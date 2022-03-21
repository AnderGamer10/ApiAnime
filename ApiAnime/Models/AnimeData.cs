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
        public string Chapters { get; set; }
        public string Image { get; set; }
        public string Studio { get; set; }
        public string Date { get; set; }
        public string Genre { get; set; }
    }
}
