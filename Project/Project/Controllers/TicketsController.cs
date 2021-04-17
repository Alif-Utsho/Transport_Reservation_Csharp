﻿using Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Controllers
{
    class TicketsController
    {
        public static Database db = new Database();
        public static bool boolTicket(dynamic ticketInfo)
        {
            return db.Tickets.bookTicket(ticketInfo);
        }
        public static List<Ticket> getAllTickets()
        {
            return db.Tickets.getAllTickets();
        }
        public static bool cancelTicket(int ticketId)
        {
            return db.Tickets.cancelTicket(ticketId);
        }
        public static bool updateTicket(dynamic ticket)
        {
            return db.Tickets.updateTicket(ticket);
        }
    }
}
