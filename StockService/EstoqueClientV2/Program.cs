using EstoqueClientV2.StockService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstoqueClientV2
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Press ENTER when the service has started");
            Console.ReadLine();



            ServicoEstoqueV2Client proxy = new ServicoEstoqueV2Client("WS2007HttpBinding_IServicoEstoque");
            // ProductsServiceClient proxy = new ProductsServiceClient("NetTcpBinding_IProductsService");
            // Create a proxy object and connect to the service 
            //ProductsServiceClient proxy = new ProductsServiceClient();
            /*Console.WriteLine("Test 1: List all products");
            proxy.ListMatchingProducts("Prod").ToList();
            List<ProductData> products = proxy.ListMatchingProducts("Prod").ToList();//proxy.ListProducts().ToList();
            foreach (ProductData p in products)
            {
                Console.WriteLine("Name: {0}", p.Name);
                Console.WriteLine("Code: {0}", p.Code);
                Console.WriteLine("Price: {0}", p.Price);
                Console.WriteLine();
            }
            Console.WriteLine();

            // Get details of this product
            Console.WriteLine("Test 2: Display the details of a product");
            ProductData product = proxy.GetProduct("0001");
            Console.WriteLine("Name: {0}", product.Name);
            Console.WriteLine("Code: {0}", product.Code);
            Console.WriteLine("Price: {0}", product.Price);
            Console.WriteLine();

            // Query the stock of this product
            Console.WriteLine("Test 3: Display stock of a product");
            int quantity = proxy.CurrentStock("0001");
            Console.WriteLine("Current stock: {0}", quantity);

            // Add stock of this product
            Console.WriteLine("Test 4: Add stock for a product");
            if (proxy.AddStock("0001", 100))
            {
                quantity = proxy.CurrentStock("0001");
                Console.WriteLine("Stock changed. Current stock: {0}", quantity);
            }
            else
            {
                Console.WriteLine("Stock update failed");
            }
            Console.WriteLine();

            // Get details of this product
            Console.WriteLine("Test 2: Display the details of a product");
            /*ProductData 
            product = proxy.GetProduct("123");
            if (product != null)
            {
                Console.WriteLine("Name: {0}", product.Name);
                Console.WriteLine("Code: {0}", product.Code);
                Console.WriteLine("Price: {0}", product.Price);
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("No such product");
                Console.WriteLine();
            }
            */





           proxy.Close();
            Console.WriteLine("Press ENTER to finish"); Console.ReadLine();


        }
    }
}
