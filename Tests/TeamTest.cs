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

 }
}
