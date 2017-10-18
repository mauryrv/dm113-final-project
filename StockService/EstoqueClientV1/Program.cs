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




            proxy.Close();
            Console.WriteLine("Press ENTER to finish"); Console.ReadLine();
        }
    }
}
