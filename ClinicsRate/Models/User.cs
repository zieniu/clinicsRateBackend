using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicsRate.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public DateTime DateCreated { get; set; }
        public int Deleted { get; set; }
        public string Email { get; set; }
        public int AccessLevel { get; set; }

        public virtual ICollection<Opinion> Opinions { get; set; }
    }
}
