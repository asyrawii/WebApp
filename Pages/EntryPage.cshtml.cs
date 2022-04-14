using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using WebApp.Models;
using System.Text;
using MyForest9ePermit.Server.Services;
using WebApp.Services;

namespace WebApp.Pages
{
    public class EntryPageModel : PageModel
    {
        //private DatabaseService dbService { get; set; }
        private HttpService httpService { get; set; }

        public EntryPageModel(HttpService service) // (DatabaseService service)
        {
            //dbService = service;
            httpService = service;
        }

        [BindProperty]
        public User usr { get; set; }
        public List<User> usrList { get; set; }

        public void OnGet()
        {
            string list = httpService.GetUserList().Result;
            usrList = JsonConvert.DeserializeObject<List<User>>(list);

            //string list = dbService.GetUserList();
            //usrList = JsonConvert.DeserializeObject<List<User>>(list);
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            else
            {
                httpService.PostNewUser(usr);

                //dbService.InsertNewUser(usr);
                //dbService.UpdateUser(updtUser);
            }

            return RedirectToPage("/Index");
        }
    }
}