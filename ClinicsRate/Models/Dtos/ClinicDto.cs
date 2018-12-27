using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicsRate.Models.Dtos
{
    public class ClinicDto
    {
        public int ClinicId { get; set; }
        public double Longitude { get; set; }
        public double Latitude { get; set; }
        public string ClinicName { get; set; }
        public string Street { get; set; }
        public string PhoneNumber { get; set; }
        public string PostCode { get; set; }
        public string Province { get; set; }
        public string City { get; set; }
        public double Average { get; set; }
        public int Accepted { get; set; }
    }
}
