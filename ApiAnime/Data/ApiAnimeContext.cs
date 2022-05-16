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

        public DbSet<Anime_User> Anime_User { get; set; }

        public DbSet<AnimeData> AnimeData { get; set; }

        public DbSet<UserData> UserData { get; set; }






















    }
}
