using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicsRate.Models
{
    public class Opinion
    {
        [Key]
        public int Id { get; set; }
        public string Username { get; set; }
        public string Description { get; set; }
        public int Rate { get; set; }


        public int ClinicId { get; set; }
        public virtual Clinic Clinic { get; set; }

        public int? UserId { get; set; }
        public User User { get; set; }

    }
}
