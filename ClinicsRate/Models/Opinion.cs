using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicsRate.Models
{
    public class Opinion
    {
        public int OpinionId { get; set; }
        public string Username { get; set; }
        public string Description { get; set; }
        public double Rate { get; set; }

        public int ClinicId { get; set; }
        public virtual Clinic Clinic { get; set; }

        public int? UserId { get; set; }
        public User User { get; set; }

    }
}
