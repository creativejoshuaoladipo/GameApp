using Microsoft.EntityFrameworkCore;
using SimplWebService.SimplWebService.Data.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimplWebService.SimplWebService.Data.DataContext
{
    public class GamesDBContext : DbContext
    {

        public GamesDBContext(DbContextOptions<GamesDBContext> options) : base(options)
        {

        }

        public DbSet<Game> Games { get; set; }

    }

    
}
