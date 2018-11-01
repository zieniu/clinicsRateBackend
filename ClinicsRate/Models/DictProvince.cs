using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicsRate.Models
{
    public class DictProvince
    {
        [Key]
        public int DictProvinceId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Clinic> Clinics { get; set; }
    }
}
