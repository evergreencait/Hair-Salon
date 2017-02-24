using Xunit;
using System.Collections.Generic;
using System;
using System.Data;
using System.Data.SqlClient;

namespace HairSalon
{
    public class ClientTest : IDisposable
    {
        public ClientTest()
        {
            DBConfiguration.ConnectionString = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=hair_salon_test;Integrated Security=SSPI;";
        }

        [Fact]
        public void GetAll_ClientsEmptyAtFirst_true()
        {
            int result = Client.GetAll().Count;

            Assert.Equal(0, result);
        }

        [Fact]
        public void Equals_ReturnsTrueForSameName_true()
        {
            //Arrange, Act
            Client firstClient = new Client("Gwen", 1);
            Client secondClient = new Client("Gwen", 1);

            //Assert
            Assert.Equal(firstClient, secondClient);
        }

        public void Save_TestIfClientSaved_true()
        {
            Client testClient = new Client("Gwen", 1);
            testClient.Save();

            List<Client> allClientList = new List<Client>{testClient};

            List<Client> result = Client.GetAll();
            List<Client> testList = new List<Client>{testClient};


            Assert.Equal(testList, result);
        }

        [Fact]
        public void UpdateProperties_UpdatePropertiesInDatabase_true()
        {
            //Arrange
            string name = "Gwen";
            Client testClient = new Client(name, 2);
            testClient.Save();
            string newName = "Sally";

            //Act
            testClient.UpdateName(newName);

            string result = testClient.GetName();

            //Assert
            Assert.Equal(newName, result);
        }

        [Fact]
        public void Find_FindsClientInDatabase_true()
        {
            //Arrange
            Client testClient = new Client("Harry", 1);
            testClient.Save();

            //Act
            Client foundClient = Client.Find(testClient.GetId());

            //Assert
            Assert.Equal(testClient, foundClient);
        }



        public void Dispose()
        {
            Client.DeleteAll();
        }

    }
}
