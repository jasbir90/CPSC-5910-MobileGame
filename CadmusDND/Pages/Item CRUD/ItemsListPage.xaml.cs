using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace CadmusDND
{
    public partial class ItemsListPage : ContentPage
    {
        public ItemsListPage()
        {
            InitializeComponent();
            this.Title = "Read Items";
        }

		protected override void OnAppearing()
		{
			base.OnAppearing();
            GameDataAccess dataAccess = new GameDataAccess();
                ItemListView.ItemsSource =  dataAccess.GetItems();
		}

		async void Items_ItemSelected(object sender, Xamarin.Forms.SelectedItemChangedEventArgs e)
		{
			if (e.SelectedItem != null)
			{
				await Navigation.PushAsync(new ReadItems() { BindingContext = e.SelectedItem as ItemModel });
			}
		}
    }
}
