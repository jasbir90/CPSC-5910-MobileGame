using System;
using System.Collections.Generic;

namespace CadmusDND
{
	//inheriting Base Class
	public class CharacterModel : CreatureModel
	{
        public List<ItemModel> inventory;

		//constructor
		public CharacterModel(CreatureModel creature, int experience, ItemModel item)
            : base(creature.Name,creature.Level,creature.Strength, creature.Dexterity, creature.Health, creature.Speed, creature.Image)
		{
			//this.level = level;
            Experience = experience;
			this.item = item;
            inventory = new List<ItemModel>();
            if(item != null) { inventory.Add(item); }

            UpdateText();
		}
		//attributes
        public int Experience { get; set;}
		public ItemModel item
		{
			get;
			set;
		}

        public override void UpdateText()
        {
            TextTitle = String.Format("{0} ({1})", Name, Level);
            TextDesc = String.Format("STR: {0} DEX: {1} HP: {2} SPD: {3} EXP: {4}", Strength, Dexterity, Health, Speed, Experience);
        }

        public List<ItemModel> Inventory { get; set; }
    }
}
