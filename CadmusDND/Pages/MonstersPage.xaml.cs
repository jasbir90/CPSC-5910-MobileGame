using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

using Xamarin.Forms;

namespace CadmusDND
{
	public partial class MonstersPage : ContentPage
	{
		public MonstersPage()
		{
			InitializeComponent();
			MonsterView.ItemsSource = GameModel.Instance.Monsters;
			MonsterView.ItemSelected += OnSelection;
		}

		async void OnSelection(object sender, SelectedItemChangedEventArgs e)
		{
			if (e.SelectedItem == null)
			{
				return;
			}
			MonsterModel selectedMM = (MonsterModel)e.SelectedItem;
			await Navigation.PushAsync(new CreatureDetailPage(selectedMM));
			((ListView)sender).SelectedItem = null;
		}
	}
}
