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

    public string GetNameAgain()
    {
      return _name;
    }

    public string GetDoe()
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


    }
  }
