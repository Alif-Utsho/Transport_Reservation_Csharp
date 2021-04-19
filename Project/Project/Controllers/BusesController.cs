using Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Controllers
{
    public class BusesController
    {
        public static Database db = new Database();
        public static List<Bus> getAllBus()
        {
            return db.Buses.getAllBus();
        }
        public static bool addBus(dynamic bus)
        {
            return db.Buses.addBus(bus);
        }
        public static Bus searchBus(string coach)
        {
            return db.Buses.SearchBus(coach);
        }
        public static bool updateBus(dynamic bus)
        {
            return db.Buses.updateBus(bus);
        }
        public static bool deleteBus(int id)
        {
            return db.Buses.deleteBus(id);
        }
    }
}
