using EstoqueClientV1.StockService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstoqueClientV1
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Press ENTER when the service has started");
            Console.ReadLine();
            ServicoEstoqueClient proxy = new ServicoEstoqueClient("BasicHttpBinding_IServicoEstoque");

            Console.WriteLine("*****************************************************************");
            //1) Adicionar um produto(por exemplo, Produto 11)
            Console.WriteLine("Adicionar um produto");
            Console.WriteLine("");
            Stock product = new Stock();
            product.ProductId = "11000";
            product.ProductName = "Produto 11";
            product.ProdcutDesc = "Este é o produto 11";
            product.Quantity = 0;
            Console.WriteLine("Id produto: " + product.ProductId);
            Console.WriteLine("Nome produto: " + product.ProductName);
            Console.WriteLine("Descricao produto: " + product.ProdcutDesc);
            bool addProduct = proxy.AddProduct(product);

            if (addProduct)
            {
                Console.WriteLine("Produto adicionado!");
                Console.WriteLine("");
            }
            else
            {
                Console.WriteLine("Erro ao adicionar produto!");
                Console.WriteLine("");

            }
            Console.WriteLine("*****************************************************************");
            //2) Remover o produto 10
            Console.WriteLine("Remover o produto 10");
            Console.WriteLine("");
            bool removeProd = proxy.RemoveProducts("10000");
            if (removeProd)
            {
                Console.WriteLine("Produto removido!");
                Console.WriteLine("");
            }
            else
            {
                Console.WriteLine("Erro ao remover produto!");
                Console.WriteLine("");

            }

            Console.WriteLine("*****************************************************************");
            //3) Listar todos os produtos
            Console.WriteLine("Listar todos os produtos");
            Console.WriteLine("");

            List<string> products = proxy.ListProducts().ToList();
            foreach (string p in products)
            {
                Console.WriteLine("Produto: {0}", p);
            }
            Console.WriteLine();
            Console.WriteLine("*****************************************************************");
            //4) Verificar todas as informações do Produto 2
            Console.WriteLine("Verificar todas as informações do Produto 2");
            Console.WriteLine("");
            StockData stock = proxy.getProduct("2000");
            if (stock != null)
            {
                Console.WriteLine("Id produto: 2000");
                Console.WriteLine("Nome produto: " + stock.ProductName);
                Console.WriteLine("Descricao produto: " + stock.ProductDesc);
                Console.WriteLine("Quantidade produto: " + stock.Quantity);
                Console.WriteLine("");
            }

            else
            {
                Console.WriteLine("Erro ao buscar produto!");
                Console.WriteLine("");
            }
            Console.WriteLine("*****************************************************************");
            //5) Adicionar 10 unidades para este produto
            Console.WriteLine("Adicionar 10 unidades para este produto");
            Console.WriteLine("");

            bool addStock = proxy.AddStock("2000", 10);
            if (addStock)
            {
                Console.WriteLine("Estoque adicionado!");
                Console.WriteLine("");
            }
            else
            {
                Console.WriteLine("Erro ao adicionar estoque!");
                Console.WriteLine("");

            }
            Console.WriteLine("*****************************************************************");
            //6) Verificar o estoque do Produto 2
            Console.WriteLine("Verificar o estoque do Produto 2");
            Console.WriteLine("");

            int stockQty = proxy.CheckStock("2000");
            Console.WriteLine("Id produto: 2000");
            Console.WriteLine("Quantidade produto: " + stockQty);
            Console.WriteLine("");
            Console.WriteLine("*****************************************************************");

            //7) Verificar o estoque atual do Produto 1
            Console.WriteLine("Verificar o estoque atual do Produto 1");
            Console.WriteLine("");

            stockQty = proxy.CheckStock("1000");
            Console.WriteLine("Id produto: 1000");
            Console.WriteLine("Quantidade produto: " + stockQty);
            Console.WriteLine("");

            Console.WriteLine("*****************************************************************");
            //8) Remover 20 unidades para este produto
            Console.WriteLine("Remover 20 unidades para este produto");
            Console.WriteLine("");
            addStock = proxy.RemoveStock("1000", 20);
            if (addStock)
            {
                Console.WriteLine("Estoque removido!");
                Console.WriteLine("");
            }
            else
            {
                Console.WriteLine("Erro ao remover estoque!");
                Console.WriteLine("");

            }
            Console.WriteLine("*****************************************************************");
            //9) Verificar o estoque do Produto 1 novamente
            Console.WriteLine("Verificar o estoque do Produto 1 novamente");
            Console.WriteLine("");

            stockQty = proxy.CheckStock("1000");
            Console.WriteLine("Id produto: 1000");
            Console.WriteLine("Quantidade produto: " + stockQty);
            Console.WriteLine("");
            Console.WriteLine("*****************************************************************");
            //10) Verificar todas as informações do Produto 1
            Console.WriteLine("Verificar todas as informações do Produto 1");
            Console.WriteLine("");

            stock = proxy.getProduct("1000");
            if (stock != null)
            {
                Console.WriteLine("Id produto: 1000");
                Console.WriteLine("Nome produto: " + stock.ProductName);
                Console.WriteLine("Descricao produto: " + stock.ProductDesc);
                Console.WriteLine("Quantidade produto: " + stock.Quantity);
                Console.WriteLine("");
            }

            proxy.Close();
            Console.WriteLine("Press ENTER to finish"); Console.ReadLine();
        }
    }
}
