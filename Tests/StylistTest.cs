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

    public void Dispose()
    {
      Stylist.DeleteAll();
    }
  }
}
