using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Models;
using WebApp.Services;

namespace WebApp.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        public readonly JsonFileServices jsonService;
        public List<User> Users { get; set; }
        public List<Monkey> Monkeys { get; set; }
        public IndexModel(ILogger<IndexModel> logger, JsonFileServices json)
        {
            _logger = logger;
            jsonService = json;
        }

        public void OnGet()
        {
            Users = jsonService.LoadJsonFile<User>("data\\Userlist.json"); // data\\Userlist.json
            Monkeys = jsonService.LoadJsonFile<Monkey>("data\\Monkeys.json");
        }
    }
}
