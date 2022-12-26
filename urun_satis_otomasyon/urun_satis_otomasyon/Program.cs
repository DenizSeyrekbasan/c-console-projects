using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace urun_satis_otomasyon
{
    internal class Program
    {
        public class shop
        {
            public string name = "";
            public string location = "";

            List<productSeller> Products = new List<productSeller>();
            
            public void addProduct(string s_name_sur,string s_gsm,string s_id,string p_name,string p_cont,string p_price)
            {
                productSeller newProduct = new productSeller();
                newProduct.sellerNameSurname = s_name_sur;
                newProduct.sellerGsm = s_gsm;
                newProduct.sellerId = s_id;
                newProduct.productName = p_name;
                newProduct.productContent = p_cont;
                newProduct.productPrice = p_price;

                Products.Add(newProduct);
            }
            public void productDelete(string seller_id)
            {
                foreach(var item in Products)
                {
                    if (item.sellerId==seller_id)
                    {
                        Products.Remove(item);
                        break;
                    }
                }
            }
            public void productList()
            {
                foreach(var item in Products)
                {
                   Console.WriteLine("Seller name : {0}\n" + "Seller GSM : {1}\n" + "Seller ID : {2}\n" + "Product Name : {3}\n" + "Product Content : {4}\n" + "Product Price : {5} $", item.sellerNameSurname, item.sellerGsm, item.sellerId, item.productName, item.productContent, item.productPrice);
                   Console.WriteLine("***************************");
                }
            }
            
        }
        public class productSeller
        {
            public string sellerNameSurname = "";
            public string sellerGsm = "";
            public string sellerId = "";
            public string productName = "";
            public string productContent = "";
            public string productPrice = "";          
        }
        static void Main(string[] args)
        {
            shop newProduct = new shop();
            newProduct.name = "PersonalSellerShop";
            newProduct.location = "Zonguldak";

            while (true)
            {
                Console.Clear();
                Console.WriteLine("Welcome to the PersonalSellerShop");
                Console.WriteLine("Add a new product for : 1");
                Console.WriteLine("List for              : 2");
                Console.WriteLine("Delete a product for  : 3");
                Console.WriteLine("Exit for              : ESC");

                var key = Console.ReadKey();

                if (key.Key==ConsoleKey.NumPad1)
                {
                    Console.WriteLine();
                    Console.Write("Seller name-surname : ");
                    string s_name = Console.ReadLine();

                    Console.Write("Seller GSM : ");
                    string s_gsm = Console.ReadLine();

                    Console.Write("Seller ID : ");
                    string s_id = Console.ReadLine();

                    Console.Write("Product name : ");
                    string p_name = Console.ReadLine();

                    Console.Write("Product content : ");
                    string p_content = Console.ReadLine();

                    Console.Write("Product price : ");
                    string p_price = Console.ReadLine();
                    
                    newProduct.addProduct(s_name, s_gsm, s_id, p_name, p_content, p_price);
                    Console.WriteLine("Successfully uploaded ! For continue press a key..");
                    Console.ReadLine();
                }
                if (key.Key == ConsoleKey.NumPad2)
                {
                    Console.WriteLine("***************************");
                    newProduct.productList();
                    Console.WriteLine("For continue press a key..");
                    Console.ReadLine();
                }
                if (key.Key == ConsoleKey.NumPad3)
                {
                    newProduct.productList();
                    Console.Write("Which do you want to delete products(write a seller ID) = ");
                    string SELLER_ID = Console.ReadLine();
                    newProduct.productDelete(SELLER_ID);
                    Console.WriteLine("Successfully deleted ! For continue press a key..");
                    Console.ReadLine();
                }
                if (key.Key == ConsoleKey.Escape)
                {
                    break;
                }
            }
        }
    }
}
