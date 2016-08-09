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

  }
}
