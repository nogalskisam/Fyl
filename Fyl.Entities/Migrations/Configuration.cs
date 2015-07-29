namespace Fyl.Entities.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Fyl.Entities.FylEntities>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        public Configuration(string serverName, string databaseName)
            : this()
        {
            var connectionString = String.Format("Data Source={0};Initial Catalog={1};Integrated Security=SSPI;", serverName, databaseName);
            TargetDatabase = new DbConnectionInfo(connectionString, "System.Data.SqlClient");
        }

        protected override void Seed(Fyl.Entities.FylEntities context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            AddAddresses(context);
        }

        private static void AddAddresses(FylEntities context)
        {
            if (!context.Addresses.Any())
            {
                context.Addresses.AddOrUpdate(
                    new Address()
                    {
                        HouseName = "9",
                        Address1 = "Regency Court",
                        Address2 = "53 Cardigan Road",
                        Area = "Headingley",
                        City = "Leeds",
                        County = "West Yorkshire",
                        Country = "United Kingdom",
                        Postcode = "LS6 1DW"
                    },
                    new Address()
                    {
                        HouseName = "19",
                        Address1 = "Trelawn Terrace",
                        Area = "Headingley",
                        City = "Leeds",
                        County = "West Yorkshire",
                        Country = "United Kingdom",
                        Postcode = "LS6 3JQ"
                    },
                    new Address()
                    {
                        HouseName = "79",
                        Address1 = "Headingley Avenue",
                        Area = "Headingley",
                        City = "Leeds",
                        County = "West Yorkshire",
                        Country = "United Kingdom",
                        Postcode = "LS6 3ER"
                    }
                );
            }
            context.SaveChanges();
        }
    }
}
