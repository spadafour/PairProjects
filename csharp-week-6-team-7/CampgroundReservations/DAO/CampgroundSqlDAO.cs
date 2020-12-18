using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using CampgroundReservations.Models;

namespace CampgroundReservations.DAO
{
    public class CampgroundSqlDAO : ICampgroundDAO
    {
        private string connectionString;

        public CampgroundSqlDAO(string dbConnectionString)
        {
            connectionString = dbConnectionString;
        }

        public IList<Campground> GetCampgroundsByParkId(int parkId)
        {
            IList<Campground> allCampgrounds = new List<Campground>();
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string sqlString = "select * from campground;";
                    SqlCommand command = new SqlCommand(sqlString, connection);
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Campground campground = new Campground
                        {
                            CampgroundId = Convert.ToInt32(reader["campground_id"]),
                            ParkId = Convert.ToInt32(reader["park_id"]),
                            Name = Convert.ToString(reader["name"]),
                            OpenFromMonth = Convert.ToInt32(reader["open_from_mm"]),
                            OpenToMonth = Convert.ToInt32(reader["open_to_mm"]),
                            DailyFee = Convert.ToDouble(reader["daily_fee"])
                        };
                        allCampgrounds.Add(campground);
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return allCampgrounds;
        }

        private Campground GetCampgroundFromReader(SqlDataReader reader)
        {
            Campground campground = new Campground();
            campground.CampgroundId = Convert.ToInt32(reader["campground_id"]);
            campground.ParkId = Convert.ToInt32(reader["park_id"]);
            campground.Name = Convert.ToString(reader["name"]);
            campground.OpenFromMonth = Convert.ToInt32(reader["open_from_mm"]);
            campground.OpenToMonth = Convert.ToInt32(reader["open_to_mm"]);
            campground.DailyFee = Convert.ToDouble(reader["daily_fee"]);

            return campground;
        }
    }
}
