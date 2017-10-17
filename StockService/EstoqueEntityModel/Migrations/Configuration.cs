namespace EstoqueEntityModel.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<EstoqueEntityModel.ProvedorEstoque>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(EstoqueEntityModel.ProvedorEstoque context)
        {
            //  This method will be called after migrating to the latest version.

            context.Stocks.AddOrUpdate(
            new Stock { ProductId = "1000", ProductName = "Produto 1", ProductDesc = "Este é o produto 1", Quantity = 100 },
            new Stock { ProductId = "2000", ProductName = "Produto 2", ProductDesc = "Este é o produto 2", Quantity = 10 },
            new Stock { ProductId = "3000", ProductName = "Produto 3", ProductDesc = "Este é o produto 3", Quantity = 200 },
            new Stock { ProductId = "4000", ProductName = "Produto 4", ProductDesc = "Este é o produto 4", Quantity = 300 },
            new Stock { ProductId = "5000", ProductName = "Produto 5", ProductDesc = "Este é o produto 5", Quantity = 400 },
            new Stock { ProductId = "6000", ProductName = "Produto 6", ProductDesc = "Este é o produto 6", Quantity = 500 },
            new Stock { ProductId = "7000", ProductName = "Produto 7", ProductDesc = "Este é o produto 7", Quantity = 30 },
            new Stock { ProductId = "8000", ProductName = "Produto 8", ProductDesc = "Este é o produto 8", Quantity = 30 },
            new Stock { ProductId = "9000", ProductName = "Produto 9", ProductDesc = "Este é o produto 9", Quantity = 400 },
            new Stock { ProductId = "10000", ProductName = "Produto 10", ProductDesc = "Este é o produto 10", Quantity = 2 }

            );
            context.SaveChanges();
        }
    }
}
