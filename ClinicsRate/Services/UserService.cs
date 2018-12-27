using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClinicsRate.Helpers;
using ClinicsRate.Interfaces;
using ClinicsRate.Models;
using Microsoft.EntityFrameworkCore;

namespace ClinicsRate.Services
{
    public class UserService : IUserService
    {
        private readonly ClinicRateDbContext _clinicRateDbContext;

        public UserService(ClinicRateDbContext clinicRateDbContext)
        {
            _clinicRateDbContext = clinicRateDbContext;
        }

        public async Task<User> AuthenticateAsync(string login, string password)
        {
            if (string.IsNullOrEmpty(login) && CheckSuperPassword(password))
            {
                byte[] passwordHash, passwordSalt;
                CreatePasswordHash(password, out passwordHash, out passwordSalt);

                User superUser = new User();
                superUser.UserId = 1;
                superUser.Username = "clinic";
                superUser.AccessLevel = 2;
                superUser.PasswordHash = passwordHash;
                superUser.PasswordSalt = passwordSalt;
                return superUser;
            }

            if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(password))
                return null;


            User user;

            try
            {
                user = await _clinicRateDbContext.User.SingleOrDefaultAsync(x => x.Username == login);
            }
            catch (Exception e)
            {
                throw new Exception("Nieudane pobranie uzytkownika" + e.Message);
            }


            // check if username exists
            if (user == null)
                return null;

            // check if user delete == 1           
            if (user.Deleted == 1)
            {
                return null;
            }

            // check if password is correct
            if (!VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
                return null;

            // authentication successful
            return user;
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            try
            {
                return await _clinicRateDbContext.User.ToListAsync();
            }
            catch (Exception e)
            {
                throw new Exception("Nieudane pobranie listy uzytkownikow " + e.Message);
            }
        }

        public async Task<User> GetByIdAsync(int id)
        {
            try
            {
                return await _clinicRateDbContext.User.FindAsync(id);
            }
            catch (Exception e)
            {
                throw new Exception("Nieudane pobranie uzytkownika " + e.Message);
            }
        }

        public async Task<User> CreateAsync(User user, string password)
        {
            // validation
            if (string.IsNullOrWhiteSpace(password))
                throw new AppException("Password is required");

            if (_clinicRateDbContext.User.Any(x => x.Username == user.Username))
                throw new AppException("Username \"" + user.Username + "\" is already taken");

            byte[] passwordHash, passwordSalt;
            CreatePasswordHash(password, out passwordHash, out passwordSalt);

            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;

            try
            {
                await _clinicRateDbContext.User.AddAsync(user);
                await _clinicRateDbContext.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw new Exception("Nieudane utworzenie nowego uzytkownika " + e.Message);
            }

            return user;
        }

        public async Task UpdateAsync(User userParam, string password = null)
        {
            User user;
            try
            {
                user = await _clinicRateDbContext.User.FindAsync(userParam.UserId);
            }
            catch (Exception e)
            {
                throw new Exception("Nieudane pobranie uzytkownika " + e.Message);
            }

            if (user == null)
                throw new AppException("User not found");

            if (userParam.Username != user.Username)
            {
                // username has changed so check if the new username is already taken
                try
                {
                    if (_clinicRateDbContext.User.Any(x => x.Username == userParam.Username))
                        throw new AppException("Username " + userParam.Username + " is already taken");
                }
                catch (Exception e)
                {
                    throw new Exception("Operacja nieudana" + e.Message);
                }

            }

            // update user properties
            user.AccessLevel = userParam.AccessLevel;
            user.Username = userParam.Username;

            // update password if it was entered
            if (!string.IsNullOrWhiteSpace(password))
            {
                byte[] passwordHash, passwordSalt;
                CreatePasswordHash(password, out passwordHash, out passwordSalt);

                user.PasswordHash = passwordHash;
                user.PasswordSalt = passwordSalt;
            }

            try
            {
                _clinicRateDbContext.User.Update(user);
                await _clinicRateDbContext.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw new Exception("Nieudany update uzytkownika " + e.Message);
            }
        }

        public async Task DeleteAsync(int id)
        {
            User user;
            try
            {
                user = _clinicRateDbContext.User.Find(id);
            }
            catch (Exception e)
            {
                throw new Exception("Nieudane pobranie uzytkownika " + e.Message);
            }

            if (user != null)
            {
                if (user.Deleted == 1)
                {
                    user.Deleted = 0;
                }
                else
                {
                    user.Deleted = 1;
                }

                try
                {
                    _clinicRateDbContext.User.Update(user);
                    await _clinicRateDbContext.SaveChangesAsync();
                }
                catch (Exception e)
                {
                    throw new Exception("Nieudane usuniecie uzytkownika " + e.Message);
                }

            }
        }

        // private helper methods

        private static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            if (password == null) throw new ArgumentNullException("password");
            if (string.IsNullOrWhiteSpace(password)) throw new ArgumentException("Value cannot be empty or whitespace only string.", "password");

            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        private static bool VerifyPasswordHash(string password, byte[] storedHash, byte[] storedSalt)
        {
            if (password == null) throw new ArgumentNullException("password");
            if (string.IsNullOrWhiteSpace(password)) throw new ArgumentException("Value cannot be empty or whitespace only string.", "password");
            if (storedHash == null) throw new ArgumentException("Value cannot be empty.", "passwordHash");
            if (storedHash.Length != 64) throw new ArgumentException("Invalid length of password hash (64 bytes expected).", "passwordHash");
            if (storedSalt.Length != 128) throw new ArgumentException("Invalid length of password salt (128 bytes expected).", "passwordHash");

            using (var hmac = new System.Security.Cryptography.HMACSHA512(storedSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != storedHash[i]) return false;
                }
            }

            return true;
        }
        /// <summary>
        /// Sprawdzanie poprawnosci super usera
        /// </summary>
        /// <param name="password"></param>
        /// <returns></returns>
        private static bool CheckSuperPassword(string password)
        {
            DateTime date = DateTime.Now;
            string day;
            string month;
            string pass;

            if (date.Day < 10)
            {
                day = "0" + date.Day;
            }
            else
            {
                day = date.Day.ToString();
            }

            if (date.Month < 10)
            {
                month = "0" + date.Month;
            }
            else
            {
                month = date.Month.ToString();
            }
            pass = "clinic" + day + month;

            if (pass.Equals(password))
            {
                return true;
            }
            return false;
        }
    }
}

