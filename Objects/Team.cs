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

        public static List<Team> GetAll()
          {
            List<Team> allTeams = new List<Team>{};

            SqlConnection conn = DB.Connection();
            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM teams;", conn);
            SqlDataReader rdr  = cmd.ExecuteReader();

            while(rdr.Read())
            {
              int teamId = rdr.GetInt32(0);
              string teamName = rdr.GetString(1);
              int team_id= rdr.GetInt32(2);
              Team newTeam = new Team(teamName, team_id, teamId);
              allTeams.Add(newTeam);
            }
            if (rdr != null)
            {
              rdr.Close();
            }
            if (conn != null)
            {
              conn.Close();
            }
            return allTeams;
          }



        public void Save()
        {
          SqlConnection conn = DB.Connection();
          conn.Open();

          SqlCommand cmd = new SqlCommand("INSERT INTO teams(name,team_id)OUTPUT INSERTED.id VALUES (@teamName,@team_id);", conn );
          SqlParameter nameParameter = new SqlParameter();
          nameParameter.ParameterName = "@teamName";
          nameParameter.Value = this.GetTeamName();
          cmd.Parameters.Add(nameParameter);

          SqlParameter team_idParameter = new SqlParameter();
          team_idParameter.ParameterName = "@team_id";
          team_idParameter.Value = this.GetTeam_Id();
          cmd.Parameters.Add(team_idParameter);
          SqlDataReader rdr = cmd.ExecuteReader();

          while(rdr.Read())
          {
            this._id = rdr.GetInt32(0);
          }
          if (rdr !=null)
          {
            rdr.Close();
          }
          if (conn !=null)
          {
            conn.Close();
          }
        }

       //
        public static Team Find(int id)
       {
         SqlConnection conn = DB.Connection();
         conn.Open();

         SqlCommand cmd = new SqlCommand("SELECT * FROM teams WHERE id = @teamId;", conn);
         SqlParameter teamIdParameter = new SqlParameter();
         teamIdParameter.ParameterName =  "@teamId";
         teamIdParameter.Value = id.ToString();
         cmd.Parameters.Add(teamIdParameter);
         SqlDataReader rdr = cmd.ExecuteReader();

         int findTeamId = 0;
         string findTeamName = null;
         int findTeam_id = 0;
         while(rdr.Read())
         {
           findTeamId = rdr.GetInt32(0);
           findTeamName = rdr.GetString(1);
           findTeam_id = rdr.GetInt32(2);
         }
         Team findTeam = new Team(findTeamName,findTeam_id,findTeamId);

         if (rdr != null)
         {
           rdr.Close();
         }
         if (conn != null)
         {
           conn.Close();
         }
         return findTeam;

       }



}
}
