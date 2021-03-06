﻿using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace CadmusDND
{
    public partial class DeleteItemsPage : ContentPage
    {
        public DeleteItemsPage()
        {
            InitializeComponent();
        }
		protected override void OnAppearing()
		{
			base.OnAppearing();
			GameDataAccess dataAccess = new GameDataAccess();
			DeleteItemListView.ItemsSource = dataAccess.GetItems();
			
		}

		async void Items_ItemSelected(object sender, Xamarin.Forms.SelectedItemChangedEventArgs e)
		{
			if (e.SelectedItem != null)
			{
                await Navigation.PushAsync(new DeleteItems() { BindingContext = e.SelectedItem as ItemModel });
			}
		}
    }
}
