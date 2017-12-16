using System;
using SQLite;
using System.ComponentModel;
namespace CadmusDND
{
    [Table("Monsters")]
	public class MonsterModel: CreatureModel, INotifyPropertyChanged
	{
		//attributes
        [PrimaryKey, AutoIncrement]
        public int monsterID { get; set; }
		private int rewardAmount;
		private string category;

		//constructor
        public MonsterModel(){}
		public MonsterModel(CreatureModel creature, int rewardAmount, string category)
            : base(creature.Name, creature.Level, creature.Strength, creature.Dexterity, creature.Health, creature.Speed, creature.Image)
		{
			this.rewardAmount = rewardAmount;
			this.category = category;

            UpdateText();
        }
		public int Reward
		{
			get { return rewardAmount;  }
			set { rewardAmount = value; }
		}
		public string Category
		{
			get { return category;  }
			set { category = value;  }
		}

		public override void UpdateText()
		{
			TextTitle = String.Format("{0} ({1}-{2})", Name, Level, Category);
			TextDesc = String.Format("STR: {0} DEX: {1} HP: {2} SPD: {3} REW: {4}", Strength, Dexterity, Health, Speed, Reward);
		}
        public event PropertyChangedEventHandler PropertyChanged;
    private void OnPropertyChanged(string propertyName)
    {
      this.PropertyChanged?.Invoke(this,
        new PropertyChangedEventArgs(propertyName));
    }
	}
}
