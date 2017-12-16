using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

using Xamarin.Forms;

namespace CadmusDND
{
	public class BattleLog
	{
		public string Text { get; set; }
		public string Detail { get; set; }
	}

	public partial class TextBattlePage : ContentPage
    {
        public bool done = false;
        public ObservableCollection<BattleLog> BattleLogData = new ObservableCollection<BattleLog>();
        public TextBattlePage()
        {
            InitializeComponent();
            BattleView.ItemsSource = BattleLogData;
			GameController.Instance.PrepareBattle(false);
		}

        public void OnTimer()
        {
            if (done)
                return;
            if (GameController.Instance.battleEventLoaded == false)
                return;
            done = true;
			GameController.Instance.ProcessBattleText(this);
			// Scroll To End
			BattleView.ScrollTo(BattleLogData[BattleLogData.Count - 1], ScrollToPosition.End, false);
		}

		public async void OnButtonClicked(object sender, EventArgs args)
		{
			await Navigation.PopAsync();
		}

        public void AddBattleLog(string _Text, string _Detail)
        {
            BattleLogData.Add(new BattleLog { Text = _Text, Detail = _Detail });
		}
    }
}
