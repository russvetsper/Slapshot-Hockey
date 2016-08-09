using System.Collections.Generic;
using Nancy;
using Nancy.ViewEngines.Razor;

namespace Slapshot.Objects
{
  public class HomeModule : NancyModule
  {
    public HomeModule()
    {
      Get["/"] = _ => {
        return View["index.cshtml"];
      };

      Get["/users"] = _ => {
        List<User> allUsers = User.GetAll();
        return View["users.cshtml", allUsers];
      };



    }
  }
}
