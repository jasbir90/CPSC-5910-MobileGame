using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace CadmusDND
{
    public partial class AboutPage : ContentPage
    {
        public AboutPage()
        {
            InitializeComponent();


        }

		public void OnButtonClicked(object sender, EventArgs args)
		{
			
			((App)App.Current).GotoMainPage();
		}
    }
}
