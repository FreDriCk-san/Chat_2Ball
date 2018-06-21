using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace Chat_2Ball.Context
{
    public class ContextDB : DbContext
    {
        public ContextDB() : base("name=ChatDB")
        {
            //Database.SetInitializer<ContextDB>(new CreateDatabaseIfNotExists<ContextDB>());
            //Database.SetInitializer<ContextDB>(new DropCreateDatabaseAlways<ContextDB>());
            Database.SetInitializer<ContextDB>(new MigrateDatabaseToLatestVersion<ContextDB, Migrations.Configuration>());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Models.Users> Users { get; set; }

        public DbSet<Models.Messages> Messages { get; set; }
    }
}