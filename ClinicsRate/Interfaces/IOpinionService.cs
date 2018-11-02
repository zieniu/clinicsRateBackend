using ClinicsRate.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicsRate.Interfaces
{
    public interface IOpinionService
    {
        Task<IEnumerable<Opinion>> GetAllOpinionsAsync();
        Task<int> AddOpinionAsync(Opinion opinion);
        Task<int> UpdateOpinionAsync(Opinion opinion);
        Task DeleteOpinionAsync(int opinionId);
    }
}
