using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorBattles.Shared;
using Microsoft.EntityFrameworkCore;

namespace BlazorBattles.Server.Data
{
    public class DataContext: DbContext
    //Query db models og save til db
    //Abstraction af data, repository pattern
    {
        public DataContext(DbContextOptions<DataContext> options):base(options)
        {
                
        }

        public DbSet<Unit> Units { get; set; }
        //Query units, navn af entity

    }
}
