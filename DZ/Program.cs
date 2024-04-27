using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DZ
{
    internal class Program
    {
        public static void Addroysched(roysched newOrder)
        {
            using (var context = new pubsEntities())
            {
                context.royscheds.Add(newOrder);
                context.SaveChanges();
            }
        }
        public static List<author> GetAllAuthorssWitTitle()
        {
            using (var context = new pubsEntities())
            {
                return context.authors.Include("titleauthors").ToList();
            }
        }
        public static List<store> GetAllStores()
        {
            using (var context = new pubsEntities())
            {
                return context.stores.ToList();
            }
        }
        public static List<store> GetAllStoresDiscaunt()
        {
            using (var context = new pubsEntities())
            {
                return context.stores.Include("discounts").ToList();
            }
        }
        static void Main(string[] args)
        {
            //DATABSE https://github.com/microsoft/sql-server-samples/blob/master/samples/databases/northwind-pubs/instpubs.sql
            foreach (var item in GetAllStoresDiscaunt())
            {
                Console.WriteLine(item.city);
            }

            foreach (var item in GetAllAuthorssWitTitle())
            {
                Console.WriteLine(item.au_id+ "   \t"+ item.contract);
            }
            Console.ReadKey();  
        }
    }
}
