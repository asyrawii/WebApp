using Newtonsoft.Json;
using WebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace WebApp.Services
{
    public class HttpService
    {
        private HttpClient httpClient = new HttpClient();

        public async void PostNewUser(User user)
        {
            string jsonObj = JsonConvert.SerializeObject(user, Formatting.Indented);
            StringContent content = new StringContent(jsonObj, Encoding.UTF8, "application/json");

            string url = @"https://localhost:44375/dbuser";

            HttpResponseMessage response = await httpClient.PostAsync(url, content);
        }

        public async void UpdateNewUser(User user)
        { 
            string jsonObj = JsonConvert.SerializeObject(user, Formatting.Indented);
            StringContent content = new StringContent(jsonObj, Encoding.UTF8, "application/json");

            string url = @"https://localhost:44375/dbuser";

            HttpResponseMessage response = await httpClient.PutAsync(url, content);
        }

        public async Task<string> GetUserList()
        {
            string url = @"https://localhost:44375/dbuser/1";

            HttpResponseMessage response = await httpClient.GetAsync(url);

            response.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsStringAsync();
        }
    }
}