namespace OrdersAssignment.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using OrdersAssignment.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<OrdersAssignment.Models.OrdersAssignmentContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(OrdersAssignment.Models.OrdersAssignmentContext context)
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

            context.Customers.AddOrUpdate(c => c.Name,
                new Customer { Name = "cust1", CreditLimit = 1000m, IsDeleted = false },
                new Customer { Name = "cust2", CreditLimit = 750m, IsDeleted = false },
                new Customer { Name = "cust3", CreditLimit = 500m, IsDeleted = false },
                new Customer { Name = "cust4", CreditLimit = 7500m, IsDeleted = false }
                );
        }
    }
}
