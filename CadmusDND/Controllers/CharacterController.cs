using System;
using Xamarin.Forms;
using System.Collections.Generic;
using CadmusDND;
namespace CadmusDND
{
	public class CharacterController
	{
		//objects and variables
		public CharacterModel CharacterObj1;
		public int defenceRateValue;
        public Dictionary<string, MagicModel> magicList;

		public CharacterController()
		{
		}

        public CharacterController(CharacterModel charObj)
        {
            CharacterObj1 = charObj;
            magicList = new Dictionary<string, MagicModel>();
        }
		//Method to check if the character is alive
		public bool isDead(CharacterModel CharacterObj1)
		{
            if (CharacterObj1.Health == 0)
                return true;
            
			else return false;
		}

		//Adding Item to Character
		public CharacterModel useItem(CharacterModel CharacterObj1)
		{
			CharacterObj1.Strength = CharacterObj1.Strength + CharacterObj1.item.upgradeValue;
			return CharacterObj1;
		}

		public void AddToInventory(ItemModel i)
		{
            CharacterObj1.inventory.Add(i);
            if (i.name.Contains("Tomb"))
            {
                MagicToggle(true);
                buildMagicGrid();
            }
		}
        //Removing item from Character
        public void deleteItem(ItemModel i)
        {
            if (CharacterObj1.inventory.Contains(i))
            {
                CharacterObj1.inventory.Remove(i);
                if(CharacterObj1.Magic && i.name.Contains("Tomb"))
                {
                    buildMagicGrid();
                    if (magicList.Count == 0) { MagicToggle(false); }
                }
            }
        }
        // Remove certain type of object from Character
        public void deleteItemType(string type)
        {
            foreach(ItemModel item in CharacterObj1.inventory)
            {
                if(item.type == type)
                {
                    deleteItem(item);
                }
            }
        }

        public bool HasItemType(string type)
        {
			foreach (ItemModel item in CharacterObj1.inventory)
			{
                if (item.type == type)
                {
                    return true;
                }

                else { return false; }
			}
            return false;
        }
		//character defense Rate
		public int defenseRate(CharacterModel CharacterObj1)
		{
			defenceRateValue = CharacterObj1.Speed * CharacterObj1.Dexterity;
			return defenceRateValue;
		}
		//When the level is increased by 1, the experience of the character is increased by 10
		public int levelup(CharacterModel CharacterObj1)
		{
			CharacterObj1.Experience = CharacterObj1.Experience + 10;
			return CharacterObj1.Experience;
		}

        // The following methods control magic
        public void MagicToggle(bool val)
        {
            CharacterObj1.Magic = val;
        }

        public void buildMagicGrid()
        {
			foreach (ItemModel item in CharacterObj1.inventory)
			{
                if (item.name.Contains("Tomb") && !magicList.ContainsKey(item.name))
				{
                    MagicToggle(true);
                    MagicModel magic = new MagicModel(item.itemID, item.name, item.type, item.upgradeAttribute, item.upgradeValue);
                    //MagicModel magic = new MagicModel();
     //               magic.Itemid = item.itemID;
					//magic.AttribMod = item.upgradeAttribute;
					//magic.AttribValues = item.upgradeValue;
					//magic.Name = item.name;
					//magic.Type = item.type;
					magicList.Add(item.name, magic);
				}
			}
        }
	}
}
