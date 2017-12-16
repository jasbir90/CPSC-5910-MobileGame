using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace CadmusDND
{
    public partial class DeleteItems : ContentPage
    {
        public DeleteItems()
        {
            InitializeComponent();
        }
		void Delete_Clicked(object sender, System.EventArgs e)
		{
            var ItemRow = (ItemModel)BindingContext;
			GameDataAccess dataAccess = new GameDataAccess();
			dataAccess.DeleteItem(ItemRow);
            Navigation.PopAsync();
		}

		async void Cancel_Clicked(object sender, System.EventArgs e)
		{
			await Navigation.PopAsync();
		}
    }
}
