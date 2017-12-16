using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace CadmusDND
{
	public partial class ItemsPage : ContentPage
	{
		public ItemsPage()
		{
			InitializeComponent();
			Title = "CRUD Items";
		}
		async void Create_Clicked(object sender, System.EventArgs e)
		{
			await Navigation.PushAsync(new CreateItemPage() { BindingContext = new ItemModel() });
		}
		async void Read_Clicked(object sender, System.EventArgs e)
		{
			ItemRestClientService ItemService = new ItemRestClientService();
            ItemAPIRequestModel reqItem = new ItemAPIRequestModel();
            reqItem.randomItemOption = 1;
            reqItem.superItemOption = 1;
            List<ItemModel> items = new List<ItemModel>();
             items = await ItemService.PostCharForPostClient(reqItem);
            GameDataAccess dataAccess = new GameDataAccess();
            dataAccess.DeleteAllItem();
            foreach (ItemModel item in items)
            {
				
                dataAccess.InsertItem(item);
            }
			await Navigation.PushAsync(new ItemsListPage());
		}
		async void Update_Clicked(object sender, System.EventArgs e)
		{
			await Navigation.PushAsync(new UpdateItemsPage());
		}
		async void Delete_Clicked(object sender, System.EventArgs e)
		{
            await Navigation.PushAsync(new DeleteItemsPage());
		} 
	}
}
