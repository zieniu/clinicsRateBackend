using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicsRate.Models
{
    public class Clinic
    {
        [Key]
        public int ClinicId { get; set; }
        public double Longitude { get; set; }
        public double Latitude { get; set; }
        public string ClinicName { get; set; }
        public string Street { get; set; }
        public string PhoneNumber { get; set; }
        public string PostCode { get; set; }

        [ForeignKey("DictProvince")]
        public int ProvinceId { get; set; }
        public virtual DictProvince DictProvince { get; set; }

        [ForeignKey("DictCity")]
        public int CityID { get; set; }
        public virtual DictCity DictCity { get; set; }


        public virtual ICollection<Opinion> Opinions { get; set; }
    }
}
