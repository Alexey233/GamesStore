using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamesStore.Data.Sql
{
    public class GameStoreContext : DbContext
    {
        public DbSet<GameEntity> Games { get; set; }   
        public DbSet<CheckEntity> Checks { get; set; }
        public GameStoreContext() : base()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql($"Host=localhost;Port=5432;Database=newDb;Username=postgres;Password=19781978");
        }
    }
}
