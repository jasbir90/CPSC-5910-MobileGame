using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace CadmusDND
{
	public partial class ScorePage : ContentPage
	{
        public ScorePage()
        {
            InitializeComponent();

            // Temporary Score View
            GameModel gm = GameModel.Instance;
            CharNo.Text = string.Format("{0} character(s) in your party", gm.Characters.Count);
            Experience.Text = string.Format( "Experience: {0}", gm.Characters[0].Experience );
            Level.Text = string.Format("Character level is {0}", gm.Characters[0].Level);
            Gold.Text = string.Format("You have {0} gold", gm.Gold);
            BattleNo.Text = string.Format("{0} total battles", gm.BattleTotal);
            Victory.Text = string.Format("{0} total victories", gm.BattleVictory);
            MonterKill.Text = string.Format("Totally {0} monsters killed", gm.MonsterKill);
            BattleNo.Text = string.Format("Win {0} battles out of {1} total battles", gm.BattleVictory, gm.BattleTotal);
        }

        public async void OnButtonClicked(object sender, EventArgs args)
		{
			await Navigation.PopAsync();
		}
	}
}
