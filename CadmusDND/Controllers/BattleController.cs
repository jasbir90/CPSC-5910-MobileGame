﻿using System;
using System.Collections.Generic;
using System.Linq;
namespace CadmusDND
{
	public class BattleController
	{
		private BattleModel battleObj;
		private DiceController dice;
        private Random rand = new Random();
        private bool CRITICALHIT;

		public BattleController()
		{
			battleObj = new BattleModel();
			dice = new DiceController();
            CRITICALHIT = false;
		}

		// Determine attack range
		// This method determines which set
		// of dice to use for damage
		// calculation based on creature strength
		public int DamageRange(CreatureModel creature)
		{
			int strength = creature.Strength;
			if (strength < 10)
			{
				return 4;
			}
			else if (strength < 15)
			{
				return 6;
			}
			else if (strength < 20)
			{
				return 8;
			}
			else if (strength < 25)
			{
				return 10;
			}
			else { return 12; }
		}

		// Initiate an attack sequence
		public void Attack(BattleModel battleObj)
		{
			if (!battleObj.State)
			{
				// Get creature with the highest strength first
				CreatureModel creature1;
				CreatureModel creature2;

				bool isMonster = false;

				if (battleObj.MonsterCombatants[0].Strength > battleObj.CharacterCombatants[0].Strength)
				{
					creature1 = (CreatureModel)battleObj.MonsterCombatants[0];
					creature2 = (CreatureModel)battleObj.CharacterCombatants[0];
					isMonster = true;
				}

				else
				{
					creature1 = (CreatureModel)battleObj.CharacterCombatants[0];
					creature2 = (CreatureModel)battleObj.MonsterCombatants[0];
				}

				// Get damage
				int damage = GetDamage(creature1, creature2);

				// Apply damage
				creature2.Health = creature2.Health - damage;

				// Check if opponent is still alive
				if (creature2.isDead)
				{
					if (creature2 is CharacterModel)
					{
						battleObj.CharacterCombatants.RemoveAt(0);
					}
					else { battleObj.MonsterCombatants.RemoveAt(0); }
				}

				// Get the next combatant
				if (isMonster)
				{
					List<CreatureModel> list = new List<CreatureModel>();
					list.Add((MonsterModel)creature1);
					Cycle(list);
				}
				else
				{
					List<CreatureModel> list = new List<CreatureModel>();
					list.Add((CharacterModel)creature1);
					Cycle(list);
				}

				// Check if there are still opponents
				// If not, battle is over
				if (battleObj.CharacterCombatants.Count() == 0 || battleObj.MonsterCombatants.Count() == 0)
				{
					battleObj.State = true;
				}
			}
		}

		// Determine hit or miss
		// Calculate chance by determining the difference in levels
		// between the character and monster and multiplying by 10.
		// Differences get added to 100.
		// Example, Character is level 1 and Monster is level 3.
		// Character would have an 80% chance of hitting the monster.
		// Monster would have 100% chance of hitting the character.
		// Being lower level than your opponent hurts your chances.
		public bool Hit(CreatureModel creature1, CreatureModel creature2)
		{
			int difference = (creature1.Level - creature2.Level) * 10;
			if (difference < 0) { difference = 100 + difference; }
			else { difference = 100; }

			Random rand = new Random();
			if (rand.Next(0, difference + 1) < difference)
			{
				return true;
			}

			return false;
		}

		// Calculate damage
		public int GetDamage(CreatureModel creature1, CreatureModel creature2)
		{
			int damage = 0;

			if (Hit(creature1, creature2))
			{
                // Get damage range first
				/*int range = DamageRange((creature1));
				damage = dice.DiceRoll(1, range);
                // Check for critical miss
                if(damage == 1)
                {
                    return 1;
                }
                // Check for critical hit
                if(damage == range) 
                {
                    this.CRITICALHIT = true;
                    damage = damage * 2;
                }*/
			}

            return damage *  (rand.Next(4) + 1) + rand.Next(6); // For balance;

		// Prepare for next round
		public void Cycle(List<CreatureModel> list)
		{
			while (!battleObj.State)
			{
				if (list[0] is CharacterModel && battleObj.CharacterCombatants.Count > 1)
				{
					CharacterModel first = battleObj.CharacterCombatants[0];
					battleObj.CharacterCombatants.RemoveAt(0);
					battleObj.CharacterCombatants.Add(first);
				}

				if (list[0] is MonsterModel && battleObj.MonsterCombatants.Count > 1)
				{
					MonsterModel first = battleObj.MonsterCombatants[0];
					battleObj.MonsterCombatants.RemoveAt(0);
					battleObj.MonsterCombatants.Add(first);
				}
			}
		}

		// Add Characters to the battle collection
		// Also sorts descending by strength
		public void AddCharacter(CharacterModel character, BattleModel battleObj)
		{
			battleObj.CharacterCombatants.Add((CharacterModel)character);
			if (battleObj.CharacterCombatants.Count() > 1)
			{
				battleObj.CharacterCombatants = battleObj.CharacterCombatants.OrderByDescending(CharacterModel => CharacterModel.Strength).ToList();
			}
		}

		public void AddMonster(MonsterModel monster,BattleModel battleObj)
		{
			battleObj.MonsterCombatants.Add((MonsterModel)monster);
			if (battleObj.MonsterCombatants.Count() > 1)
			{
				battleObj.MonsterCombatants = battleObj.MonsterCombatants.OrderByDescending(CharacterModel => CharacterModel.Strength).ToList();
			}
		}

        public bool isCritical()
        {
            if (this.CRITICALHIT) { this.CRITICALHIT = false; return true; }
            else { return false; }
        }
	}
}