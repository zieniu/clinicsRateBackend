using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicsRate.Models
{
    public class DictCity
    {
        [Key]
        public int DictCityId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Clinic> Clinics { get; set; }
    }
}
