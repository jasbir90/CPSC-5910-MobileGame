using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace CadmusDND
{
	public partial class BattlePage : ContentPage
	{
		private bool initialized = false;
		private double scrWidth;
		private double scrHeight;
        private int damageCount;
        private double damageVx;
        private double damageVy;
        private Image dyingImg;
        private int dyingCount;
        public static double ImgSize = 64.0;

		public BattlePage()
		{
			InitializeComponent();
            GameController.Instance.PrepareBattle(true);
		}

        public void OnTimer()
        {
            if (!initialized) 
            {
                InitCoord();
                initialized = true;
            }
            // Damage Animation
            if (damageCount > 0) 
            {
				damageCount++;
				if (damageCount > 12)
				{
					Damage.IsVisible = false;
				}
				Damage.TranslationX += damageVx;
				Damage.TranslationY += damageVy;
				damageVy += 1;
			}
            // Dying Animation
            if (dyingCount > 0)
            {
                dyingCount++;
                dyingImg.TranslationY += dyingCount * 4;
                dyingImg.Rotation = dyingCount * 30.0;
                if (dyingCount == 12)
                {
                    dyingImg.IsVisible = false;
                    dyingImg = null;
                    dyingCount = 0;
                }
            }
        }

        public void OnButtonClicked(object sender, EventArgs args)
		{
            GameController.Instance.Surrender();
		}

        private void InitCoord()
        {
			scrWidth = Application.Current.MainPage.Width;
			scrHeight = Application.Current.MainPage.Width;

            // Char
            for (int i = 0; i < VBattleModel.MaxSlots; i++)
            {
                Image img = GameObjImage(0, i);
                if (img != null)
                {
                    if (!GameController.Instance.SetSlot(0, i, img, GetXPos(0, i), GetYPos(0, i)))
                    {
                        img.IsVisible = false;
                    }
                }
            }
			// Monster
			for (int i = 0; i < VBattleModel.MaxSlots; i++)
			{
				Image img = GameObjImage(1, i);
				if (img != null)
				{
					if (!GameController.Instance.SetSlot(1, i, img, GetXPos(1, i), GetYPos(1, i)))
					{
						img.IsVisible = false;
					}
				}
			}

            Damage.TranslationX = scrWidth / 2;
			Damage.TranslationY = scrHeight / 2;
		}

        public Image GameObjImage(int side, int no)
        {
            if (side == 0)
            {
                switch (no)
                {
                    case 0: return Char0;
                    case 1: return Char1;
                    case 2: return Char2;
                    case 3: return Char3;
                }
            }
            else
            {
                switch (no)
                {
                    case 0: return Monster0;
                    case 1: return Monster1;
                    case 2: return Monster2;
                    case 3: return Monster3;
                }
            }
            return null;
        }

        public void SetDamage(string msg, double xPos, double yPos)
        {
			Damage.TranslationX = xPos;
			Damage.TranslationY = yPos;
            Damage.Text = msg;
            Damage.IsVisible = true;
            damageVy = -5.0;
            damageVx = ((new Random()).Next(3) - 1) * 2;
            damageCount = 1;
        }

        public void SetDying(VGameObj dyingObj)
        {
            dyingImg = dyingObj.image;
            dyingCount = 1;
        }

        private double GetXPos(int side, int no)
        {
            if (side == 0)
                return 0;
            else
                return scrWidth - ImgSize;
        }

        private double GetYPos(int side, int no)
        {
            return scrHeight * (no / 4.0 + 0.2);
        }
	}
}
