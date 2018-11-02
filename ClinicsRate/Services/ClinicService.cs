using ClinicsRate.Helpers;
using ClinicsRate.Interfaces;
using ClinicsRate.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicsRate.Services
{
    public class ClinicService : IClinicService
    {
        private readonly ClinicRateDbContext _clinicRateDbContext;

        public ClinicService(ClinicRateDbContext clinicRateDbContext)
        {
            _clinicRateDbContext = clinicRateDbContext;
        }

        /// <summary>
        /// Metoda dodająca nową klinike do bazy danych
        /// </summary>
        /// <param name="clinic"></param>
        /// <returns></returns>
        public async Task<int> AddClinicAsync(Clinic clinic)
        {
            if(clinic == null)
            {
                throw new Exception("Obiekt clinic nie może być pusty.");
            }

            _clinicRateDbContext.Clinics.Add(clinic);
            await _clinicRateDbContext.SaveChangesAsync();

            return clinic.ClinicId;
        }

        /// <summary>
        /// Metoda usuwająca klinike o podanym nr id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task DeleteClinicAsync(int id)
        {
            if (id <= 0)
            {
                throw new Exception("Zmienna id nie może być mniejsza bądź równa 0");
            }

            var clinic = await _clinicRateDbContext.Clinics.SingleOrDefaultAsync(s => s.ClinicId == id);

            if (clinic != null)
            {
                _clinicRateDbContext.Remove(clinic);
                _clinicRateDbContext.RemoveRange(_clinicRateDbContext.Opinions.Where(s => s.ClinicId == id));
                await _clinicRateDbContext.SaveChangesAsync();
            }
        }


        /// <summary>
        /// Metoda zwracająca klinike o podanym id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Clinic> GetClinicAsync(int id)
        {
            if (id <= 0)
            {
                throw new Exception("Zmienna id nie może być mniejsza bądź równa 0");
            }

            var clinic = await _clinicRateDbContext.Clinics.SingleOrDefaultAsync(s => s.ClinicId == id);

            if (clinic == null)
            {
                throw new Exception("Nie znaleziono kliniki o podanym id");
            }

            return clinic;
        }


        /// <summary>
        /// Metoda odpowiadajaca za wyświetlanie wszystkich klinik znajdujących się w bazie danych
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Clinic>> GetClinicsAsync()
        {
            return await _clinicRateDbContext.Clinics.ToListAsync();
        }


        /// <summary>
        /// Metoda odpowiadajaca za aktualizowanie kliniki w bazie danych
        /// </summary>
        /// <param name="clinic"></param>
        /// <returns></returns>
        public async Task<int> UpdateClinicAsync(Clinic clinic)
        {
            if (clinic == null)
            {
                throw new Exception("Obiekt clinic nie może być pusty.");                
            }

            _clinicRateDbContext.Clinics.Update(clinic);
            await _clinicRateDbContext.SaveChangesAsync();
            return clinic.ClinicId;
        }
    }
}
