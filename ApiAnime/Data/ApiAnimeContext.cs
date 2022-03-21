using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ApiAnime.Models;

namespace ApiAnime.Data
{
    public class ApiAnimeContext : DbContext
    {
        public ApiAnimeContext (DbContextOptions<ApiAnimeContext> options)
            : base(options)
        {
        }

        public DbSet<ApiAnime.Models.Anime_User> Anime_User { get; set; }

        public DbSet<ApiAnime.Models.AnimeData> AnimeData { get; set; }

        public DbSet<ApiAnime.Models.UserData> UserData { get; set; }
    }
}
