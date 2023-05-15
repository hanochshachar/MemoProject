using Microsoft.AspNetCore.DataProtection.KeyManagement;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http.Headers;
using System.Xml.Linq;

namespace MemoProject.model
{
    public class UserManager
    {
        public async Task<string> getList(int page, int per_page)
        {
            using (var httpClient = new HttpClient())
            {

                using (var request = new HttpRequestMessage(new HttpMethod("GET"), $"https://reqres.in/api/users?page={page}&per_page={per_page}"))
                {
                    var response = await httpClient.SendAsync(request);


                    string responseBody = await response.Content.ReadAsStringAsync();
                    return responseBody;
                }
            }
        }
        public async Task<string> getUser(int id)
        {
            using (var httpClient = new HttpClient())
            {

                using (var request = new HttpRequestMessage(new HttpMethod("GET"), $"https://reqres.in/api/users/{id}"))
                {
                    var response = await httpClient.SendAsync(request);


                    string responseBody = await response.Content.ReadAsStringAsync();
                    return responseBody;
                }
            }
        }
        public async Task<string> CreateUser(User user)
        {
            using (var httpClient = new HttpClient())
            {
                using (var request = new HttpRequestMessage(new HttpMethod("POST"), "https://reqres.in/api/register"))
                {
                    var jsonObj = new
                    {
                        username = $"{user.username}",
                        email = $"{user.email}",
                        password = $"{user.password}"
                    };
                    string jStr = JsonConvert.SerializeObject(jsonObj);
                    request.Content = new StringContent($"{jStr}");
                    request.Content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json");
                    var response = await httpClient.SendAsync(request);
                    var responseBody = await response.Content.ReadAsStringAsync();
                    return responseBody;
                }
            }
        }

        public async Task<string> UpdateUser(int id, User user)
        {
            using (var httpClient = new HttpClient())
            {
                using (var request = new HttpRequestMessage(new HttpMethod("POST"), $"https://reqres.in/api/users/{id}"))
                {
                    var jsonObj = new
                    {
                        username = $"{user.username}",
                        email = $"{user.email}",
                        password = $"{user.password}"
                    };
                    string jStr = JsonConvert.SerializeObject(jsonObj);
                    request.Content = new StringContent($"{jStr}");
                    request.Content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json");
                    
                   
                        var response = await httpClient.SendAsync(request);
                        var responseBody = await response.Content.ReadAsStringAsync();
                        return responseBody;
                  
                 
                    
                }
            }
        }

        public async Task<HttpStatusCode> DeleteUser(int id)
        {
            using (var httpClient = new HttpClient())
            {

                using (var request = new HttpRequestMessage(new HttpMethod("DELETE"), $"https://reqres.in/api/users/{id}"))
                {
                    var response = await httpClient.SendAsync(request);
                    return response.StatusCode;
                }
            }
        }
    }
}
