using Xamarin.Forms;
using System;

namespace CadmusDND
{
	public partial class CadmusDNDPage : ContentPage
	{
		public CadmusDNDPage()
		{
			InitializeComponent();
            GameModel.Instance.Initialize();
            GameController.Instance.Initialize();
		}
		public void OnButtonClicked(object sender, EventArgs args)
		{
            DependencyService.Get<i_audio>().PlayAudioFile("DND.mp3");

            Device.StartTimer(TimeSpan.FromMilliseconds(30), () =>
			{
                GameController.Instance.OnTimer();
				return true;
			});


			((App)App.Current).GotoMainPage();
		}
	}
}