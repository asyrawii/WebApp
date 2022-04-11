using Newtonsoft.Json;
using WebApp.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;

namespace WebApp.Services
{
    public class JsonFileServices
    {
        private StreamReader srArray;
        private IWebHostEnvironment WebHostEnvironment { get; }

        public JsonFileServices(IWebHostEnvironment webHostEnvironment)
        {
            WebHostEnvironment = webHostEnvironment;
        }

        // Generic Function
        public void SaveJsonFile<T>(List<T> inputList, string filename) where T : new()
        {
            string listOutput = JsonConvert.SerializeObject(inputList, Formatting.Indented);

            string fullPathFilename = Path.Combine(WebHostEnvironment.WebRootPath,filename);

            if (File.Exists(fullPathFilename))
            {
                File.Delete(fullPathFilename);
            }

            File.WriteAllText(fullPathFilename, listOutput);
        }

        //public static void SaveJsonFile(List<User> userList)
        //{
        //    string listOutput = JsonConvert.SerializeObject(userList, Formatting.Indented);

        //    if (File.Exists("UserList.json"))
        //    {
        //        File.Delete("UserList.json");
        //    }

        //    File.WriteAllText("UserList.json", listOutput);
        //}

        // Generic Function
        public List<T> LoadJsonFile<T>(string jsonFilename) where T : new()
        {
            try
            {
                string fullPathFilename = Path.Combine(WebHostEnvironment.WebRootPath,jsonFilename);

                srArray = new StreamReader(fullPathFilename);
                string outputFromFile = srArray.ReadToEnd();

                List<T> classArray = JsonConvert.DeserializeObject<List<T>>(outputFromFile);

                srArray.Close();

                return classArray;
            }
            catch (Exception ex)
            {
                return null;
                //throw;
            }
        }

        //public static List<User> LoadJsonFile(string jsonFilename)
        //{
        //    try
        //    {
        //        srArray = new StreamReader(jsonFilename);
        //        string outputFromFile = srArray.ReadToEnd();

        //        List<User> usrArray = JsonConvert.DeserializeObject<List<User>>(outputFromFile);

        //        srArray.Close();

        //        return usrArray;
        //    }
        //    catch (Exception)
        //    {
        //        return null;
        //        //throw;
        //    }
        //}
    }
}