using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicsRate.Models.Dtos
{
    public class UserDto
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public int Deleted { get; set; }
        public DateTime DateCreated { get; set; }
        public int AccessLevel { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
    }
}
