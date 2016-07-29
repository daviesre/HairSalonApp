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
    public void GetAll_ClientEmptyAtFirst()
    {
     //Arrange, Act
     int result = Client.GetAll().Count;
     //Assert
     Assert.Equal(0, result);
    }

    [Fact]
    public void Equals_Equal_ReturnsTrueIfNamesAreTheSame()
    {
      //Arrange, Act
      Client newClient1 = new Client("Ms. Client");
      Client newClient2 = new Client("Ms. Client");
      //Assert
      Assert.Equal(newClient1, newClient2);
    }

    [Fact]
    public void Test_Save_SavesToDatabase()
    {
      //Arrange
      Client testClient = new Client("Ms. Client");
      //Act
      testClient.Save();
      List<Client> result = Client.GetAll();
      List<Client> testList = new List<Client>{testClient};
      //Assert
      Assert.Equal(testList, result);
    }

    [Fact]
    public void Test_Save_AssignsIdToObject()
    {
      //Arrange
      Client testClient = new Client("Ms. Client");
      //Act
      testClient.Save();
      Client savedClient = Client.GetAll()[0];

      int result = savedClient.GetId();
      int testId = testClient.GetId();
      //Assert
      Assert.Equal(testId, result);
    }

    [Fact]
    public void Test_Find_FindsTaskInDatabase()
    {
      //Arrange
      Client testClient = new Client("Ms. Client");
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
