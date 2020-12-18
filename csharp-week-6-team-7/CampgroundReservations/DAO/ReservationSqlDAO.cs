using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Net.Http.Headers;
using CampgroundReservations.Models;

namespace CampgroundReservations.DAO
{
    public class ReservationSqlDAO : IReservationDAO
    {
        private string connectionString;

        public ReservationSqlDAO(string dbConnectionString)
        {
            connectionString = dbConnectionString;
        }

        public int CreateReservation(int siteId, string name, DateTime fromDate, DateTime toDate)
        {
            int reservationId;
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string sqlText = $"insert into reservation (site_id, name, from_date, to_date) values(@siteId, '@name', @fromDate, @toDate);select scope_identity();";
                    SqlCommand command = new SqlCommand(sqlText, connection);
                    command.Parameters.AddWithValue("@siteId", siteId);
                    command.Parameters.AddWithValue("@name", name);
                    command.Parameters.AddWithValue("@fromDate", fromDate);
                    command.Parameters.AddWithValue("@toDate", toDate);
                    reservationId = Convert.ToInt32(command.ExecuteScalar());
                    return reservationId;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        private Reservation GetReservationFromReader(SqlDataReader reader)
        {
            Reservation reservation = new Reservation();
            reservation.ReservationId = Convert.ToInt32(reader["reservation_id"]);
            reservation.SiteId = Convert.ToInt32(reader["site_id"]);
            reservation.Name = Convert.ToString(reader["name"]);
            reservation.FromDate = Convert.ToDateTime(reader["from_date"]);
            reservation.ToDate = Convert.ToDateTime(reader["to_date"]);
            reservation.CreateDate = Convert.ToDateTime(reader["create_date"]);

            return reservation;
        }

        public List<Reservation> GetUpcomingReservations()
        {
            List<Reservation> upcomingReservations = new List<Reservation>();
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string sqlString = "select * from reservation where GETDATE() + 30 >= from_date and from_date >= GETDATE();";
                    SqlDataReader reader = new SqlCommand(sqlString, connection).ExecuteReader();
                    while (reader.Read())
                    {
                        upcomingReservations.Add(GetReservationFromReader(reader));
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return upcomingReservations;
        }
    }
}
