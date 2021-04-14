using Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Controllers
{
    public class AuthenticateController
    {
        static Database db = new Database();

        public static AuthModel AuthController(string name, string password, string role)
        {
            return db.Authentication.Authenticate(name, password, role);
        }
    }
}
