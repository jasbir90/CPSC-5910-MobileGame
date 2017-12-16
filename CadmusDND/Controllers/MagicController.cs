using System;
using System.Collections.Generic;

namespace CadmusDND
{
    public class MagicController
    {
        //public MagicModel MagicObj;
        public CharacterModel hero;

        public MagicController()
        {
        }

        public MagicController(CharacterModel character)
        {
            hero = character;
           // MagicObj = magic;
        }

        public Tuple<string,int,List<CreatureModel>> UseMagic(string spell, List<CreatureModel> creatures)
        {
            List<CreatureModel> resultcreature = new List<CreatureModel>();
            string msg = "";
            int effect = 0;
            if(hero.Magic)
            {
                CharacterController HeroCtrl = new CharacterController(hero);
                HeroCtrl.buildMagicGrid();
                MagicModel magic; HeroCtrl.magicList.TryGetValue(spell,out magic);
                msg = magic.AttribValues.ToString() + " (" + magic.AttribMod + ")";
                effect = magic.AttribValues;

                if(magic.AttribMod == "MAGICALL")
                {
                    foreach(CreatureModel c in creatures)
                    {
                        if(magic.AttribMod == "STRENGTH") { c.Strength += effect; }
                        if (magic.AttribMod == "SPEED") { c.Speed += effect; }
                        if (magic.AttribMod == "DEFENSE") { c.Dexterity += effect; }
                        if (magic.AttribMod == "HP") { c.Health += effect; }
                        resultcreature.Add(c);
                    }
                }

                else 
                {
                    CreatureModel c = creatures[0];
					if (magic.AttribMod == "STRENGTH") { c.Strength += effect; }
					if (magic.AttribMod == "SPEED") { c.Speed += effect; }
					if (magic.AttribMod == "DEFENSE") { c.Dexterity += effect; }
					if (magic.AttribMod == "HP") { c.Health += effect; }
                    resultcreature.Add(c);
                }

                // Reduce usage
                bool removeitem = false;
                ItemModel removeme = null;
                foreach(ItemModel item in hero.inventory)
                {
                    if (item.itemID == magic.Itemid)
                    {
                        item.usage -= 1;
						if (item.usage <= 0)
						{
                            removeitem = true;
                            removeme = item;
                            HeroCtrl.buildMagicGrid();
                            if(HeroCtrl.magicList.Count == 0) { HeroCtrl.MagicToggle(false);}
						}
                    }
                }
                if (removeitem)
				{
                    hero.inventory.Remove(removeme);
				}
            }
            Tuple<string,int,List<CreatureModel>> result = new Tuple<string, int, List<CreatureModel>>(msg, effect,resultcreature);

            return result;
        }
    }
}
