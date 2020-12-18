using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Dynamic;
using CampgroundReservations.Models;

namespace CampgroundReservations.DAO
{
    public class SiteSqlDAO : ISiteDAO
    {
        private string connectionString;

        public SiteSqlDAO(string dbConnectionString)
        {
            connectionString = dbConnectionString;
        }

        public IList<Site> GetSitesThatAllowRVs(int parkId)
        {
            IList<Site> allSites = new List<Site>();
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string sqlString = "select * from site join campground on campground.campground_id = site.campground_id where max_rv_length > 0 and park_id = @parkId;";
                    SqlCommand command = new SqlCommand(sqlString, connection);
                    command.Parameters.AddWithValue("@parkId", parkId);
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Site site = new Site
                        {
                            CampgroundId = Convert.ToInt32(reader["campground_id"]),
                            SiteId = Convert.ToInt32(reader["site_id"]),
                            SiteNumber = Convert.ToInt32(reader["site_number"]),
                            MaxOccupancy = Convert.ToInt32(reader["max_occupancy"]),
                            Accessible = Convert.ToBoolean(reader["accessible"]),
                            MaxRVLength = Convert.ToInt32(reader["max_rv_length"]),
                            Utilities = Convert.ToBoolean(reader["utilities"])
                        };
                        allSites.Add(site);
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return allSites;
        }

        private Site GetSiteFromReader(SqlDataReader reader)
        {
            Site site = new Site();
            site.SiteId = Convert.ToInt32(reader["site_id"]);
            site.CampgroundId = Convert.ToInt32(reader["campground_id"]);
            site.SiteNumber = Convert.ToInt32(reader["site_number"]);
            site.MaxOccupancy = Convert.ToInt32(reader["max_occupancy"]);
            site.Accessible = Convert.ToBoolean(reader["accessible"]);
            site.MaxRVLength = Convert.ToInt32(reader["max_rv_length"]);
            site.Utilities = Convert.ToBoolean(reader["utilities"]);

            return site;
        }

        public List<Site> GetCurrentlyAvailableSites(int parkId)
        {
            List<Site> availableSites = new List<Site>();
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string sqlText = "select * from site join campground on campground.campground_id = site.campground_id where park_id = @parkId and site.site_id not in (select site_id from reservation where from_date <= GETDATE() and to_date >= GETDATE());";
                    SqlCommand command = new SqlCommand(sqlText, connection);
                    command.Parameters.AddWithValue("@parkId", parkId);
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        availableSites.Add(GetSiteFromReader(reader));
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return availableSites;
        }

        public List<Site> GetAvailableSitesWithinDateRange(int parkId, DateTime desiredFrom, DateTime desiredTo)
        {
            List<Site> availableSites = new List<Site>();
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string sqlText = "select * from site join campground on campground.campground_id = site.campground_id where park_id = @parkId and site.site_id not in (select reservation.site_id from reservation where(@desiredFrom > from_date and @desiredFrom < to_date) or(@desiredFrom < from_date and @desiredTo > to_date) or(@desiredTo > from_date and @desiredTo < to_date));";
                    SqlCommand command = new SqlCommand(sqlText, connection);
                    command.Parameters.AddWithValue("@parkId", parkId);
                    command.Parameters.AddWithValue("@desiredFrom", desiredFrom);
                    command.Parameters.AddWithValue("@desiredTo", desiredTo);
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        availableSites.Add(GetSiteFromReader(reader));
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return availableSites;
        }
    }
}
