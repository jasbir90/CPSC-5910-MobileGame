using System;
using Xamarin.Forms;

namespace CadmusDND
{
    public class VGameObj
    {
        public double PositionX;
        public double PositionY;
		public bool isCharacter;
		public Image image;
        public CreatureModel Creature;
        public int CurHealth;

		public VGameObj()
        {
        }

        public void SetCharacter(CharacterModel cm)
        {
            isCharacter = true;
            Creature = cm;
            CurHealth = cm.Health;
        }

        public void SetMonster(MonsterModel mm)
        {
            isCharacter = false;
			Creature = mm;
            CurHealth = mm.Health;
		}

        public void SetPos()
        {
			image.TranslationX = PositionX;
			image.TranslationY = PositionY;
        }

        public void SetPos(double x, double y)
        {
            image.TranslationX = x;
            image.TranslationY = y;
        }
    }
}
