using Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Controllers
{
    class ManagersController
    {
        static Database db = new Database();

        public static bool AddManager(dynamic manager)
        {
            return db.Managers.addManager(manager);
        }

        public static List<Manager> getAllManager()
        {
            return db.Managers.getAllManager();
        }

        public static Manager getSingleManager(string username)
        {
            return db.Managers.getManager(username);
        }

        public static bool updateManager(dynamic manager)
        {
            return db.Managers.updateManager(manager);
        }

        public static bool deleteManager(int id)
        {
            return db.Managers.deleteManager(id);
        }
    }
}
