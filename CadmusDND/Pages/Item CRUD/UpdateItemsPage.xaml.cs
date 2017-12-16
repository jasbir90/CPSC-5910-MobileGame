using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace CadmusDND
{
    public partial class UpdateItemsPage : ContentPage
    {
        public UpdateItemsPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            GameDataAccess dataAccess = new GameDataAccess();
            UpdateItemListView.ItemsSource =  dataAccess.GetItems();
        }

        
        async void Items_ItemSelected(object sender, Xamarin.Forms.SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                await Navigation.PushAsync(new UpdateItemDetailPage() { BindingContext = e.SelectedItem as ItemModel });
            }
        }

    }
}
