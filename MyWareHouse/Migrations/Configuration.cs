namespace MyWareHouse.Migrations
{
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;


    internal sealed class Configuration : DbMigrationsConfiguration<DataAccess.MyWareHouseContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "DataAccess.MyWareHouseContext";
        }

        protected override void Seed(DataAccess.MyWareHouseContext db)
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
            db.Products.AddOrUpdate(
                p => p.Name,
                new Products { Name = "samsung GX-1000", Catagory = "Electronics", Price = 2999, Count = 3 },
                new Products { Name = "Appel", Catagory = "Electronics", Price = 100000, Count = 2 },
                new Products { Name = "BedLex", Catagory = "Furniture", Price = 2999, Count = 13 }
                );
        }
    }
}
