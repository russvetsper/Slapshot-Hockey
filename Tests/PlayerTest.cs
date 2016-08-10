using System.Collections.Generic;
using Xunit;
using System;


namespace Slapshot.Objects
{
  public class PlayerTest : IDisposable
  {
    public void Dispose()
    {
      Player.DeleteAll();
    }

    public PlayerTest()
   {
     DBConfiguration.ConnectionString = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=slapshot_hockey_test;Integrated Security=SSPI;";
   }


   [Fact]
   public void Test1_GetPlayerName()
   {

     Player newPlayer = new Player("Wayne","Gretzky",1);

     string result = newPlayer.GetFirstName();

     Assert.Equal("Wayne", result);
   }

   [Fact]
   public void Test2_GetPlayerID()
   {
     // arrange
    Player newPlayer = new Player("Wayne","Gretzky",1,1);
     // act
     int result = newPlayer.GetId();

     Assert.Equal(1, result);

   }

   [Fact]
   public void Test3_SetFirstName()
   {

     Player newPlayer = new Player("Wayne" ,"Gretzky" , 1);
     newPlayer.SetFirstName("john");

     string result = newPlayer.GetFirstName();

     Assert.Equal("john", result);
   }



   [Fact]
   public void Test3_SetLastName()
   {

     Player newPlayer = new Player("Felix" ,"potvin" , 1);
     newPlayer.SetFirstName("Wayne");

     string result = newPlayer.GetFirstName();

     Assert.Equal("Wayne", result);
   }


   [Fact]
   public void Test4_SavesToDatabase()
   {

   Player newPlayer = new Player("Doug", "Gilmour");
   newPlayer.Save();

   List<Player> result = Player.GetAll();
   List<Player> newPlayer = new List<Player>{newPlayer};

   Assert.Equal(newPlayer, result);
   }

  }
}
