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

    [Fact]
    public void Test2_GetPassword()
    {
      // arrange
      User newUser = new User("Russ", "password");
      // act
      string result = newUser.GetPassword();

      Assert.Equal("password", result);
    }

    [Fact]
   public void Test3_SetName()
   {
     // arrange
     User newUser = new User("Russ", "password");
     newUser.SetName("John");
     // act
     string result = newUser.GetName();

     Assert.Equal("John", result);
   }

   [Fact]
   public void Test4_SaveUser()
   {
     //Arrange
   User newUser = new User("Russ", "password");
   newUser.Save();
    //ACt
   List<User> allUsers = User.GetAll();
    //assert
   Assert.Equal(newUser, allUsers[0]);
   }

   [Fact]
    public void Test5_FindId()
    {
      User newUser = new User ("russ","password");
      newUser.Save();

      User findUser = User.Find(newUser.GetId());

      Assert.Equal(findUser, newUser);
    }

    [Fact]
   public void Test6_UpdateUser()
   {
     User newUser = new User("Rouz","password");
     newUser.Save();
     newUser.Update("mike");
     string result = newUser.GetName();

     Assert.Equal("mike", result);
   }




    }
  }
