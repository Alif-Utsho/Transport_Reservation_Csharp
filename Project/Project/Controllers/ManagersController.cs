using Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project.Controllers
{
    class ManagersController
    {
        static Database db = new Database();

        public static bool AddManager(dynamic manager)
        {
            if (manager.name.Length == 0 || manager.username.Length == 0 || manager.password.Length == 0)
            {
                MessageBox.Show("Fill all the required field");
                return false;
            }
            var has = ManagersController.getSingleManager(manager.username);
            if (has != null)
            {
                MessageBox.Show("Username Already used");
                return false;
            }
            //bool result = ManagersController.AddManager(manager);
            bool result=db.Managers.addManager(manager);
            if (result)
            {
                //AdminDashboard.reloadManager();
                MessageBox.Show("Manager Added");
                return true;
            }
            else
            {
                MessageBox.Show("Could not Add");
                return false;
            }
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
