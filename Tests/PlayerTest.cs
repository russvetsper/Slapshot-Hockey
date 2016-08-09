using System.Collections.Generic;
using Xunit;
using System;


namespace Slapshot.Objects
{
  public class PlayerTest : IDisposable
  {
    public void Dispose()
    {
      Player.DeleteAll();
    }
  }
}
