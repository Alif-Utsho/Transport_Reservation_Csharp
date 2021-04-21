﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Project.Models
{
    public class Database
    {
        public Authentication Authentication { get; set; }
        public Managers Managers;
        public Sellers Sellers;
        public Tickets Tickets;
        public Customers Customers;
        public Buses Buses;
        public Admins Admins;
        public Database()
        {
            string connectionString = @"Server=LAPTOP-LSE8ACET\SQL_SERVER;Database=TransportReservation;User Id=sa;Password=12345;";
            SqlConnection conn = new SqlConnection(connectionString);

            Authentication = new Authentication(conn);
            Managers = new Managers(conn);
            Sellers = new Sellers(conn);
            Tickets = new Tickets(conn);
            Customers = new Customers(conn);
            Buses = new Buses(conn);
            Admins = new Admins(conn);
        }
    }
}
