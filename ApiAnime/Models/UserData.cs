using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ApiAnime.Models
{
    public class UserData
    {
        [Key]
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Role { get; set; }
        public int Edad { get; set; }
        public string Sexo { get; set; }
        public string Biografia { get; set; }

        [JsonIgnore]
        public string Password { get; set; }
    }
}
