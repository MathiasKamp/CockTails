using System.Collections.Generic;
using System.Data.Entity;

namespace CockTails
{
    public class CockTailContext : DbContext
    {
        public CockTailContext() : base("name=CockTailsDbConnectionString")
        {
            Database.SetInitializer<CockTailContext>(new DropCreateDatabaseAlways<CockTailContext>());
        }


        public DbSet<Drinks> Drinks { get; set; }
        public DbSet<Ingredients> Ingredients { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //Configure domain classes using modelBuilder here..
        }
    }
}