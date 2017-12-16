using System;
using System.Collections.Generic;
using CadmusDND;
using System.Linq;
using Xamarin.Forms;
namespace CadmusDND
{
    public partial class CreateItemPage : ContentPage
    {
        public CreateItemPage()
        {
            InitializeComponent();

        }
		async void Save_Clicked(object sender, System.EventArgs e)
		{
            GameDataAccess dataAccess = new GameDataAccess();
			var ItemRow = (ItemModel)BindingContext;
            dataAccess.InsertItem(ItemRow);
			
			await Navigation.PopAsync();
		}

		async void Cancel_Clicked(object sender, System.EventArgs e)
		{
			await Navigation.PopAsync();
		}
    }
}
