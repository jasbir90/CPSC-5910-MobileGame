using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Plugin.RestClient;

namespace CadmusDND
{
    public class ItemRestClientService
    {
		

        public async Task<List<ItemModel>> PostCharForPostClient(ItemAPIRequestModel req)
		{


            RestClient<ItemModel> restClient = new RestClient<ItemModel>();

			var ItemList = await restClient.PostAsync(req);

			return ItemList;
		}
    }
}
