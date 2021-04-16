using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Project.Models
{
    public class Tickets
    {
        SqlConnection conn;
        public Tickets() { }
        public Tickets(SqlConnection conn)
        {
            this.conn = conn;
        }

        public bool bookTicket(dynamic ticket)
        {
            conn.Open();
            string query = string.Format("INSERT INTO Tickets VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}')", ticket.name, ticket.phone, ticket.source, ticket.destination, ticket.type, ticket.coach, ticket.date, ticket.time);
            SqlCommand cmd = new SqlCommand(query, conn);
            int res = cmd.ExecuteNonQuery();
            conn.Close();
            if (res > 0) return true;
            return false;
        }

        public List<Ticket> getAllTickets()
        {
            conn.Open();
            string query = string.Format("SELECT * FROM Tickets");
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataReader reader = cmd.ExecuteReader();
            List<Ticket> ticket = new List<Ticket>();
            Ticket aTicket = null;
            while (reader.Read())
            {
                aTicket = new Ticket();
                aTicket.Id = reader.GetInt32(reader.GetOrdinal("Id"));
                aTicket.Name = reader.GetString(reader.GetOrdinal("Name")).Trim();
                aTicket.Phone = reader.GetString(reader.GetOrdinal("Phone")).Trim();
                aTicket.Source = reader.GetString(reader.GetOrdinal("Source")).Trim();
                aTicket.Destination = reader.GetString(reader.GetOrdinal("Destination")).Trim();
                aTicket.Bustype = reader.GetString(reader.GetOrdinal("BusType")).Trim();
                aTicket.Coach = reader.GetString(reader.GetOrdinal("Coach")).Trim();
                aTicket.Date = reader.GetString(reader.GetOrdinal("Date")).Trim();
                aTicket.Time = reader.GetString(reader.GetOrdinal("Time")).Trim();
                ticket.Add(aTicket);
            }
            conn.Close();
            return ticket;
        }
    }
}
