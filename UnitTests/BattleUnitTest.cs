/*using System;
using System.IO;
using System.Linq;
using NUnit.Framework;
using CadmusDND;
using System.Collections.Generic;

namespace UnitTests
{
	public class BattleUnitTest
	{
		public BattleUnitTest() { }
		[SetUp]
		public void BeforeEachTest() { }
		//Tests Battle Model
		[Test]
		public void BattleIsOverMustBeFalseWhenBattleObjectIsCreated()
		{
			//Creating Character Test List
			CreatureModel testCreature1 = new CreatureModel("Cad", 1, 4, 5, 4, 5, "");
			ItemModel testItem1 = new ItemModel("Weapon", "Sword", "Strength", 20);
			CharacterModel testCharacter1 = new CharacterModel(testCreature1, 5, testItem1);
			CreatureModel testCreature2 = new CreatureModel("Cad", 1, 5, 5, 3, 5, "");
			ItemModel testItem2 = new ItemModel("Weapon", "FlamingOil", "Strength", 30);
			CharacterModel testCharacter2 = new CharacterModel(testCreature2, 5, testItem2);
			List<CharacterModel> characterTestList = new List<CharacterModel>();
			characterTestList.Add(testCharacter1);
			characterTestList.Add(testCharacter2);
			//Creating Monster Test List
			CreatureModel monsterTestCreature1 = new CreatureModel("Antman", 1, 4, 5, 4, 5, "");
			MonsterModel testMonster1 = new MonsterModel(monsterTestCreature1, 40, "Beast");
			CreatureModel monsterTestCreature2 = new CreatureModel("Dragon", 1, 5, 5, 3, 5, "");
			MonsterModel testMonster2 = new MonsterModel(monsterTestCreature1, 40, "Beast");
			List<MonsterModel> monsterTestList = new List<MonsterModel>();
			monsterTestList.Add(testMonster1);
			monsterTestList.Add(testMonster2);

			BattleModel testBattle = new BattleModel();
			Assert.IsFalse(testBattle.State, "IsOver should be false in the start of the battle");
		}

		[Test]
		public void BattleIsOverMustBeTrueWhenSetToTrue()
		{
			BattleModel testBattle = new BattleModel();
			testBattle.State = true;
			Assert.IsTrue(testBattle.State, "IsOver should be true when the battle ends");
		}
		//Tests for DamageRange() Method
		[Test]
		public void DamageRangeMustBe4WhenCreatureStrengthIsLessThan10()
		{
			BattleController testBattle = new BattleController();
			DiceController testDice = new DiceController();
			CreatureModel testCreature = new CreatureModel("Cad", 1, 4, 5, 4, 5, "");
			testCreature.Strength = 9;
			Assert.IsTrue(testBattle.DamageRange(testCreature) == 4, "Damage Range should be 4 when creature strength is less than 10");
		}

		[Test]
		public void DamageRangeMustNotBe4WhenCreatureStrengthIsGreaterThan10()
		{
			BattleController testBattle = new BattleController();
			DiceController testDice = new DiceController();
			CreatureModel testCreature = new CreatureModel("Cad", 1, 4, 5, 4, 5, "");
			testCreature.Strength = 11;
			Assert.IsFalse(testBattle.DamageRange(testCreature) == 4, "Damage Range should not be 4 when creature strength is greater than 10");
		}
		[Test]
		public void DamageRangeMustBe6WhenCreatureStrengthIsBetween10And14()
		{
			BattleController testBattle = new BattleController();
			DiceController testDice = new DiceController();
			CreatureModel testCreature = new CreatureModel("Cad", 1, 4, 5, 4, 5, "");
			testCreature.Strength = 10;
			Assert.IsTrue(testBattle.DamageRange(testCreature) == 6, "Damage Range should be 6 when creature strength is between 10 and 14 inclusive");
		}

		[Test]
		public void DamageRangeMustNotBe6WhenCreatureStrengthIsNotBetween10And14()
		{
			BattleController testBattle = new BattleController();
			DiceController testDice = new DiceController();
			CreatureModel testCreature = new CreatureModel("Cad", 1, 4, 5, 4, 5, "");
			testCreature.Strength = 9;
			Assert.IsFalse(testBattle.DamageRange(testCreature) == 6, "Damage Range should not be 6 when creature strength is not between 10 and 14");
		}
		[Test]
		public void DamageRangeMustBe8WhenCreatureStrengthIsBetween15And19()
		{
			BattleController testBattle = new BattleController();
			DiceController testDice = new DiceController();
			CreatureModel testCreature = new CreatureModel("Cad", 1, 4, 5, 4, 5, "");
			testCreature.Strength = 15;
			Assert.IsTrue(testBattle.DamageRange(testCreature) == 8, "Damage Range should be 8 when creature strength is between 15 and 19 inclusive");
		}

		[Test]
		public void DamageRangeMustNotBe8WhenCreatureStrengthIsNotBetween15And19()
		{
			BattleController testBattle = new BattleController();
			DiceController testDice = new DiceController();
			CreatureModel testCreature = new CreatureModel("Cad", 1, 4, 5, 4, 5, "");
			testCreature.Strength = 10;
			Assert.IsFalse(testBattle.DamageRange(testCreature) == 8, "Damage Range should not be 8 when creature strength is not between 15 and 19");
		}
		[Test]
		public void DamageRangeMustBe10WhenCreatureStrengthIsBetween20And24()
		{
			BattleController testBattle = new BattleController();
			DiceController testDice = new DiceController();
			CreatureModel testCreature = new CreatureModel("Cad", 1, 4, 5, 4, 5, "");
			testCreature.Strength = 20;
			Assert.IsTrue(testBattle.DamageRange(testCreature) == 10, "Damage Range should be 10 when creature strength is between 20 and 24 inclusive");
		}

		[Test]
		public void DamageRangeMustNotBe10WhenCreatureStrengthIsNotBetween20And24()
		{
			BattleController testBattle = new BattleController();
			DiceController testDice = new DiceController();
			CreatureModel testCreature = new CreatureModel("Cad", 1, 4, 5, 4, 5, "");
			testCreature.Strength = 25;
			Assert.IsFalse(testBattle.DamageRange(testCreature) == 10, "Damage Range should not be 10 when creature strength is not between 20 and 24");
		}
		[Test]
		public void DamageRangeMustBe12WhenCreatureStrengthIsGreaterThan24()
		{
			BattleController testBattle = new BattleController();
			DiceController testDice = new DiceController();
			CreatureModel testCreature = new CreatureModel("Cad", 1, 4, 5, 4, 5, "");
			testCreature.Strength = 25;
			Assert.IsTrue(testBattle.DamageRange(testCreature) == 12, "Damage Range should be 12 when creature strength is greater than 24");
		}
		[Test]
		public void DamageRangeMustNotBe12WhenCreatureStrengthIsLessThan25()
		{
			BattleController testBattle = new BattleController();
			DiceController testDice = new DiceController();
			CreatureModel testCreature = new CreatureModel("Cad", 1, 4, 5, 4, 5, "");
			testCreature.Strength = 24;
			Assert.IsFalse(testBattle.DamageRange(testCreature) == 12, "Damage Range should not be 12 when creature strength is lesser than 24");
		}
		//Unit tests for BattleController Method GetDamage(). Damage has to be greater than 0 when strength of character 1 > strength of character 2

		[Test]
		public void GetDamageMustNotReturn0IfStrengthOfCreature1IsGreater()
		{
			BattleController testBattle = new BattleController();
			DiceController testDice = new DiceController();
			CreatureModel testCreature1 = new CreatureModel("Cad", 1, 4, 8, 4, 5, "");
			CreatureModel testCreature2 = new CreatureModel("Antman", 1, 6, 3, 7, 6, "");
			Assert.IsFalse(testBattle.GetDamage(testCreature1, testCreature2) == 0, "Damage must not be zero when strength of Creature1 is more than creature 2");
		}

		[Test]
		public void GetDamageMustBeGreaterThan0IfStrengthOfCreature1IsGreater()
		{
			BattleController testBattle = new BattleController();
			DiceController testDice = new DiceController();
			CreatureModel testCreature1 = new CreatureModel("Cad", 1, 4, 8, 4, 5, "");
			CreatureModel testCreature2 = new CreatureModel("Antman", 1, 6, 3, 7, 6, "");
			Assert.IsTrue(testBattle.GetDamage(testCreature1, testCreature2) > 0, "Damage must not be zero when strength of Creature1 is more than creature 2");
		}

		//Unit tests for BattleController Method AddCharacter().  
		[Test]
		public void CountOfCharacterCombatantsShouldBeMoreThan0OnAddingACharacter()
		{
			BattleController testBattleController = new BattleController();
			BattleModel testBattleModel = new BattleModel();
			CreatureModel testCreature1 = new CreatureModel("Cad", 1, 4, 5, 4, 5, "");
			ItemModel testItem1 = new ItemModel("Weapon", "Sword", "Strength", 20);
			CharacterModel testCharacter1 = new CharacterModel(testCreature1, 5, testItem1);
			int initialCount = testBattleModel.CharacterCombatants.Count();
			testBattleController.AddCharacter(testCharacter1, testBattleModel);
			Assert.IsTrue(testBattleModel.CharacterCombatants.Count() > 0, "Count of character combatants must be greate than zero on addition of 1 character");
		}

		[Test]
		public void CountOfCharacterCombatantsShouldBeMoreThanInitialCountOnAddingACharacter()
		{
			BattleController testBattleController = new BattleController();
			BattleModel testBattleModel = new BattleModel();
			CreatureModel testCreature1 = new CreatureModel("Cad", 1, 4, 5, 4, 5, "");
			ItemModel testItem1 = new ItemModel("Weapon", "Sword", "Strength", 20);
			CharacterModel testCharacter1 = new CharacterModel(testCreature1, 5, testItem1);
			int initialCount = testBattleModel.CharacterCombatants.Count();
			testBattleController.AddCharacter(testCharacter1, testBattleModel);
			Assert.IsTrue(testBattleModel.CharacterCombatants.Count() > initialCount, "Count of character combatants increase by 1 on addition of 1 character");

		}

		[Test]
		public void CountOfCharacterCombatantsMustNotBe0OnAddingACharacter()
		{
			BattleController testBattleController = new BattleController();
			BattleModel testBattleModel = new BattleModel();
			CreatureModel testCreature1 = new CreatureModel("Cad", 1, 4, 5, 4, 5, "");
			ItemModel testItem1 = new ItemModel("Weapon", "Sword", "Strength", 20);
			CharacterModel testCharacter1 = new CharacterModel(testCreature1, 5, testItem1);
			int initialCount = testBattleModel.CharacterCombatants.Count();
			testBattleController.AddCharacter(testCharacter1, testBattleModel);
			Assert.IsFalse(testBattleModel.CharacterCombatants.Count() == 0, "Count of character combatants cannot be 0 after addition of a character");

		}

		//Unit tests for BattleController Method AddMonster().  
		[Test]
		public void CountOfMonsterCombatantsShouldBeMoreThan0OnAddingAMonster()
		{
			BattleController testBattleController = new BattleController();
			BattleModel testBattleModel = new BattleModel();
			CreatureModel monsterTestCreature1 = new CreatureModel("Antman", 1, 4, 5, 4, 5, "");
			MonsterModel testMonster1 = new MonsterModel(monsterTestCreature1, 40, "Beast");
			int initialCount = testBattleModel.MonsterCombatants.Count();
			testBattleController.AddMonster(testMonster1, testBattleModel);
			Assert.IsTrue(testBattleModel.MonsterCombatants.Count() > 0, "Count of monster combatants must be greate than zero on addition of 1 monster");
		}

		[Test]
		public void CountOfMonsterCombatantsShouldBeMoreThanInitialCountOnAddingAMonster()
		{
			BattleController testBattleController = new BattleController();
			BattleModel testBattleModel = new BattleModel();
			CreatureModel monsterTestCreature1 = new CreatureModel("Antman", 1, 4, 5, 4, 5, "");
			MonsterModel testMonster1 = new MonsterModel(monsterTestCreature1, 40, "Beast");
			int initialCount = testBattleModel.MonsterCombatants.Count();
			testBattleController.AddMonster(testMonster1, testBattleModel);
			Assert.IsTrue(testBattleModel.MonsterCombatants.Count() > initialCount, "Count of monster combatants increase by 1 on addition of 1 monster");
		}

		[Test]
		public void CountOfMonsterCombatantsMustNotBe0OnAddingAMonster()
		{
			BattleController testBattleController = new BattleController();
			BattleModel testBattleModel = new BattleModel();
			CreatureModel monsterTestCreature1 = new CreatureModel("Antman", 1, 4, 5, 4, 5, "");
			MonsterModel testMonster1 = new MonsterModel(monsterTestCreature1, 40, "Beast");
			int initialCount = testBattleModel.MonsterCombatants.Count();
			testBattleController.AddMonster(testMonster1, testBattleModel);
			Assert.IsFalse(testBattleModel.MonsterCombatants.Count() == 0, "Count of monster combatants cannot be 0 after addition of a monster");
		}

		//Unit tests for BattleController Method Attack().  
		[Test]
		public void BattleWouldFinishWhenCharacterCombatantsCountIsZero()
		{
			BattleController testBattleController = new BattleController();
			BattleModel testBattleModel = new BattleModel();
			CreatureModel testCreature1 = new CreatureModel("Cad", 1, 4, 5, 4, 5, "");
			ItemModel testItem1 = new ItemModel("Weapon", "Sword", "Strength", 20);
			CharacterModel testCharacter1 = new CharacterModel(testCreature1, 5, testItem1);
			testBattleController.AddCharacter(testCharacter1, testBattleModel);
			testBattleModel.State = true;
			testBattleController.Attack(testBattleModel);
			Assert.IsTrue(testBattleModel.State, "Battle state must to be true since the character combatants count is 0 ");
		}
		[Test]
		public void BattleWouldFinishWhenMonsterCombatantsCountIsZero()
		{
			BattleController testBattleController = new BattleController();
			BattleModel testBattleModel = new BattleModel();
			CreatureModel monsterTestCreature1 = new CreatureModel("Antman", 1, 4, 5, 4, 5, "");
			MonsterModel testMonster1 = new MonsterModel(monsterTestCreature1, 40, "Beast");
			testBattleController.AddMonster(testMonster1, testBattleModel);
			testBattleModel.State = true;
			testBattleController.Attack(testBattleModel);
			Assert.IsTrue(testBattleModel.State, "Battle state must to be true since the monster combatants count is 0 ");
		}


	}
}*/