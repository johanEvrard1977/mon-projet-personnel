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
    public class VaisseauRepo : IVaisseauxRepo<int, Vaisseaux>
    {
        static string BaseUri = @"http://localhost:60504/api/";
        static string firstName = "jojo";
        static string pass = "jojo";
        HttpClient _httpClient;

        public bool Create(Vaisseaux T)
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

            HttpResponseMessage responseMessage = _httpClient.PostAsync("Vaisseaux", httpContent).Result;
            return responseMessage.IsSuccessStatusCode;

        }

        public void Delete(int id)
        {
            using (HttpClient client = new HttpClient())
            {
                _httpClient.BaseAddress = new Uri(BaseUri);
                _httpClient.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(
                    "Basic", Convert.ToBase64String(
                ASCIIEncoding.ASCII.GetBytes(
                   $"{firstName}:{pass}")));

                //la requête
                using (HttpResponseMessage response = client.DeleteAsync($"{BaseUri}Vaisseaux/" + id).Result)
                {
                    response.EnsureSuccessStatusCode();
                }
            }

        }

        public IEnumerable<Vaisseaux> GetAll()
        {


            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(
                    "Basic", Convert.ToBase64String(
                ASCIIEncoding.ASCII.GetBytes(
                   $"{firstName}:{pass}")));

                //la requête
                using (HttpResponseMessage response = client.GetAsync($"{BaseUri}Vaisseaux").Result)
                {
                    response.EnsureSuccessStatusCode();
                    using (HttpContent content = response.Content)
                    {
                        // la réponse, il ne resterai plus qu'à désérialiser
                        string result = content.ReadAsStringAsync().Result;
                        return JsonConvert.DeserializeObject<Vaisseaux[]>(result);
                    }
                }
            }
        }



        public Vaisseaux GetByName(string name)
        {
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(
                    "Basic", Convert.ToBase64String(
                ASCIIEncoding.ASCII.GetBytes(
                   $"{firstName}:{pass}")));

                //la requête
                using (HttpResponseMessage response = client.GetAsync($"{BaseUri}Vaisseaux/" + name).Result)
                {
                    response.EnsureSuccessStatusCode();
                    using (HttpContent content = response.Content)
                    {
                        // la réponse, il ne resterai plus qu'à désérialiser
                        string result = content.ReadAsStringAsync().Result;
                        return JsonConvert.DeserializeObject<Vaisseaux>(result);
                    }
                }
            }
        }

        public Vaisseaux GetOne(int id)
        {
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(
                    "Basic", Convert.ToBase64String(
                ASCIIEncoding.ASCII.GetBytes(
                   $"{firstName}:{pass}")));

                //la requête
                using (HttpResponseMessage response = client.GetAsync($"{BaseUri}Vaisseaux/" + id).Result)
                {
                    response.EnsureSuccessStatusCode();
                    using (HttpContent content = response.Content)
                    {
                        // la réponse, il ne resterai plus qu'à désérialiser
                        string result = content.ReadAsStringAsync().Result;
                        return JsonConvert.DeserializeObject<Vaisseaux>(result);
                    }
                }
            }

        }

        public bool Update(int id, Vaisseaux T)
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

            HttpResponseMessage responseMessage = _httpClient.PutAsync("Vaisseaux/" + id, httpContent).Result;
            return responseMessage.IsSuccessStatusCode;
        }
    }
}
