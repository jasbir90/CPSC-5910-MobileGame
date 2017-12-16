﻿using System;
using System.Collections.Generic;
using SQLite;

namespace CadmusDND
{
    [Table("Items")]
	public class ItemModel
	{
        public ItemModel(){}
		public ItemModel(string type, string name, string upgradeAttribute, int upgradeValue, string description, string creator, int usage, string image, string bodyPart)
		{
			this.name = name;
			this.type = type;
			this.upgradeAttribute = upgradeAttribute;
			this.upgradeValue = upgradeValue;
            this.description = description;
            this.creator = creator;
            this.usage = usage;
            this.image = image;
            this.bodyPart = bodyPart;
		}
		[PrimaryKey, AutoIncrement]
		public int itemID { get; set; }
		public string type
		{
			get;
			set;
		}
		public string bodyPart
		{
			get;
			set;
		}
		public string name
		{
			get;
			set;
		}
		public string upgradeAttribute
		{
			get;
			set;
		}
		public int upgradeValue
		{
			get;
			set;
		}
        public int usage
		public string image
		{
			get;
			set;
		}

		public string description
		{
			get;
			set;
		}
		public int usage
		{
			get;
			set;
		}
        public string creator
        {
            get;
            set;
        }
		//static List<ItemModel> createItems()
		//{
		//	ItemModel item1 = new ItemModel("Apple", "Food", "health", 12);
		//	ItemModel item2 = new ItemModel("Health Portion", "Portion", "health", 100);
		//	ItemModel item3 = new ItemModel("Health Drink", "Portion", "health", 1000);
		//	ItemModel item4 = new ItemModel("Cocktail", "Drink", "health", 23);
		//	ItemModel item5 = new ItemModel("Cake", "Food", "health", 100000);
		//	List<ItemModel> itemList = new List<ItemModel>();
		//	itemList.Add(item1);
		//	itemList.Add(item2);
		//	itemList.Add(item3);
		//	itemList.Add(item4);
		//	itemList.Add(item5);
		//	return itemList;
		//}
	}
}
