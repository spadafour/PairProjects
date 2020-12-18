using CampgroundReservations.DAO;
using CampgroundReservations.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace CampgroundReservations.Tests.DAO
{
    [TestClass]
    public class SiteSqlDAOTests : BaseDAOTests
    {
        [TestMethod]
        public void GetSitesThatAllowRVs_Should_ReturnSites()
        {
            // Arrange
            SiteSqlDAO dao = new SiteSqlDAO(ConnectionString);

            // Act
            IList<Site> sites = dao.GetSitesThatAllowRVs(ParkId);

            // Assert
            Assert.AreEqual(2, sites.Count);
        }

        [TestMethod]
        public void GetCurrentlyAvailableSitesTest()
        {
            SiteSqlDAO dao = new SiteSqlDAO(ConnectionString);
            int result = dao.GetCurrentlyAvailableSites(ParkId).Count;
            Assert.AreEqual(2, result);
        }

        [TestMethod]
        public void GetAvailableSitesWithinDateRangeTest()
        {
            SiteSqlDAO dao = new SiteSqlDAO(ConnectionString);
            DateTime desiredFrom = DateTime.Now.AddDays(3);
            DateTime desiredTo = DateTime.Now.AddDays(5);
            List<Site> resultList = dao.GetAvailableSitesWithinDateRange(ParkId, desiredFrom, desiredTo);
            Assert.AreEqual(2, resultList.Count);
        }
    }
}
