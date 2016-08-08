using System.Collections.Generic;
using System.Data.SqlClient;
using System;

namespace Slapshot.Objects
{
public class Team
{
  private string _name;
  private int _team_id;
  private int _id;

  public Team(string Name, int team_id, int id=0)
  {
    _name = Name;
    _team_id = team_id;
    _id = id;
  }

  public string GetTeamName()
  {
    return _name;
  }

  public int GetTeam_Id()
  {
    return _team_id;
  }

  public int GetId()
  {
    return _id;
  }

  public void SetName(string newTeamName)
  {
    _name = newTeamName;
  }


  public override bool Equals(System.Object otherTeam)
  {
    if (!(otherTeam is Team))
    {
      return false;
    }
    else
    {
      Team newTeam = (Team) otherTeam;
      return this.GetTeamName().Equals(newTeam.GetTeamName());
    }
  }

        public override int GetHashCode()
        {
          return this.GetTeamName().GetHashCode();
        }

}
}
