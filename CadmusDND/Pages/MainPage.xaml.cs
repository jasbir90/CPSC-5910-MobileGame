using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace CadmusDND
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();
			Title = "Cadmus DND";
		}
		async public void OnButtonClicked(object sender, EventArgs args)
		{
            DependencyService.Get<i_audio>().PlayAudioFile("mainPageClicks.mp3");
			Button button = (Button)sender;
			if (button.Text == "Score")
			{
				await Navigation.PushAsync(new ScorePage());
			}
			else if (button.Text == "Character")
			{
				await Navigation.PushAsync(new CharacterPage());
			}
			else if (button.Text == "Inventory")
			{
				await Navigation.PushAsync(new InventoryPage());
			}
			else if (button.Text == "Monsters")
			{
				await Navigation.PushAsync(new MonstersPage());
			}
			else if (button.Text == "Items")
			{
				await Navigation.PushAsync(new ItemsPage());
			}
			else if (button.Text == "Battle")
			{
				bool yes = await DisplayAlert("Battle", "Animated Battle?", "Yes", "No");
				if (yes)
				{
					await Navigation.PushAsync(new BattlePage());
				}
                else
                {
					await Navigation.PushAsync(new TextBattlePage());
				}
			}
            else if(button.Text == "About")
            {
                await Navigation.PushAsync(new AboutPage());
            }
			else if (button.Text == "Settings")
			{
				await Navigation.PushAsync(new SettingsPage());
			}
		}
	}
}
