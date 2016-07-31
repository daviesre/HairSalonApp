using System.Collections.Generic;
using Nancy;
using Nancy.ViewEngines.Razor;

namespace HairSalon
{
  public class HomeModule : NancyModule
  {
    public HomeModule()
    {
      Get["/"] = _ => {
         List<Stylist> allStylists = Stylist.GetAll();
         return View["index.cshtml", allStylists];
       };

       Post["/stylist/new"] = _ => {
         Stylist newStylist = new Stylist(Request.Form["stylist-name"]);
         newStylist.Save();
         List<Stylist> allStylists = Stylist.GetAll();
         return View["index.cshtml", allStylists];
       };

       Get["/clients"] = _ => {
         List<Client> allClients = Client.GetAll();
         return View["clients.cshtml", allClients];
       };

       Post["/clients/{id}"] = parameters => {
         Client newClient = new Client(Request.Form["name"], Request.Form["stylist-id"]);
         newClient.Save();
         Dictionary<string, object> model = new Dictionary<string, object>();
         Stylist selectedStylist = Stylist.Find(parameters.id);
         List<Client> stylistClients = selectedStylist.GetClients();
         model.Add("stylist", selectedStylist);
         model.Add("clients", stylistClients);
         return View["clients.cshtml", model];
       };

       Get["/clients/{id}"] = parameters => {
         Dictionary<string, object> model = new Dictionary<string, object>();
         Stylist selectedStylist = Stylist.Find(parameters.id);
         List<Client> stylistClients = selectedStylist.GetClients();
         model.Add("stylist", selectedStylist);
         model.Add("clients", stylistClients);
         return View["clients.cshtml", model];
       };
    }
  }
}
