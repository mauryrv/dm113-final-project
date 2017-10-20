using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using EstoqueEntityModel;

namespace EstoqueLibrary
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class ServicoEstoque : IServicoEstoque, IServicoEstoqueV2
    {
        public bool AddProduct(Stock product)
        {
            try { 
                using (ProvedorEstoque database = new ProvedorEstoque())
                {
                    if (ProductExists(product.ProductId, database))
                        return false;
                    else
                    {
                        database.Stocks.Add(product);
                        database.SaveChanges();
                    }
                }

            }
            catch(Exception ex)
            {
                // If an exception occurs, return false to indicate failure
                return false;
            }
            // Return true to indicate success
            return true;
        }

        public bool AddStock(string productCode, int quantity)
        {
            try
            {
                // Connect to the ProductsModel database
                using (ProvedorEstoque database = new ProvedorEstoque())
                {
                    if (!ProductExists(productCode, database))
                        return false;
                    else
                    {

                        // Find the Stock object that matches the parameters passed
                        // in to the operation
                        Stock stockOrigin = database.Stocks.First(pi => pi.ProductId == productCode);
                        Stock stockUpdated = stockOrigin;
                        stockUpdated.Quantity = stockOrigin.Quantity+quantity;
                        database.Entry(stockOrigin).CurrentValues.SetValues(stockUpdated);
                        database.SaveChanges();
                    }
                }

            }
            catch(Exception ex)
            {
                // If an exception occurs, return false to indicate failure
                return false;
            }
            // Return true to indicate success
            return true;
        }

        public int CheckStock(string productCode)
        {

            int quantityTotal = 0;
            try
            {
                // Connect to the ProductsModel database
                using (ProvedorEstoque database = new ProvedorEstoque())
                {
                    if (ProductExists(productCode, database))
                    {
                        // Calculate the sum of all quantities for the specified product
                        quantityTotal = (from p in database.Stocks
                                         where String.Compare(p.ProductId, productCode) == 0
                                         select (int)p.Quantity).Sum();
                    }
                    
                }
            }
            catch(Exception ex)
            {
                // Ignore exceptions in this implementation
            }
            // Return the stock level
            return quantityTotal;
        }

        public StockData getProduct(string productCode)
        {
            StockData product = null;
            try
            {
                // Connect to the ProductsModel database
                using (ProvedorEstoque database = new ProvedorEstoque())
                {
                    if (ProductExists(productCode, database))
                    {
                        Stock matchingProduct = database.Stocks.First(p => String.Compare(p.ProductId, productCode) == 0);
                        product = new StockData()
                        {
                            ProductName = matchingProduct.ProductName,
                            ProductDesc = matchingProduct.ProdcutDesc,
                            Quantity = matchingProduct.Quantity

                        };
                    }
                }
            }
            catch
            {
                // Ignore exceptions in this implementation
            }
            // Return the product
            return product;
        }

        public List<string> ListProducts()
        {
            List<string> products = new List<string>();
            try
            {
                // Connect to the ProductsModel database
                using (ProvedorEstoque database = new ProvedorEstoque())
                {
                    // Fetch the products in the database
                     products = (from product in database.Stocks select product.ProductName).ToList();
                   /* foreach (Product product in products)
                    {
                        ProductData productData = new ProductData()
                        {
                            Name = product.Name,
                            Code = product.Code,
                            Price = product.Price
                        };
                        productsList.Add(productData);
                    }*/
                }
            }
            catch
            {
                // Ignore exceptions in this implementation
            }
            // Return the list of products
            return products;
        }

        public bool RemoveProducts(string productCode)
        {

            try
            {
                // Connect to the ProductsModel database
                using (ProvedorEstoque database = new ProvedorEstoque())
                {
                    if (!ProductExists(productCode, database))
                        return false;
                    else
                    {

                        // Find the Stock object that matches the parameters passed
                        // in to the operation
                        Stock stock = database.Stocks.First(pi => pi.ProductId == productCode);
                        database.Stocks.Remove(stock);
                        database.SaveChanges();
                    }
                }

            }
            catch
            {
                // If an exception occurs, return false to indicate failure
                return false;
            }
            // Return true to indicate success
            return true;

        }

        public bool RemoveStock(string productCode, int quantity)
        {
            try
            {
                // Connect to the ProductsModel database
                using (ProvedorEstoque database = new ProvedorEstoque())
                {
                    if (!ProductExists(productCode, database))
                        return false;
                    else
                    {
                        // Find the Stock object that matches the parameters passed
                        // in to the operation
                        Stock stockOrigin = database.Stocks.First(pi => pi.ProductId == productCode);
                        Stock stockUpdated = stockOrigin;


                        if (quantity > stockOrigin.Quantity)
                            return false;

                        stockUpdated.Quantity = stockOrigin.Quantity - quantity;
                        database.Entry(stockOrigin).CurrentValues.SetValues(stockUpdated);
                        database.SaveChanges();

                    }
                }

            }
            catch(Exception ex)
            {
                // If an exception occurs, return false to indicate failure
                return false;
            }
            // Return true to indicate success
            return true;
        }

        public bool ProductExists(string productCode, ProvedorEstoque database)
        {
            // Check to see whether the specified product exists in the database
            int numProducts = (from p in database.Stocks
                               where string.Equals(p.ProductId, productCode)
                               select p).Count();
            return numProducts > 0;
        }

    }
}
