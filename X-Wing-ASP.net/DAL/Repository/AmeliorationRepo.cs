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
    public class AmeliorationRepo : IAmeliorationRepo<int, Amelioration>
    {
        static string BaseUri = @"http://localhost:60504/api/";
        static string firstName = "jojo";
        static string pass = "jojo";
        HttpClient _httpClient;

        public bool Create(Amelioration T)
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

            HttpResponseMessage responseMessage = _httpClient.PostAsync("Amelioration", httpContent).Result;
            return responseMessage.IsSuccessStatusCode;

        }

        public void Delete(int id, Amelioration T)
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
            HttpResponseMessage responseMessage = _httpClient.DeleteAsync("Amelioration/" + id).Result;
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
                using (HttpResponseMessage response = client.GetAsync($"{BaseUri}Amelioration").Result)
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

        public Amelioration GetByName(string lastName)
        {
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(
                    "Basic", Convert.ToBase64String(
                ASCIIEncoding.ASCII.GetBytes(
                   $"{firstName}:{pass}")));

                //la requête
                using (HttpResponseMessage response = client.GetAsync($"{BaseUri}Amelioration/" + lastName).Result)
                {
                    response.EnsureSuccessStatusCode();
                    using (HttpContent content = response.Content)
                    {
                        // la réponse, il ne resterai plus qu'à désérialiser
                        string result = content.ReadAsStringAsync().Result;
                        return JsonConvert.DeserializeObject<Amelioration>(result);
                    }
                }
            }
        }

        public Amelioration GetOne(int id)
        {
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(
                    "Basic", Convert.ToBase64String(
                ASCIIEncoding.ASCII.GetBytes(
                   $"{firstName}:{pass}")));

                //la requête
                using (HttpResponseMessage response = client.GetAsync($"{BaseUri}Amelioration/" + id).Result)
                {
                    response.EnsureSuccessStatusCode();
                    using (HttpContent content = response.Content)
                    {
                        // la réponse, il ne resterai plus qu'à désérialiser
                        string result = content.ReadAsStringAsync().Result;
                        return JsonConvert.DeserializeObject<Amelioration>(result);
                    }
                }
            }

        }


        public bool Update(int id, Amelioration T)
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
            HttpResponseMessage responseMessage = _httpClient.PutAsync("Amelioration/" + id, httpContent).Result;
            return responseMessage.IsSuccessStatusCode;
        }

        IEnumerable<Amelioration> IRepository<int, Amelioration>.GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
