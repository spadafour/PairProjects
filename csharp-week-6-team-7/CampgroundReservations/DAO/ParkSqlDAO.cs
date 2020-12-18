using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using CampgroundReservations.Models;

namespace CampgroundReservations.DAO
{
    public class ParkSqlDAO : IParkDAO
    {
        private string connectionString;

        public ParkSqlDAO(string dbConnectionString)
        {
            connectionString = dbConnectionString;
        }

        public IList<Park> GetAllParks()
        {
            IList<Park> allParks = new List<Park>();
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string sqlString = "select * from park order by location;";
                    SqlCommand command = new SqlCommand(sqlString, connection);
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Park park = new Park
                        {
                            ParkId = Convert.ToInt32(reader["park_id"]),
                            Name = Convert.ToString(reader["name"]),
                            Location = Convert.ToString(reader["location"]),
                            EstablishDate = Convert.ToDateTime(reader["establish_date"]),
                            Area = Convert.ToInt32(reader["area"]),
                            Visitors = Convert.ToInt32(reader["visitors"]),
                            Description = Convert.ToString(reader["description"])
                        };
                        allParks.Add(park);
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return allParks;
        }

        private Park GetParkFromReader(SqlDataReader reader)
        {
            Park park = new Park();
            park.ParkId = Convert.ToInt32(reader["park_id"]);
            park.Name = Convert.ToString(reader["name"]);
            park.Location = Convert.ToString(reader["location"]);
            park.EstablishDate = Convert.ToDateTime(reader["establish_date"]);
            park.Area = Convert.ToInt32(reader["area"]);
            park.Visitors = Convert.ToInt32(reader["visitors"]);
            park.Description = Convert.ToString(reader["description"]);

            return park;
        }
    }
}
