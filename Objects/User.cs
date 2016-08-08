using System.Collections.Generic;
using System.Data.SqlClient;
using System;

namespace Slapshot.Objects
{
  public class User
  {
    private string _name;
    private string _password;
    private int _id;

    public User(string name, string password, int id=0)
    {
      _name = name;
      _password = password;
      _id = id;
    }

    public string GetName()
    {
      return _name;
    }

    public string GetPassword()
    {
      return _password;
    }

    public int GetId()
    {
      return _id;
    }

    public void SetName(string newName)
    {
      _name = newName;
    }

    public override bool Equals(System.Object otherUser)
   {
     if (!(otherUser is User))
     {
       return false;
     }
     else
     {
       User newUser = (User) otherUser;
       return this.GetName().Equals(newUser.GetName());
     }
   }

   public void Save()
   {
     SqlConnection conn = DB.Connection();
     conn.Open();

     SqlCommand cmd = new SqlCommand("INSERT INTO users(name,password)OUTPUT INSERTED.id VALUES (@userName,@userPassword);", conn );
     SqlParameter nameParameter = new SqlParameter();
     nameParameter.ParameterName = "@userName";
     nameParameter.Value = this.GetName();
     cmd.Parameters.Add(nameParameter);

     SqlParameter passwordParameter = new SqlParameter();
     passwordParameter.ParameterName = "@userPassword";
     passwordParameter.Value = this.GetPassword();
     cmd.Parameters.Add(passwordParameter);
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

   public static List<User> GetAll()
    {
      List<User> allUsers = new List<User>{};

      SqlConnection conn = DB.Connection();
      conn.Open();
      SqlCommand cmd = new SqlCommand("SELECT * FROM users;", conn);
      SqlDataReader rdr  = cmd.ExecuteReader();

      while(rdr.Read())
      {
        int userId = rdr.GetInt32(0);
        string userName = rdr.GetString(1);
        string userPassword = rdr.GetString(2);
        User newUser = new User(userName, userPassword, userId);
        allUsers.Add(newUser);
      }
      if (rdr != null)
      {
        rdr.Close();
      }
      if (conn != null)
      {
        conn.Close();
      }
      return allUsers;
    }

    public static User Find(int id)
   {
     SqlConnection conn = DB.Connection();
     conn.Open();

     SqlCommand cmd = new SqlCommand("SELECT * FROM users WHERE id = @userId;", conn);
     SqlParameter userIdParameter = new SqlParameter();
     userIdParameter.ParameterName =  "@userId";
     userIdParameter.Value = id.ToString();
     cmd.Parameters.Add(userIdParameter);
     SqlDataReader rdr = cmd.ExecuteReader();

     int findUserId = 0;
     string findUserName = null;
     string findUserPassword = null;
     while(rdr.Read())
     {
       findUserId = rdr.GetInt32(0);
       findUserName = rdr.GetString(1);
       findUserPassword = rdr.GetString(2);
     }
     User findUser = new User(findUserName,findUserPassword,findUserId);

     if (rdr != null)
     {
       rdr.Close();
     }
     if (conn != null)
     {
       conn.Close();
     }
     return findUser;

   }



    }
  }
