using System.Collections.Generic;
using Xunit;
using System;


namespace Slapshot.Objects
{
  public class UserTest
  {

    public UserTest()
   {
     DBConfiguration.ConnectionString = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=slapshot_hockey_test;Integrated Security=SSPI;";
   }



    [Fact]
    public void Test1_UserGetName()
    {
      // arrange
      User newUser = new User("Russ", "password");
      // act
      string result = newUser.GetName();

      Assert.Equal("Russ", result);
    }


    }
  }
