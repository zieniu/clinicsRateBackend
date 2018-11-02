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
    public class OpinionService : IOpinionService
    {
        private readonly ClinicRateDbContext _clinicRateDbContext;

        public OpinionService(ClinicRateDbContext clinicRateDbContext)
        {
            _clinicRateDbContext = clinicRateDbContext;
        }

        /// <summary>
        /// Metoda dodająca nową opinie do bazy danych
        /// </summary>
        /// <param name="opinion"></param>
        /// <returns></returns>
        public async Task<int> AddOpinionAsync(Opinion opinion)
        {
            if (opinion == null)
            {
                throw new Exception("Obiekt opinion nie może być pusty.");
            }

            await _clinicRateDbContext.Opinions.AddAsync(opinion);
            await _clinicRateDbContext.SaveChangesAsync();

            return opinion.ClinicId;
        }

        /// <summary>
        /// Metoda usuwająca wybraną opinię z bazy danych
        /// </summary>
        /// <param name="opinionId"></param>
        /// <returns></returns>
        public async Task DeleteOpinionAsync(int opinionId)
        {
            if (opinionId <= 0)
            {
                throw new Exception("Obiekt opinionId nie może być mniejszy bądź równy 0");
            }

            var opinion = await _clinicRateDbContext.Opinions.SingleOrDefaultAsync(s => s.OpinionId == opinionId);

            if (opinion != null)
            {
                _clinicRateDbContext.Opinions.Remove(opinion);
                await _clinicRateDbContext.SaveChangesAsync();
            }

        }

        /// <summary>
        /// Metoda zwracająca wszystkie opinie w bazie danych
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Opinion>> GetAllOpinionsAsync()
        {
            return await _clinicRateDbContext.Opinions.ToArrayAsync();
        }

        /// <summary>
        /// Metoda aktualizująca podany rekord w bazie danych
        /// </summary>
        /// <param name="opinion"></param>
        /// <returns></returns>
        public async Task<int> UpdateOpinionAsync(Opinion opinion)
        {
            if (opinion == null)
            {
                throw new Exception("Obiekt opinion nie może być pusty.");
            }

            _clinicRateDbContext.Opinions.Update(opinion);
            await _clinicRateDbContext.SaveChangesAsync();

            return opinion.OpinionId;
        }
    }
}
