using Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project.Controllers
{
    class TicketsController
    {
        public static Database db = new Database();
        public static bool boolTicket(dynamic ticket)
        {
            if (ticket.name.Length == 0 || ticket.phone.Length == 0 || ticket.source.Equals("Source") || ticket.destination.Equals("To") ||
                ticket.coach.Equals("Coach") || ticket.type.Length == 0 || ticket.time.Equals("Time") || ticket.author.Length==0 || ticket.seat.Length==0)
            { 
                MessageBox.Show("Fill all the required fields");
                return false;
            }

            //Customer Adding
            var hasCus = CustomerController.searchCustomer(ticket.phone);
            if (hasCus == null) { bool customeradd = CustomerController.addCustomer(ticket); }

            //Coach Reservation
            var reservation = new
            {
                ticket.coach,
                ticket.source,
                ticket.destination,
                ticket.date,
                ticket.time,
                seats = ticket.booked,
                booked = ticket.booked.Split(',').Length,
                available = 40 - ticket.booked.Split(',').Length
            };
            var hasCoach = ReservationController.getSingleCoachReservation(reservation);
            if (hasCoach == null) { bool reserve = ReservationController.addCoachReservation(reservation); }
            else { bool reserve = ReservationController.updateCoachReservation(reservation); }

            return db.Tickets.bookTicket(ticket);
        }
        public static List<Ticket> getAllTickets()
        {
            return db.Tickets.getAllTickets();
        }
        public static bool cancelTicket(int ticketId)
        {
            if (ticketId == 0)
            {
                MessageBox.Show("Select a ticket first");
                return false;
            }
            return db.Tickets.cancelTicket(ticketId);
        }
        public static bool updateTicket(dynamic ticket)
        {
            if (ticket.id == 0)
            {
                MessageBox.Show("Select a ticket first");
                return false;
            }
            if (ticket.name.Length == 0 || ticket.phone.Length == 0 || ticket.source.Equals("Source") || ticket.destination.Equals("To") ||
                ticket.coach.Equals("Coach") || ticket.type.Length == 0 || ticket.time.Equals("Time") || ticket.author.Length == 0 || ticket.seat.Length == 0)
            {
                MessageBox.Show("Fill all the required fields");
                return false;
            }

            return db.Tickets.updateTicket(ticket);
        }
    }
}
