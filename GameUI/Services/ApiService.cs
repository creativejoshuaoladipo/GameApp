using GameUI.Models;
using GameUI.ViewModels;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace GameUI.Services
{
    public  class ApiService
    {
        static string baseUrl = "http://localhost:62112/simple-api/";


        public async Task<(bool, string)> Login(LoginVM login)
        {
            var signInVM = new SignInVM
            {
                Email = login.UserName,
                Password = login.Password
            };

            var httpClient = new HttpClient();
            var json = JsonConvert.SerializeObject(signInVM);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await httpClient.PostAsync($"{baseUrl}authenticate", content);
            if (!response.IsSuccessStatusCode)
                return (false, null);

            var jsonResult = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<ResponseModel>(jsonResult);

            if(result.StatusCode == HttpStatusCode.OK)
            {
                var jObj = JObject.FromObject(result.Data);

                var tokenInfo = jObj.ToObject<TokenInfo>();

                if(!string.IsNullOrEmpty(tokenInfo.AccessToken))
                {
                       return (true, tokenInfo.AccessToken);
                }

             
            }
            else
            {
                return (false, result.Message + result.StatusCode.ToString());
            }

            return (false, null);


        }

        public async Task<(bool, string, List<GameVM>)> GetAllGames()
        {
            var httpClient = new HttpClient();
            var response = await httpClient.GetStringAsync($"{baseUrl}get-games");
            var result = JsonConvert.DeserializeObject<ResponseModel>(response);
            if (result.StatusCode == HttpStatusCode.OK)
            {
                var jObj = JArray.FromObject(result.Data);

                var gamesList = jObj.ToObject<List<GameVM>>();

                
                    return (true, result.Message, gamesList);
                


            }
          
            return (false, result.Message, null);
        }
    }
}
