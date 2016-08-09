using System.Collections.Generic;
using Xunit;
using System;


namespace Slapshot.Objects
{
  public class TeamTest : IDisposable
  {
    public void Dispose()
    {
      Player.DeleteAll();
    }
  }
}
