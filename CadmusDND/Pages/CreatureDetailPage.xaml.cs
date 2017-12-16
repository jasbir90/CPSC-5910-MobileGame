using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace CadmusDND
{
    public partial class CreatureDetailPage : ContentPage
    {
        public CreatureDetailPage(CreatureModel creature)
        {
            InitializeComponent();
            if (creature is CharacterModel)
			    Title = "Charater Details";
            else
			    Title = "Monster Details";
			ImageIcon.Source = creature.Image;
			LabelTitle.Text = creature.TextTitle;
			LabelDesc.Text = creature.TextDesc;
		}

		public async void OnButtonClicked(object sender, EventArgs args)
		{
			await Navigation.PopAsync();
		}
	}
}
