using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

using Xamarin.Forms;

namespace CadmusDND
{
    public partial class CharacterPage : ContentPage
    {
		public CharacterPage()
        {
			InitializeComponent();
   			CharacterView.ItemsSource = GameModel.Instance.Characters;
			CharacterView.ItemSelected += OnSelection;
		}

		async void OnSelection(object sender, SelectedItemChangedEventArgs e)
		{
			if (e.SelectedItem == null)
			{
				return;
			}
            CharacterModel selectedCM = (CharacterModel)e.SelectedItem;
            await Navigation.PushAsync(new CreatureDetailPage(selectedCM));
			((ListView)sender).SelectedItem = null;
		}

        public void OnButtonClicked(object sender, EventArgs args)
		{
		}
	}
}
