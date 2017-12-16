using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace CadmusDND
{
    public partial class SettingsPage : ContentPage
    {
        public SettingsPage()
        {
            InitializeComponent();
			Title = "Settings";
			ItemServer.IsToggled = GameController.Instance.itemServer;
            ItemRandom.IsToggled = GameController.Instance.itemRandom;
			ItemSuper.IsToggled = GameController.Instance.itemSuper;
			BattleEvent.IsToggled = GameController.Instance.battleEvent;
		}
		async public void OnButtonClicked(object sender, EventArgs args)
		{
			Button button = (Button)sender;
			if (button.Text == "Restart Game")
			{
				bool yes = await DisplayAlert("Restart Game", "All game data will be reset!", "Yes", "No");
				if (yes)
				{
					GameController.Instance.RestartGame();
					await DisplayAlert("Restart Game", "New game started!", "OK");
				}
			}
		}

        public void OnToggled(object sender, ToggledEventArgs args)
        {
            Switch swt = (Switch)sender;
            if (swt == ItemServer)
            {
                bool itemServer = swt.IsToggled;
                ItemRandom.IsEnabled = itemServer;
				ItemSuper.IsEnabled = itemServer;

				GameController.Instance.itemServer = ItemServer.IsToggled;
				GameController.Instance.itemRandom = ItemRandom.IsToggled;
				GameController.Instance.itemSuper = ItemSuper.IsToggled;
				// Call
				// ItemServer.IsToggled, ItemRandom.IsToggled, ItemSuper.IsToggled, 
			}
            else if (swt == ItemRandom || swt == ItemSuper)
            {
				GameController.Instance.itemServer = ItemServer.IsToggled;
				GameController.Instance.itemRandom = ItemRandom.IsToggled;
				GameController.Instance.itemSuper = ItemSuper.IsToggled;

				// Call
				// ItemServer.IsToggled, ItemRandom.IsToggled, ItemSuper.IsToggled, 
			}
            else if (swt == CriticalHit)
			{
				// Call swt.IsToggled;
			}
			else if (swt == CriticalMiss)
			{
				// Call swt.IsToggled;
			}
			else if (swt == ItemUsage)
			{
				// Call swt.IsToggled;
			}
			else if (swt == MagicUsage)
			{
				// Call swt.IsToggled;
			}
            else if (swt == HealingUsage)
			{
				// Call swt.IsToggled;
			}
			else if (swt == BattleEvent)
			{
                GameController.Instance.battleEvent = swt.IsToggled;
			}
        }
	}
}
