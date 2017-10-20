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
            Console.WriteLine("*****************************************************************");
            //1) Verificar o estoque atual do Produto 1
            Console.WriteLine("Verificar o estoque atual do Produto 1");
            Console.WriteLine("");

            int stockQty = proxy.CheckStock("1000");
            Console.WriteLine("Id produto: 1000");
            Console.WriteLine("Quantidade produto: " + stockQty);
            Console.WriteLine("");

            Console.WriteLine("*****************************************************************");
            //2) Adicionar 20 unidades para este produto
            Console.WriteLine("Adicionar 20 unidades para este produto");
            Console.WriteLine("");
            bool addStock = proxy.AddStock("1000", 20);
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
            //3) Verificar o estoque do Produto 1 novamente
            Console.WriteLine("Verificar o estoque do Produto 1 novamente");
            Console.WriteLine("");
            stockQty = proxy.CheckStock("1000");
            Console.WriteLine("Id produto: 1000");
            Console.WriteLine("Quantidade produto: " + stockQty);
            Console.WriteLine("");

            Console.WriteLine("*****************************************************************");
            //4) Verificar o estoque atual do Produto 5
            Console.WriteLine("Verificar o estoque atual do Produto 5");
            Console.WriteLine("");
            stockQty = proxy.CheckStock("5000");
            Console.WriteLine("Id produto: 5000");
            Console.WriteLine("Quantidade produto: " + stockQty);
            Console.WriteLine("");
            Console.WriteLine("*****************************************************************");
            //5) Remover 10 unidades para este produto
            Console.WriteLine("Remover 10 unidades para este produto");
            Console.WriteLine("");
            addStock = proxy.RemoveStock("5000", 10);
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
            //6) Verificar o estoque do Produto 5 novamente
            Console.WriteLine("Verificar o estoque do Produto 5 novamente");
            Console.WriteLine("");

            stockQty = proxy.CheckStock("5000");
            Console.WriteLine("Id produto: 5000");
            Console.WriteLine("Quantidade produto: " + stockQty);
            Console.WriteLine("");
            Console.WriteLine("*****************************************************************");


            proxy.Close();
            Console.WriteLine("Press ENTER to finish"); Console.ReadLine();


        }
    }
}
