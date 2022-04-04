using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ApiAnime.Models
{
    public class AnimeData
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string Name { get; set; }
        public string Description { get; set; }
        public string Episodes { get; set; }
        public string Image { get; set; }
        public string Producers { get; set; }
        public string Date { get; set; }
        public string Genres { get; set; }
        public string Status { get; set; }
        public string Premiered { get; set; }
        public string Broadcast { get; set; }
        public string Demographic { get; set; }
        public string Duration { get; set; }

    }
}