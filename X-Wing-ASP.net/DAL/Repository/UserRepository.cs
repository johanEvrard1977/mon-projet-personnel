using DAL.Entities;
using DAL.ViewModels;
using DalXwing.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public class UserRepository : IUserRepository<int, User>
    {
        static string BaseUri = @"http://localhost:60504/api/";
        static string firstName = "jojo";
        static string pass = "jojo";
        HttpClient _httpClient;

        public bool Create(User T)
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri(BaseUri);
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(
                "Basic", Convert.ToBase64String(
            ASCIIEncoding.ASCII.GetBytes(
               $"{firstName}:{pass}")));
            string json = JsonConvert.SerializeObject(T);

            HttpContent httpContent = new StringContent(json);
            httpContent.Headers.ContentType = new MediaTypeWithQualityHeaderValue("application/json");
            HttpResponseMessage responseMessage = _httpClient.PostAsync("Users", httpContent).Result;
            return responseMessage.IsSuccessStatusCode;

        }

        public void Delete(int id, User T)
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri(BaseUri);
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(
                "Basic", Convert.ToBase64String(
            ASCIIEncoding.ASCII.GetBytes(
               $"{firstName}:{pass}")));
            string json = JsonConvert.SerializeObject(T);
            HttpContent httpContent = new StringContent(json);
            httpContent.Headers.ContentType = new MediaTypeWithQualityHeaderValue("application/json");
            HttpResponseMessage responseMessage = _httpClient.DeleteAsync("Users/" + id).Result;
        }

        public IEnumerable<View> GetAll()
        {
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(
                    "Basic", Convert.ToBase64String(
                ASCIIEncoding.ASCII.GetBytes(
                   $"{firstName}:{pass}")));

                //la requête
                using (HttpResponseMessage response = client.GetAsync($"{BaseUri}Users").Result)
                {
                    response.EnsureSuccessStatusCode();
                    using (HttpContent content = response.Content)
                    {
                        // la réponse, il ne resterai plus qu'à désérialiser
                        string result = content.ReadAsStringAsync().Result;
                        return JsonConvert.DeserializeObject<View[]>(result);
                    }
                }
            }
        }



        public User GetByName(string name)
        {
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(
                    "Basic", Convert.ToBase64String(
                ASCIIEncoding.ASCII.GetBytes(
                   $"{firstName}:{pass}")));

                //la requête
                using (HttpResponseMessage response = client.GetAsync($"{BaseUri}Users/GetByName/" + name).Result)
                {
                    response.EnsureSuccessStatusCode();
                    using (HttpContent content = response.Content)
                    {
                        // la réponse, il ne resterai plus qu'à désérialiser
                        string result = content.ReadAsStringAsync().Result;
                        return JsonConvert.DeserializeObject<User>(result);
                    }
                }
            }
        }

        public User GetOne(int id)
        {
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(
                    "Basic", Convert.ToBase64String(
                ASCIIEncoding.ASCII.GetBytes(
                   $"{firstName}:{pass}")));

                //la requête
                using (HttpResponseMessage response = client.GetAsync($"{BaseUri}Users/" + id).Result)
                {
                    response.EnsureSuccessStatusCode();
                    using (HttpContent content = response.Content)
                    {
                        // la réponse, il ne resterai plus qu'à désérialiser
                        string result = content.ReadAsStringAsync().Result;
                        return JsonConvert.DeserializeObject<User>(result);
                    }
                }
            }

        }

        public bool Update(int id, User T)
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri(BaseUri);
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(
                "Basic", Convert.ToBase64String(
            ASCIIEncoding.ASCII.GetBytes(
               $"{firstName}:{pass}")));
            string json = JsonConvert.SerializeObject(T);
            HttpContent httpContent = new StringContent(json);
            httpContent.Headers.ContentType = new MediaTypeWithQualityHeaderValue("application/json");
            HttpResponseMessage responseMessage = _httpClient.PutAsync("Users/" + id, httpContent).Result;
            return responseMessage.IsSuccessStatusCode;
        }


        public bool Check(string username, string password)
        {
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(
                    "Basic", Convert.ToBase64String(
                ASCIIEncoding.ASCII.GetBytes(
                   $"{firstName}:{pass}")));

                //la requête
                using (HttpResponseMessage response = client.GetAsync($"{BaseUri}Users/Check/" + username+"/"+password).Result)
                {
                    response.EnsureSuccessStatusCode();
                    using (HttpContent content = response.Content)
                    {
                        // la réponse, il ne resterai plus qu'à désérialiser
                        string result = content.ReadAsStringAsync().Result;
                        return JsonConvert.DeserializeObject<bool>(result);
                    }
                }
            }
        }


        public bool CheckAdmin(string username, string password, string role)
        {
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(
                    "Basic", Convert.ToBase64String(
                ASCIIEncoding.ASCII.GetBytes(
                   $"{firstName}:{pass}")));
                //la requête
                using (HttpResponseMessage response = client.GetAsync($"{BaseUri}Users/CheckAdmin/" + username + "/" + password + "/" + role).Result)
                {
                    response.EnsureSuccessStatusCode();
                    using (HttpContent content = response.Content)
                    {
                        // la réponse, il ne resterai plus qu'à désérialiser
                        string result = content.ReadAsStringAsync().Result;
                        return JsonConvert.DeserializeObject<bool>(result);
                    }
                }
            }
        }


        IEnumerable<User> IRepository<int, User>.GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
