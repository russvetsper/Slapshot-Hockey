using System.Collections.Generic;
using System.Data.SqlClient;
using System;

namespace Slapshot.Objects
{
  public class Player
  {
    private int _id;
    private string _firstName;
    private string _lastName;
    private int _rating;
//CONSTRUCTOR
    public Player(string first, string last, int rating, int id=0)
    {
      _id = id;
      _firstName = first;
      _lastName = last;
      _rating = rating;
    }
//GETTERS
    public int GetId()
    {
      return _id;
    }

    public string GetFirstName()
    {
      return _firstName;
    }

    public string GetLastName()
    {
      return _lastName;
    }

    public int GetRating()
    {
      return _rating;
    }
//SETTERS
    public void SetFirstName(string newName)
    {
      _firstName = newName;
    }

    public void SetLastName(string newName)
    {
      _lastName = newName;
    }

    public void SetRating(int newRating)
    {
      _rating = newRating;
    }
//SAVE & GetAll

    //Not done yet
    public override bool Equals(System.Object otherPLayer)
    {
      if (!(otherPLayer is Player))
      {
        return false;
      }
      else
      {
        Player newPlayer = (Player) otherPLayer;
        return this.GetFirstName().Equals(newPlayer.GetFirstName());
      }
    }

          public override int GetHashCode()
          {
            return this.GetFirstName().GetHashCode();
          }

          public static List<Player> GetAll()
            {
              List<Player> allPlayers = new List<Player>{};

              SqlConnection conn = DB.Connection();
              conn.Open();
              SqlCommand cmd = new SqlCommand("SELECT * FROM players;", conn);
              SqlDataReader rdr  = cmd.ExecuteReader();

              while(rdr.Read())
              {
                int teamId = rdr.GetInt32(0);
                string firstName = rdr.GetString(1);
                string lastName = rdr.GetString(2);
                int rating= rdr.GetInt32(3);
                Player newPlayer = new Player(firstName, lastName, rating, teamId);
                allPlayers.Add(newPlayer);
              }
              if (rdr != null)
              {
                rdr.Close();
              }
              if (conn != null)
              {
                conn.Close();
              }
              return allPlayers;
            }
            //
            public void Save()
            {
              SqlConnection conn = DB.Connection();
              conn.Open();

              SqlCommand cmd = new SqlCommand("INSERT INTO players(firstName,lastName,rating)OUTPUT INSERTED.id VALUES (@firstName,@lastName,@rating);", conn );
              SqlParameter firstNameParameter = new SqlParameter();
              firstNameParameter.ParameterName = "@firstName";
              firstNameParameter.Value = this.GetFirstName();
              cmd.Parameters.Add(firstNameParameter);

              SqlParameter lastNameParameter = new SqlParameter();
              lastNameParameter.ParameterName = "@lastName";
              lastNameParameter.Value = this.GetLastName();
              cmd.Parameters.Add(lastNameParameter);
              SqlDataReader rdr = cmd.ExecuteReader();

              // SqlCommand ratingParameter = new SqlParameter();
              // ratingParameter.ParameterName = "@rating";
              // ratingParameter.Value = this.GetRating();
              // cmd.Parameters.Add(ratingParameter);
              // SqlDataReader rdr = cmd.ExecuteReader();

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


//DeleteAll
    public static void DeleteAll()
    {
      SqlConnection conn = DB.Connection();
      conn.Open();
      SqlCommand cmd = new SqlCommand ("DELETE FROM players;",conn);
      cmd.ExecuteNonQuery();
      conn.Close();

    }

  }
}
