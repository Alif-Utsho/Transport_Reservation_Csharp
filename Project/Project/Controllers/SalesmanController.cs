using Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Controllers
{
    class SalesmanController
    {
        static Database db = new Database();

        public static List<Salesman> getAllSalesman()
        {
            return db.Sellers.getAllSalesman();
        }
        public static bool addSalesman(dynamic salesman)
        {
            return db.Sellers.addSalesMan(salesman);
        }
        public static Salesman searchSalesman(string username)
        {
            return db.Sellers.searchSalesman(username);
        }
        public static bool updateSalesman(dynamic salesman)
        {
            return db.Sellers.updateSalesman(salesman);
        }
        public static bool deleteSalesman(int id)
        {
            return db.Sellers.deleteSalesman(id);
        }
    }
}
