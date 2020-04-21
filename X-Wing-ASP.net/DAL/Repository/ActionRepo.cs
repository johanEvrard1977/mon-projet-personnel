using DalXwing.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
namespace DAL.Repository
{
    public class ActionRepo : IActionRepo<int, Actions>
    {
        static string BaseUri = @"http://localhost:60504/api/";
        static string firstName = "jojo";
        static string pass = "jojo";
        HttpClient _httpClient;

        public bool Create(Actions T)
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

            HttpResponseMessage responseMessage = _httpClient.PostAsync("Action", httpContent).Result;
            return responseMessage.IsSuccessStatusCode;

        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id, Actions T)
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

            HttpResponseMessage responseMessage = _httpClient.DeleteAsync("Action/" + id).Result;
            //return responseMessage.IsSuccessStatusCode;
        }

        public IEnumerable<Actions> GetAll()
        {
            

            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(
                    "Basic", Convert.ToBase64String(
                ASCIIEncoding.ASCII.GetBytes(
                   $"{firstName}:{pass}")));

                //la requête
                using (HttpResponseMessage response = client.GetAsync($"{BaseUri}Action").Result)
                {
                    response.EnsureSuccessStatusCode();
                    using (HttpContent content = response.Content)
                    {
                        // la réponse, il ne resterai plus qu'à désérialiser
                        string result = content.ReadAsStringAsync().Result;
                        return JsonConvert.DeserializeObject<Actions[]>(result);
                    }
                }
            }
        }



        public Actions GetByName(string name)
        {
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(
                    "Basic", Convert.ToBase64String(
                ASCIIEncoding.ASCII.GetBytes(
                   $"{firstName}:{pass}")));

                //la requête
                using (HttpResponseMessage response = client.GetAsync($"{BaseUri}Action/GetByName/" + name).Result)
                {
                    response.EnsureSuccessStatusCode();
                    using (HttpContent content = response.Content)
                    {
                        // la réponse, il ne resterai plus qu'à désérialiser
                        string result = content.ReadAsStringAsync().Result;
                        return JsonConvert.DeserializeObject<Actions>(result);
                    }
                }
            }
        }

        public Actions GetOne(int id)
        {
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(
                    "Basic", Convert.ToBase64String(
                ASCIIEncoding.ASCII.GetBytes(
                   $"{firstName}:{pass}")));

                //la requête
                using (HttpResponseMessage response = client.GetAsync($"{BaseUri}Action/"+id).Result)
                {
                    response.EnsureSuccessStatusCode();
                    using (HttpContent content = response.Content)
                    {
                        // la réponse, il ne resterai plus qu'à désérialiser
                        string result = content.ReadAsStringAsync().Result;
                        return JsonConvert.DeserializeObject<Actions>(result);
                    }
                }
            }

        }

        public bool Update(int id, Actions T)
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

            HttpResponseMessage responseMessage = _httpClient.PutAsync("Action/"+id, httpContent).Result;
            return responseMessage.IsSuccessStatusCode;
        }
    }
}
