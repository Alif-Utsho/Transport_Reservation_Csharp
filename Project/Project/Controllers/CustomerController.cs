using Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Controllers
{
    public class CustomerController
    {
        static Database db = new Database();

        public static List<Customer> getAllCustomer()
        {
            return db.Customers.getAllCustomer();
        }
        public static bool addCustomer(dynamic customer)
        {
            return db.Customers.addCustomer(customer);
        }
        public static Customer searchCustomer(string phone)
        {
            return db.Customers.searchCustomer(phone);
        }
        public static bool deleteCustomer(int id)
        {
            return db.Customers.deleteCustomer(id);
        }
        public static bool updateCustomer(dynamic customer)
        {
            return db.Customers.updateCustomer(customer);
        }
    }
}
