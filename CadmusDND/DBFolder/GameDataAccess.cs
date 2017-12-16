using SQLite;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;
using System.Collections.ObjectModel;
using System;

namespace CadmusDND
{
    public class GameDataAccess
    {
    private SQLiteConnection database;
    private static object collisionLock = new object();
    public ObservableCollection<MonsterModel> Monsters { get; set; }
        public ObservableCollection<ItemModel> Items { get; set; }
    public GameDataAccess()
    {
      database =
        DependencyService.Get<IDatabaseConnection>().
        DbConnection();
      database.CreateTable<MonsterModel>();
            database.CreateTable<ItemModel>();
      this.Monsters =
        new ObservableCollection<MonsterModel>(database.Table<MonsterModel>());
			this.Items =
		new ObservableCollection<ItemModel>(database.Table<ItemModel>());
      // If the table is empty, initialize the collection
      if (!database.Table<MonsterModel>().Any())
      {
        AddNewMonster();
      }
			if (!database.Table<ItemModel>().Any())
			{
				AddNewItem();
			}
    }
    public void AddNewMonster()
    {
      this.Monsters.Add(new MonsterModel(new CreatureModel("Alien", 1, 4, 5, 20, 6, "m_alien.png"), 20, "Beast"));
    }
		public void AddNewItem()
		{
			this.Items.Add(new ItemModel("Weapon","Sword","Strength", 20,"SPPED +2", "jasbir",20,"","ATTAKARM"));
		}
    // Use LINQ to query and filter data
    public IEnumerable<MonsterModel> GetMonsters()
    {
      // Use locks to avoid database collitions
      lock(collisionLock)
      {
        var query = from mons in database.Table<MonsterModel>()
                    select mons;
        return query.AsEnumerable();
      }
    }
    public void SaveMonster(MonsterModel monsterInstance)
    {
      lock(collisionLock)
      {
        if (monsterInstance.monsterID != 0)
        {
          database.Update(monsterInstance);
         // return monsterInstance.Id;
        }
        else
        {
          database.Insert(monsterInstance);
          
        }
      }
    }
 
        //methods for ItemModel
    public void DeleteAllMonsters()
    {
      lock(collisionLock)
      {
        database.DropTable<MonsterModel>();
        database.CreateTable<MonsterModel>();
      }
            this.Monsters = null;
            this.Monsters = new ObservableCollection<MonsterModel>
        (database.Table<MonsterModel>());
    }

      

        public IEnumerable<ItemModel> GetItems()
		{
			// Use locks to avoid database collitions
			lock (collisionLock)
			{
				var query = from item in database.Table<ItemModel>()
							select item;
				return query.AsEnumerable();
			}
		}
		public void InsertItem(ItemModel itemInstance)
		{
			lock (collisionLock)
			{
					database.Insert(itemInstance);

			}
		}

		public void DeleteItem(ItemModel itemInstance)
		{
			lock (collisionLock)
			{
                database.Delete(itemInstance);

			}
		}

		public void UpdateItem(ItemModel itemInstance)
		{
			lock (collisionLock)
			{
                if (itemInstance.itemID != 0)
                {
                    database.Update(itemInstance);
                }
			}
		}

		public void DeleteAllItem()
		{
			lock (collisionLock)
			{
                database.DropTable<ItemModel>();
				database.CreateTable<ItemModel>();
			}
            this.Items = null;
            this.Items = new ObservableCollection<ItemModel>
		(database.Table<ItemModel>());
		}
	
  }
}