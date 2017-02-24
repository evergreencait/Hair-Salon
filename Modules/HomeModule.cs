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
                List<Stylist> AllStylists = Stylist.GetAll();
                return View["index.cshtml", AllStylists];
            };

            Get["/clients"] = _ => {
                List<Client> AllClients = Client.GetAll();
                return View["clients.cshtml", AllClients];
            };

            Get["/stylists"] = _ => {
                List<Stylist> AllStylists = Stylist.GetAll();
                return View["stylists.cshtml", AllStylists];
            };

            Get["/stylists/new"] = _ => {
                return View["stylists_form.cshtml"];
            };
            Post["/stylists/new"] = _ => {
                Stylist newStylist = new Stylist(Request.Form["stylist-name"]);
                newStylist.Save();
                return View["success.cshtml"];
            };

            Get["/clients/new"] = _ => {
                List<Stylist> AllStylists = Stylist.GetAll();
                return View["clients_form.cshtml", AllStylists];
            };

            Post["/clients/new"] = _ => {
                Client newClient = new Client(Request.Form["client-name"], Request.Form["stylist-id"]);
                newClient.Save();
                return View["success.cshtml"];
            };

            Post["/clients/delete"] = _ => {
                Client.DeleteAll();
                return View["cleared.cshtml"];
            };

            Get["/stylists/{id}"] = parameters => {
                Dictionary<string, object> model = new Dictionary<string, object>();
                var SelectedStylist = Stylist.Find(parameters.id);
                var StylistClients = SelectedStylist.GetClients();
                model.Add("stylist", SelectedStylist);
                model.Add("clients", StylistClients);
                return View["stylist.cshtml", model];
            };

            Get["/client/{id}"] = parameters => {
                Client SelectedClient = Client.Find(parameters.id);
                return View["client.cshtml", SelectedClient];
            };

            Get["client/edit/{id}"] = parameters => {
                Client SelectedClient = Client.Find(parameters.id);
                return View["update_client.cshtml", SelectedClient];
            };

            Patch["client/edit/{id}"] = parameters => {
                Client SelectedClient = Client.Find(parameters.id);
                SelectedClient.UpdateName(Request.Form["client-name"]);
                return View["client_updated.cshtml", SelectedClient];
            };


            Delete["client/delete/{id}"] = parameters => {
                Client SelectedClient = Client.Find(parameters.id);
                SelectedClient.DeleteClient();
                return View["client_deleted.cshtml"];
            };

            Delete["client/delete/{id}"] = parameters => {
                Client SelectedClient = Client.Find(parameters.id);
                SelectedClient.DeleteClient();
                return View["client_deleted.cshtml"];
            };
        }
    }
}
