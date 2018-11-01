using ClinicsRate.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicsRate.Interfaces
{
    public interface IOpinionService
    {
        IEnumerable<Opinion> GetAllOpinions();
        Task<int> AddOpinionAsync(Opinion opinion);
        Task<int> UpdateOpinionAsync(Opinion opinion);
        Task DeleteOpinionAsync(int opinionId);
    }
}
