using Xunit;
using System.Collections.Generic;
using System;
using System.Data;
using System.Data.SqlClient;

namespace HairSalon
{
    public class StylistTest : IDisposable
    {
        public StylistTest()
        {
            DBConfiguration.ConnectionString = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=hair_salon_test;Integrated Security=SSPI;";
        }

        [Fact]
        public void GetAll_StylistEmptyAtFirst_true()
        {
            int result = Stylist.GetAll().Count;

            Assert.Equal(0, result);
        }


        [Fact]
        public void Equals_ReturnsTrueForSameName_true()
        {
            //Arrange, Act
            Stylist firstStylist = new Stylist("Henry");
            Stylist secondStylist = new Stylist("Henry");

            //Assert
            Assert.Equal(firstStylist, secondStylist);
        }

        [Fact]
        public void Save_TestIfTypeSaved_true()
        {
            Stylist testStylist = new Stylist("Henry");
            testStylist.Save();

            List<Stylist> result = Stylist.GetAll();
            List<Stylist> testList = new List<Stylist>{testStylist};

            Assert.Equal(testList, result);
        }

        [Fact]
        public void GetAll_ReturnListOfAllStylists_true()
        {
            Stylist firstStylist = new Stylist("Henry");
            Stylist secondStylist = new Stylist("Sally");
            firstStylist.Save();
            secondStylist.Save();

            List<Stylist> testStylistList = new List<Stylist> {firstStylist, secondStylist};
            List<Stylist> resultStylistList = Stylist.GetAll();
            Assert.Equal(testStylistList, resultStylistList);
        }

        [Fact]
        public void GetId_GetsIdForStylist_true()
        {
            //Arrange
            Stylist testStylist = new Stylist("Henry");
            testStylist.Save();

            //Act
            Stylist savedStylist = Stylist.GetAll()[0];

            int result = savedStylist.GetId();
            int testId = testStylist.GetId();

            //Assert
            Assert.Equal(testId, result);
        }

        [Fact]
        public void Find_FindsStylistInDatabase_true()
        {
            //Arrange
            Stylist testStylist = new Stylist("Sally");
            testStylist.Save();

            //Act
            Stylist foundStylist = Stylist.Find(testStylist.GetId());

            //Assert
            Assert.Equal(testStylist, foundStylist);
        }
        public void Dispose()
        {
            // Client.DeleteAll();
            Stylist.DeleteAll();
        }
    }
}
