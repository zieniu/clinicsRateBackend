using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicsRate.Models
{
    public class ClinicTMP
    {
        public int ClinicId { get; set; }
        public double Longitude { get; set; }
        public double Latitude { get; set; }
        public string ClinicName { get; set; }
        public string Street { get; set; }
        public string PhoneNumber { get; set; }
        public string PostCode { get; set; }

        public int ProvinceId { get; set; }
        public virtual DictProvince DictProvince { get; set; }

        public int CityId { get; set; }
        public virtual DictCity DictCity { get; set; }
    }
}
