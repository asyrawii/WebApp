using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Models;
using WebApp.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApp.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        static List<User> usrNew = new List<User>();
        private JsonFileServices jsonService { get; set; }
        public UserController(JsonFileServices json)
        {
            jsonService = json;
        }

        // GET: api/<UserController>
        [HttpGet]
        public List<User> Get()
        {
            if (usrNew.Count == 0)
            {
                usrNew = jsonService.LoadJsonFile<User>("data\\Userlist.json");

                if (usrNew == null)
                {
                    usrNew = new List<User>();
                }
            }

            return usrNew; //new string[] { "value1", "value2" };
        }

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public User Get(int id)
        {
            return usrNew.Find(x => x.UserID == id);
        }

        [HttpGet]
        [Route("byname")]
        public User Get(string name)
        {
            return usrNew.Find(x => x.Name.ToUpper() == name.ToUpper());
        }

        // POST api/<UserController>
        [HttpPost]
        public void Post([FromBody] User value)
        {
            if (usrNew.Count == 0)
            {
                usrNew = jsonService.LoadJsonFile<User>("data\\Userlist.json");

                if (usrNew == null)
                {
                    usrNew = new List<User>();
                }
            }
            int MaxId = usrNew.Max(x => x.UserID);
            MaxId++;
            value.UserID = MaxId;
            usrNew.Add(value);
            jsonService.SaveJsonFile<User>(usrNew, "data\\Userlist.json");
        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] User value)
        {
            User selectedUser = usrNew.Find(x => x.UserID == id);

            if (selectedUser != null)
            {
                if (value.NRIC != null)
                    selectedUser.NRIC = value.NRIC;

                if (value.DOB != null)
                    selectedUser.DOB = value.DOB;
            }

            jsonService.SaveJsonFile<User>(usrNew, "data\\Userlist.json");
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            User selectedUser = usrNew.Find(x => x.UserID == id);

            if (selectedUser != null)
            {
                usrNew.Remove(selectedUser);
            }

            jsonService.SaveJsonFile<User>(usrNew, "data\\Userlist.json");
        }
    }
}