using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using CadmusDND;

namespace CadmusDND
{
    public class GameModel
    {
        // Singleton Implementation
        private static GameModel instance;
        GameDataAccess dataAccess1;
		public List<int> leveling { get; }
		private Dictionary<int, int> experience;
        public static GameModel Instance
        {
            get 
            {
                if (instance == null)
                {
                    instance = new GameModel();
                }
                return instance;
            }
        }

        // Game Data
        public ObservableCollection<CharacterModel> Characters;     // Characters in my party
        public ObservableCollection<MonsterModel> Monsters;         // Monsters in the game
        public VBattleModel battleModel;
        // Statistics
        public int Gold { get; set; }
		public int BattleTotal { get; set; }
		public int BattleVictory { get; set; }
        public int MonsterKill { get; set; }
	
        public GameModel()
		{
			Characters = new ObservableCollection<CharacterModel>();
			Monsters = new ObservableCollection<MonsterModel>();
            battleModel = new VBattleModel();
            this.dataAccess1= new GameDataAccess();


			// Build level system
			leveling = new List<int>();
			leveling.Add(1); // level + 1
			leveling.Add(2); // STR +2
			leveling.Add(1); // DEX +1
			leveling.Add(1); // SPD +1
			leveling.Add(4); // HP +4

			experience = new Dictionary<int, int>();
			buildEXPChart();
		}

        public void Initialize()
        {
            // Check DB
            // If record exists, load the DB
            if (false)
            {
                // Load the DB
            }
			// IF record doesn't exist, start a new Game
			else
            {
                Restart();   
            }
        }

        public void Restart()
        {
            // Reset Stat
            Gold = 0;
            BattleTotal = 0;
            BattleVictory = 0;
            MonsterKill = 0;

            // Initialize Char (Start with one character)
            Characters.Clear();
			AddCharToParty(); 
			AddCharToParty();   // Start with two

            // Initialize Monster
            dataAccess1.DeleteAllMonsters();
			Monsters.Clear();
			dataAccess1.SaveMonster(new MonsterModel(new CreatureModel("Alien", 1, 4, 5, 20, 6, "m_alien.png"), 20, "Beast"));
            dataAccess1.SaveMonster(new MonsterModel(new CreatureModel("Bird", 2, 4, 5, 25, 10, "m_bird.png"), 20, "Animal"));
            dataAccess1.SaveMonster(new MonsterModel(new CreatureModel("Bug", 3, 4, 5, 20, 3, "m_bug.png"), 40, "Insect"));
            dataAccess1.SaveMonster(new MonsterModel(new CreatureModel("Dru", 4, 4, 5, 25, 5, "m_dru.png"), 40, "Human"));
            dataAccess1.SaveMonster(new MonsterModel(new CreatureModel("Fox", 5, 4, 5, 25, 6, "m_fox.png"), 60, "Animal"));
            dataAccess1.SaveMonster(new MonsterModel(new CreatureModel("Ghost", 6, 4, 5, 25, 10, "m_ghost.png"), 60, "Spirit"));
            dataAccess1.SaveMonster(new MonsterModel(new CreatureModel("OneEyed", 7, 4, 5, 20, 5, "m_oneeyed.png"), 80, "Beast"));
            dataAccess1.SaveMonster(new MonsterModel(new CreatureModel("Pen", 8, 4, 5, 20, 3, "m_pen.png"), 80, "Animal"));
            dataAccess1.SaveMonster(new MonsterModel(new CreatureModel("Spy", 9, 4, 5, 25, 8, "m_spy.png"), 100, "Human"));
            dataAccess1.SaveMonster(new MonsterModel(new CreatureModel("Wizard", 10, 4, 5, 20, 7, "m_wiz.png"), 100, "Human"));
          //  ObservableCollection<MonsterModel> x = new ObservableCollection<MonsterModel>(enumerable);
            Monsters =   new ObservableCollection<MonsterModel> (dataAccess1.GetMonsters());
		}

        public void AddCharToParty()
        {
            switch (Characters.Count)
            {
	            case 0:
					Characters.Add(new CharacterModel(new CreatureModel("Warrior", 3, 10, 10, 20, 7, "c_warrior.png"), 0, null));
	                break;
				case 1:
					Characters.Add(new CharacterModel(new CreatureModel("Wizard", 3, 10, 10, 20, 7, "c_wizard.png"), 0, null));
					break;
				case 2:
					Characters.Add(new CharacterModel(new CreatureModel("Dwarf", 3, 10, 10, 20, 7, "c_dwarf.png"), 0, null));
					break;
				case 3:
					Characters.Add(new CharacterModel(new CreatureModel("Paladin", 3, 10, 10, 20, 7, "c_paladin.png"), 0, null));
					break;

			}
		}

		private void buildEXPChart()
		{
			this.experience.Add(1, 0);
			this.experience.Add(2, 7);
			this.experience.Add(3, 23);
			this.experience.Add(4, 10);
			this.experience.Add(5, 110);
			this.experience.Add(6, 220);
			this.experience.Add(7, 450);
			this.experience.Add(8, 800);
			this.experience.Add(9, 1300);
			this.experience.Add(10, 2000);
			this.experience.Add(11, 2900);
			this.experience.Add(12, 4000);
			this.experience.Add(13, 5500);
			this.experience.Add(14, 7500);
			this.experience.Add(15, 0000);
		}

		public int GetExperience(int level)
		{
			return experience[level];
		}
	}
}
