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
          List<User> AllUsers = User.GetAll();
          return View["index.cshtml", AllUsers];
      };


      Get["/users"] = _ => {
        List<User> allUsers = User.GetAll();
        return View["users.cshtml", allUsers];
      };


      Get["/users/new"] = _ => {

        return View["user_form.cshtml"];

      };

      Post["/users/new"] = _ => {
        User newUser = new User(Request.Form["user-name"], Request.Form["user-password"]);
        newUser.Save();
        List<User> allUsers= User.GetAll();
        return View["success.cshtml"];
      };


      Get["/users/{id}"] = parameters => {
        Dictionary<string, object> model = new Dictionary<string, object>();
        var SelectedUser = User.Find(parameters.id);
        var UserTeams = SelectedUser.GetTeams();
        model.Add("user", SelectedUser);
        model.Add("teams", UserTeams);
        return View["user.cshtml", model];
      };

      Get["user/edit/{id}"] = parameters => {
        User SelectedUser = User.Find(parameters.id);
        return View["user_edit.cshtml", SelectedUser];
      };

      Patch["user/edit/{id}"] = parameters => {
        User SelectedUser = User.Find(parameters.id);
        SelectedUser.Update(Request.Form["user-name"]);
        return View["success.cshtml"];
      };


      Get["/user/delete/{id}"] = parameters => {
        User SelectedUser = User.Find(parameters.id);
        return View["user_delete.cshtml", SelectedUser];
      };

      Post["/user/delete/{id}"] = parameters => {
        User SelectedUser = User.Find(parameters.id);
        SelectedUser.Delete();
        return View["success.cshtml"];
      };

      Get["/teams"] = _ => {
        List<Team> AllTeams = Team.GetAll();
        return View["teams.cshtml", AllTeams];
      };


      Get["/teams/new"] = _ => {
        List<User> AllUsers = User.GetAll();
        return View["teams_form.cshtml", AllUsers];
      };
      Post["/teams/new"] = _ => {
        if(!string.IsNullOrEmpty(Request.Form["user-id"]))
        {
          Team newTeam = new Team(Request.Form["team-name"], Request.Form["user-id"]);
          newTeam.Save();
        }
        return View["success.cshtml"];
      };

      Post["/teams/delete"] = _ => {
        Team.DeleteAll();
        return View["cleared.cshtml"];
      };

      Post["/users/clear"] = _ => {
        User.DeleteAll();
        return View["cleared.cshtml"];
      };




    }
  }
}
