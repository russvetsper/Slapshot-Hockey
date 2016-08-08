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



    }
  }
