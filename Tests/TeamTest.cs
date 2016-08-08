using System.Collections.Generic;
using Xunit;
using System;


namespace Slapshot.Objects
{
  public class TeamTest
  {


    public TeamTest()
   {
     DBConfiguration.ConnectionString = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=slapshot_hockey_test;Integrated Security=SSPI;";
   }


   [Fact]
   public void Test1_GetTeamName()
   {

     Team newTeam = new Team("The Goons",1);

     string result = newTeam.GetTeamName();

     Assert.Equal("The Goons", result);
   }


   [Fact]
   public void Test2_GetTeamID()
   {
     // arrange
    Team newTeam = new Team("Leafs",1);
     // act
     int result = newTeam.GetTeam_Id();

     Assert.Equal(1, result);

   }


 }
}
