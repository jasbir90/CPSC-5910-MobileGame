using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace CadmusDND
{
    public partial class UpdateItemDetailPage : ContentPage
    {
        public UpdateItemDetailPage()
        {
            InitializeComponent();
        }

		async void Update_Clicked(object sender, System.EventArgs e)
		{
            var ItemRow = (ItemModel)BindingContext;
			GameDataAccess dataAccess = new GameDataAccess();
			 dataAccess.UpdateItem(ItemRow);
			
			await Navigation.PopAsync();
		}
		async void Cancel_Clicked(object sender, System.EventArgs e)
		{
			await Navigation.PopAsync();
		}
    }
}
