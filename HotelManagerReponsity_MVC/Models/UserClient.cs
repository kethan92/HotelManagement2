using HotelManagerReponsity_MVC.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;

namespace HotelManagerReponsity_MVC.Models
{
    public class UserClient
    {
        private string Base_URL = "http://localhost:54788/api/";

        public User checkUser(LoginUser login)
        {
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(Base_URL);
                client.DefaultRequestHeaders.Accept.Add(
                    new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = client.GetAsync("Users?username=" + 
                    login.username + "&password=" + login.password).Result;
                if(response.IsSuccessStatusCode)
                {
                    return response.Content.ReadAsAsync<User>().Result;
                }
                return null;
            }
            catch
            {
                return null;
            }
        }
    }
}