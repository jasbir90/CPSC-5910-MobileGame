using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using CadmusDND;
using Newtonsoft.Json;

namespace Plugin.RestClient
{
    /// <summary>
    /// RestClient implements methods for calling CRUD operations
    /// using HTTP.
    /// </summary>
    public class RestClient<T>
    {
        private const string WebServiceUrl = "http://gamehackathon.azurewebsites.net/api/GetItemsList";

        public async Task<List<T>> GetAsync()
        {
            var httpClient = new HttpClient();

            var json = await httpClient.GetStringAsync(WebServiceUrl);

            var taskModels = JsonConvert.DeserializeObject<List<T>>(json);

            return taskModels;
        }

        public async Task<List<ItemModel>> PostAsync(ItemAPIRequestModel req)
        {
            var httpClient = new HttpClient();

            var json = JsonConvert.SerializeObject(req);

            HttpContent httpContent = new StringContent(json);

            httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var jsonresult = await httpClient.PostAsync(WebServiceUrl, httpContent);
            var taskModels = JsonConvert.DeserializeObject<ItemAPIResponseModel>(jsonresult.Content.ReadAsStringAsync().Result);
            List<ItemModel> resp = new List<ItemModel>();

            if (taskModels.data != null)
            {
                foreach (APIDataModel item in taskModels.data)
                {
                    //if ((item.Name != null) && ((item.Name).Trim() != "") && (item.Description != null) && ((item.Description).Trim() != "") && (item.Tier != null))
                    //{ItemModel tempItem = new ItemModel();
                    ItemModel tempItem = new ItemModel();
                        tempItem.name = item.Name;
                        tempItem.description = item.Description;
                        tempItem.creator = item.Creator;
                        tempItem.image = item.Image;
                        tempItem.usage = item.Usage;
                        tempItem.upgradeAttribute = item.AttribMod;
                        tempItem.upgradeValue = item.Tier;
                        tempItem.bodyPart = item.BodyPart;
                        resp.Add(tempItem);
                    //}
                }
            }
            return resp;
        }

        public async Task<bool> PutAsync(int id, T t)
        {
            var httpClient = new HttpClient();

            var json = JsonConvert.SerializeObject(t);

            HttpContent httpContent = new StringContent(json);

            httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var result = await httpClient.PutAsync(WebServiceUrl + id, httpContent);

            return result.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteAsync(int id, T t)
        {
            var httpClient = new HttpClient();

            var response = await httpClient.DeleteAsync(WebServiceUrl + id);

            return response.IsSuccessStatusCode;
        }
    }
}