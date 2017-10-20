using EstoqueEntityModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;



// TERMINAR ESSA CLASSE E DEPOIS TERMINAR CLASSE SERVICO ESTOQUE, TEREMOS DOIS SERVICES CONTRACTS AQUI!!!
namespace EstoqueLibrary
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract(Namespace = "http://projetoavaliativo.dm113/01", Name = "IServicoEstoque")]
    public interface IServicoEstoque
    {
        // Get all products
        [OperationContract]
        List<string> ListProducts();
        // Add Products
        [OperationContract]
        bool AddProduct(Stock stock);
        // Remove products
        [OperationContract]
        bool RemoveProducts(string productCode);
        // Get the current stock for a product
        [OperationContract]
        int CheckStock(string productCode);
        // Add stock for a product
        [OperationContract]
        bool AddStock(string productCode, int quantity);
        //erase the stock of a product
        [OperationContract]
        bool RemoveStock(string productCode, int quantity);
        //get product detail
        [OperationContract]
        StockData getProduct(string productCode);

    }

    [ServiceContract(Namespace = "http://projetoavaliativo.dm113/02", Name = "IServicoEstoqueV2")]
    public interface IServicoEstoqueV2
    {
        // Get the current stock for a product
        [OperationContract]
        int CheckStock(string productCode);
        // Add stock for a product
        [OperationContract]
        bool AddStock(string productCode, int quantity);
        //erase the stock of a product
        [OperationContract]
        bool RemoveStock(string productCode,int quantity);
    }

    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    // You can add XSD files into the project. After building the project, you can directly use the data types defined there, with the namespace "EstoqueLibrary.ContractType".
    [DataContract]
    public class StockData
    {
        [DataMember]
        public string ProductId { get; set; }
        [DataMember]
        public string ProductName { get; set; }
        [DataMember]
        public string ProductDesc { get; set; }
        [DataMember]
        public decimal Quantity { get; set; }

        
       /* public string ProductId
        {
            get { return productId; }
            set { productId = value; }
        }

        
        public string ProductName
        {
            get { return productName; }
            set { productName = value; }
        }

        [DataMember]
        public string ProdcutDesc
        {
            get { return prodcutDesc; }
            set { prodcutDesc = value; }
        }

        [DataMember]
        public decimal Quantity
        {
            get { return quantity; }
            set { quantity = value; }
        }*/
    }
}
