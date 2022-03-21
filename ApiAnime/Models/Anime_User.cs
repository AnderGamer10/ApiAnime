using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ApiAnime.Models
{
    public class Anime_User
    {
        [Key]
        public int FavoritoId { get; set; }
        [Required]
        [ForeignKey("AnimeData")]
        public string AnimeName { get; set; }
        [Required]
        [ForeignKey("UserData")]
        public int UsuarioId { get; set; }

        //PROPIEDADES DE NAVEGACIÓN
        [System.Text.Json.Serialization.JsonIgnore]
        public AnimeData AnimeData { get; set; }

        [System.Text.Json.Serialization.JsonIgnore]
        public UserData UserData { get; set; }
    }
}
