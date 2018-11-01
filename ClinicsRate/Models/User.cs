using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicsRate.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        public string Username { get; set; }
        public AccessLevel AccessLevel { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }

        public virtual ICollection<Opinion> Opinions { get; set; }
    }

    public enum AccessLevel
    {
        User = 0,
        Moderator = 1,
        Admin = 2,
    }
}
