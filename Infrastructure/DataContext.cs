using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure
{
    /* !Comment: Data context Class to create tables of database */
    public class DataContext : DbContext
    {
        /************************************************************/
        /* !Comment: Constructor */
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        /************************************************************/


        /************************************************************/
        /* !Comment: Define the tables. They are DbSet collection of
         * the entity type */
        //!Comment: Owner Table
        public DbSet<Owner> Owner { get; set; }
        //Comment: PortfolioItem Table
        public DbSet<PortfolioItem> PortfolioItems { get; set; }
        //!Comment: No need to creat the address as it shall be
        //created automatically
        /************************************************************/


        /************************************************************/
        /* !Comemnt: Overriding the OnCreatingModel Method          */
        /************************************************************/
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // 1- Passing the model builder to the base class
            base.OnModelCreating(modelBuilder);

            /* Setting Rules */
            //Rule 1: Id of type Guid to be numbered autmatically
            modelBuilder.Entity<Owner>().Property(x => x.Id).HasDefaultValueSql("NEWID()");
            //Rule 2: Id of type Guid to be numbered autmatically
            modelBuilder.Entity<PortfolioItem>().Property(x => x.Id).HasDefaultValueSql("NEWID()");
            //Rule 3: Owner table has default value when building
            modelBuilder.Entity<Owner>().HasData(
                new Owner()
                {
                    Id = Guid.NewGuid(),
                    FullName = "Ahmed Shaban Helwa",
                    Profile = "Software Developer",
                    Avatar = "avatar.jpg"
                }
                );
        }

    }
}
