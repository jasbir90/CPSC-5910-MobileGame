using System;
using System.Collections.Generic;
using System.Linq;

namespace CadmusDND
{
	public class ItemController
	{
		private ItemModel baseItem;
		private List<ItemModel> upgradeItems;
        private Dictionary<string, int> upgradeStats;
		
        public Dictionary<string, int> UpgradeStats
		{
			get { return upgradeStats; }
            set { upgradeStats = value; }
		}

		public List<ItemModel> UgradeItems
		{
			get { return upgradeItems; }
			set { upgradeItems = value; }
		}

		public ItemController(ItemModel item)
		{
			baseItem = item;
			upgradeItems = new List<ItemModel>();
			upgradeStats = new Dictionary<string, int>();
			upgradeStats.Add(item.upgradeAttribute, item.upgradeValue);
		}


        // Adds an item upgrade
        public void addItem(ItemModel item)
		{
			upgradeItems.Add((item));

			// Check if upgradeType already exists, if it does, add new upgradeValue

			if (upgradeStats.ContainsKey(item.upgradeAttribute))
			{
				upgradeStats[item.upgradeAttribute] = upgradeStats[item.upgradeAttribute] + item.upgradeValue;
			}
			else
			{
				upgradeStats.Add(item.upgradeAttribute, item.upgradeValue);
			}
		}

        // Removes an item upgrade
		public void removeItem(ItemModel item)
		{
			if (upgradeItems.Contains(item))
			{
				upgradeItems.Remove(item);
				upgradeStats[item.upgradeAttribute] = upgradeStats[item.upgradeAttribute] - item.upgradeValue;

				if (upgradeStats[item.upgradeAttribute] == 0)
				{
					upgradeStats.Remove(item.upgradeAttribute);
				}
			}
		}

		// Returns a copy of the base item
		public ItemModel GetBaseItem()
		{
			ItemModel newBase = new ItemModel(baseItem.upgradeAttribute,
                                              baseItem.name, baseItem.upgradeAttribute, baseItem.upgradeValue,baseItem.description,baseItem.creator, baseItem.usage, baseItem.image, baseItem.bodyPart);
			return newBase;
		}


		// Returns the total value of stat upgrades.
		// Assumes the stat upgrade exists otherwise will return zero
		public int TotalStatUpgrades(string attribute)
		{
			if (upgradeStats.ContainsKey((attribute)))
			{
				return upgradeStats[attribute];
			}
			else { return 0; }
		}

        // Returns a copy of the upgradeStats dictionary
        public Dictionary < string,int > TotalStatUpgrades()
        {
            Dictionary < string, int > dictCopy = new Dictionary < string, int > ();
            foreach( KeyValuePair < string, int > entry in upgradeStats )
            {

                dictCopy.Add ( entry.Key, entry.Value );
            }

            return dictCopy;
        }
	}
}
