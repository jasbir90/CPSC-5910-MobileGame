using System;
using System.Collections.Generic;

namespace CadmusDND
{
	public class DiceController
	{
		private List<DiceModel> dice;
		public DiceController()
		{
			dice = new List<DiceModel>
			{
                // Create 1d4
                new DiceModel(4),
                // Create 1d6
                new DiceModel(6),
                // Create 1d8
                new DiceModel(8),
                // Create 1d10
                new DiceModel(10),
                // Create 1d12
                new DiceModel(12)
			};
		}

		public int DiceRoll(int quantity, int type)
		{
			int total = 0;
			for (int i = 0; i < quantity; i++)
			{
				switch (type)
				{
					case 4:
						total = total + dice[0].Roll;
						break;
					case 6:
						total = total + dice[1].Roll;
						break;
					case 8:
						total = total + dice[2].Roll;
						break;
					case 10:
						total = total + dice[3].Roll;
						break;
					case 12:
						total = total + dice[4].Roll;
						break;
					default:
						total = total + 0;
						break;
				}
			}
			return total;
		}
	}
}