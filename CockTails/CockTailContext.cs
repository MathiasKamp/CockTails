using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;

namespace CockTails
{
    /// <summary>
    /// this class's purpose is to establish a db connection using entity framework
    /// </summary>
    public class CockTailContext : DbContext
    {
        public CockTailContext() : base("name=CockTailsDbConnectionString")
        {
            // this part makes sure that the program drops the current database before it tries to run.
            Database.SetInitializer<CockTailContext>(new DropCreateDatabaseAlways<CockTailContext>());
        }


        // property to access Drinks table
        public DbSet<Drinks> Drinks { get; set; }

        // property to access ingredients table
        public DbSet<Ingredients> Ingredients { get; set; }
    }
}