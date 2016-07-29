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
    public void GetAll_DatabaseEmptyAtFirst()
    {
     //Arrange, Act
     int result = Stylist.GetAll().Count;
     //Assert
     Assert.Equal(0, result);
    }

    [Fact]
    public void Equals_Equal_ReturnsTrueIfDescriptionsAreTheSame()
    {
      //Arrange, Act
      Stylist newStylist1 = new Stylist("Nancy Razor");
      Stylist newStylist2 = new Stylist("Nancy Razor");
      //Assert
      Assert.Equal(newStylist1, newStylist2);
    }

    [Fact]
    public void Test_Save_SavesToDatabase()
    {
      //Arrange
      Stylist testStylist = new Stylist("Nancy Razor");
      //Act
      testStylist.Save();
      List<Stylist> result = Stylist.GetAll();
      List<Stylist> testList = new List<Stylist>{testStylist};
      //Assert
      Assert.Equal(testList, result);
    }

    [Fact]
    public void Test_Save_AssignsIdToObject()
    {
      //Arrange
      Stylist testStylist = new Stylist("Nancy Razor");
      //Act
      testStylist.Save();
      Stylist savedStylist = Stylist.GetAll()[1];

      int result = savedStylist.GetId();
      int testId = testStylist.GetId();
      //Assert
      Assert.Equal(testId, result);
    }

    public void Dispose()
    {
      Stylist.DeleteAll();
    }
  }
}
