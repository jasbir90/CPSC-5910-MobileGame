using Xamarin.Forms;

namespace CadmusDND
{
	public partial class App : Application
	{
		public App()
		{
			InitializeComponent();

			MainPage = new CadmusDNDPage();
		}

		protected override void OnStart()
		{
			// Handle when your app starts
		}

		protected override void OnSleep()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume()
		{
			// Handle when your app resumes
		}

		public void GotoMainPage()
        {
			MainPage = new NavigationPage(new MainPage());
		}
	}
}
