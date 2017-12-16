using System;
using Xamarin.Forms;
namespace CadmusDND
{
	public class MonsterController
	{
		//objects and variables
		private MonsterModel MonsterObj;

		public MonsterController()
		{
		}
		//Check if the monster is alive
		public bool isDead(MonsterModel MonsterObj)
		{
            if (MonsterObj.Health == 0)
                return true;
            	
			else return false;
		}
		// Give monster's reward after defeating it
		public int giveReward(MonsterModel MonsterObj)
		{
			if (isDead(MonsterObj))
				return MonsterObj.Reward;
			else return 0;
		}
	}
}
