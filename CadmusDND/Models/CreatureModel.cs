﻿using System;
using System.Collections.Generic;

namespace CadmusDND
{
	public class CreatureModel
	{
		//attributes
		private string name;
        private int level;
		private int strength;
		private int dexterity;
		private int health;
		private int speed;
        private string image;
        private bool magic;
        // For UI
		public string TextTitle { get; set; }
		public string TextDesc { get; set; }
		//constructor
        public CreatureModel(){}
		public CreatureModel(string name, int level, int strength, int dexterity, int health, int speed, string image)
		{
            this.level = level;
			this.name = name;
			this.strength = strength;
			this.dexterity = dexterity;
			this.health = health;
			this.speed = speed;
            this.image = image;
            this.magic = false;
		}
		//getters and setters

		public int Level
		{
			get { return level; }
			set { level = value; }
		}

		public string Name
		{
			get { return name; }
			set { name = value; }
		}
		public int Strength
		{
			get { return strength; }
			set { strength = value; }
		}
		public int Dexterity
		{
			get { return dexterity; }
			set { dexterity = value; }
		}
		public int Health
		{
			get { return health; }
			set { health = value; }

		}
		public int Speed
		{
			get { return speed; }
			set { speed = value; }
		}
		public string Image
		{
			get { return image; }
            set { image = value; }
		}
		public bool isDead
		{
			get { return health == 0; }
		}

        public virtual void UpdateText()
        {
            
        }

        public bool Magic { get { return magic; } set { magic = value; } }
	}
}
