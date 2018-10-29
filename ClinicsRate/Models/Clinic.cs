using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicsRate.Models
{
    public class Clinic
    {
        [Key]
        public int Id { get; set; }
        public double PositionX { get; set; }
        public double PositionY { get; set; }
        public string Name { get; set; }
        public string Street { get; set; }
        public string PhoneNumber { get; set; }
        public string PostCode { get; set; }

        public int Province { get; set; }
        public virtual DictProvince DictProvince { get; set; }

        public int City { get; set; }
        public virtual DictCity DictCity { get; set; }


        public virtual ICollection<Opinion> Opinions { get; set; }
    }
}
