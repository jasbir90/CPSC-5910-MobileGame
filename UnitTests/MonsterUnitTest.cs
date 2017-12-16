using System;
using System.IO;
using System.Linq;
using NUnit.Framework;
//using Xamarin.UITest;
//using Xamarin.UITest.Queries;
using CadmusDND;

namespace UnitTests
{
public class MonsterUnitTest
	{
		public MonsterUnitTest() { }

		[SetUp]
		public void BeforeEachTest()
		{
		}

		//tests for monster's Strength. Monster's strength should be positive and max is 50
		[Test]
		public void MonsterStrengthMustBeGreaterThanZero()
		{
			CreatureModel monsterTestCreature = new CreatureModel("Antman", 1, 4, 5, 4, 5, "");
			MonsterModel testMonster = new MonsterModel(monsterTestCreature, 40, "Beast");
			Assert.IsTrue(testMonster.Strength > 0, "Monster strength must be greater than zero ");
		}
		[Test]
		public void MonsterStrengthIsEqualTo4()
		{
			CreatureModel testCreature = new CreatureModel("Antman", 1, 4, 5, 4, 5, "");
			MonsterModel testMonster = new MonsterModel(testCreature, 40, "Beast");
			testMonster.Strength = 4;
			Assert.IsTrue(testMonster.Strength == 4, "Monster strength must be equal to 4 ");
		}
		[Test]
		public void MonsterStrengthShouldNotBeLessThan1()
		{
			CreatureModel testCreature = new CreatureModel("Antman", 1, 4, 5, 4, 5, "");
			MonsterModel testMonster = new MonsterModel(testCreature, 40, "Beast");
			testMonster.Strength = 0;
			Assert.IsFalse(testMonster.Strength >= 1, "Monster strength must not be less than 1 ");
		}
		[Test]
		public void MonsterStrengthShouldBeLessThan50()
		{
			CreatureModel testCreature = new CreatureModel("Antman", 1, 4, 5, 4, 5, "");
			MonsterModel testMonster = new MonsterModel(testCreature, 40, "Beast");
			testMonster.Strength = 48;
			Assert.IsTrue(testMonster.Strength < 50, "Monster strength must be max 50");
		}
		[Test]
		public void MonsterStrengthShouldNotBeGreaterThan50()
		{
			CreatureModel testCreature = new CreatureModel("Antman", 1, 4, 5, 4, 5, "");
			MonsterModel testMonster = new MonsterModel(testCreature, 40, "Beast");
			testMonster.Strength = 52;
			Assert.IsFalse(testMonster.Strength <= 50, "Monster strength should not be greater than 50");
		}

		//tests for monster's dexterity. Monster's dexterity should be greater than 0 and max 50
		[Test]
		public void MonsterDexterityMustBeGreaterThanZero()
		{
			CreatureModel monsterTestCreature = new CreatureModel("Antman", 1, 4, 5, 4, 5, "");
			MonsterModel testMonster = new MonsterModel(monsterTestCreature, 40, "Beast");
			Assert.IsTrue(testMonster.Dexterity > 0, "Monster dexterity must be greater than zero ");
		}
		[Test]
		public void MonsterDexterityIsEqualTo4()
		{
			CreatureModel monsterTestCreature = new CreatureModel("Antman", 1, 4, 5, 4, 5, "");
			MonsterModel testMonster = new MonsterModel(monsterTestCreature, 40, "Beast");
			testMonster.Dexterity = 4;
			Assert.IsTrue(testMonster.Dexterity == 4, "Monster dexterity must equal to 4");
		}
		[Test]
		public void MonsterDexterityShouldNotBeLessThan1()
		{
			CreatureModel testCreature = new CreatureModel("Antman", 1, 4, 5, 4, 5, "");
			MonsterModel testMonster = new MonsterModel(testCreature, 40, "Beast");
			testMonster.Dexterity = 0;
			Assert.IsFalse(testMonster.Dexterity >= 1, "Monster dexterity must not be less than 1 ");
		}
		[Test]
		public void MonsterDexterityShouldBeLessThan50()
		{
			CreatureModel testCreature = new CreatureModel("Antman", 1, 4, 5, 4, 5, "");
			MonsterModel testMonster = new MonsterModel(testCreature, 40, "Beast");
			testMonster.Dexterity = 48;
			Assert.IsTrue(testMonster.Dexterity < 50, "Monster dexterity must be max 50");
		}

		[Test]
		public void MonsterDexterityShouldNotBeGreaterThan50()
		{
			CreatureModel testCreature = new CreatureModel("Antman", 1, 4, 5, 4, 5, "");
			MonsterModel testMonster = new MonsterModel(testCreature, 40, "Beast");
			testMonster.Dexterity = 52;
			Assert.IsFalse(testMonster.Dexterity <= 50, "Monster dexterity should not be greater than 50");
		}

		//tests for monster's health. Monster's health should be greater or equal to 0 and max 50
		[Test]
		public void MonsterHealthMustBeGreaterThanZero()
		{
			CreatureModel monsterTestCreature = new CreatureModel("Antman", 1, 4, 5, 4, 5, "");
			MonsterModel testMonster = new MonsterModel(monsterTestCreature, 40, "Beast");
			testMonster.Health = 10;
			Assert.IsTrue(testMonster.Health >= 0, "Monster health must be greater or equal to zero ");
		}
		[Test]
		public void MonsterHealthIsEqualTo4()
		{
			CreatureModel monsterTestCreature = new CreatureModel("Antman", 1, 4, 5, 4, 5, "");
			MonsterModel testMonster = new MonsterModel(monsterTestCreature, 40, "Beast");
			testMonster.Health = 4;
			Assert.IsTrue(testMonster.Health == 4, "Monster health must equal to 4");
		}
		[Test]
		public void MonsterHealthShouldNotBeLessThan0()
		{
			CreatureModel testCreature = new CreatureModel("Antman", 1, 4, 5, 4, 5, "");
			MonsterModel testMonster = new MonsterModel(testCreature, 40, "Beast");
			testMonster.Health = -1;
			Assert.IsFalse(testMonster.Health >= 0, "Monster health must not be less than 1 ");
		}
		[Test]
		public void MonsterHealthShouldBeLessThan50()
		{
			CreatureModel testCreature = new CreatureModel("Antman", 1, 4, 5, 4, 5, "");
			MonsterModel testMonster = new MonsterModel(testCreature, 40, "Beast");
			testMonster.Health = 48;
			Assert.IsTrue(testMonster.Health < 50, "Monster health must be max 50");
		}
		[Test]
		public void MonsterHealthShouldNotBeGreaterThan50()
		{
			CreatureModel testCreature = new CreatureModel("Antman", 1, 4, 5, 4, 5, "");
			MonsterModel testMonster = new MonsterModel(testCreature, 40, "Beast");
			testMonster.Health = 52;
			Assert.IsFalse(testMonster.Health <= 50, "Monster health should not be greater than 50");
		}

		//tests for monster's speed. Monster's speed should be greater than 0 and max 50
		[Test]
		public void MonsterSpeedMustBeGreaterThanZero()
		{
			CreatureModel monsterTestCreature = new CreatureModel("Antman", 1, 4, 5, 4, 5, "");
			MonsterModel testMonster = new MonsterModel(monsterTestCreature, 40, "Beast");
			Assert.IsTrue(testMonster.Speed > 0, "Monster speed must be greater than zero ");
		}
		[Test]
		public void MonsterSpeedIsEqualTo4()
		{
			CreatureModel monsterTestCreature = new CreatureModel("Antman", 1, 4, 5, 4, 5, "");
			MonsterModel testMonster = new MonsterModel(monsterTestCreature, 40, "Beast");
			testMonster.Speed = 4;
			Assert.IsTrue(testMonster.Speed == 4, "Monster speed must equal to 4");
		}
		[Test]
		public void MonsterSpeedShouldNotBeLessThan1()
		{
			CreatureModel testCreature = new CreatureModel("Antman", 1, 4, 5, 4, 5, "");
			MonsterModel testMonster = new MonsterModel(testCreature, 40, "Beast");
			testMonster.Speed = 0;
			Assert.IsFalse(testMonster.Speed >= 1, "Monster speed must not be less than 1 ");
		}
		[Test]
		public void MonsterSpeedShouldBeLessThan50()
		{
			CreatureModel testCreature = new CreatureModel("Antman", 1, 4, 5, 4, 5, "");
			MonsterModel testMonster = new MonsterModel(testCreature, 40, "Beast");
			testMonster.Speed = 48;
			Assert.IsTrue(testMonster.Speed < 50, "Monster speed must be max 50");
		}

		[Test]
		public void MonsterSpeedShouldNotBeGreaterThan50()
		{
			CreatureModel testCreature = new CreatureModel("Antman", 1, 4, 5, 4, 5, "");
			MonsterModel testMonster = new MonsterModel(testCreature, 40, "Beast");
			testMonster.Speed = 52;
			Assert.IsFalse(testMonster.Speed <= 50, "Monster speed should not be greater than 50");
		}

		//tests for monster's reward. Monster's reward should be greater than 0 and max 50
		[Test]
		public void MonsterRewardMustBeGreaterThanZero()
		{
			CreatureModel monsterTestCreature = new CreatureModel("Antman", 1, 4, 5, 4, 5, "");
			MonsterModel testMonster = new MonsterModel(monsterTestCreature, 40, "Beast");
			Assert.IsTrue(testMonster.Reward > 0, "Monster reward must be greater than zero ");
		}
		[Test]
		public void MonsterRewardIsEqualTo4()
		{
			CreatureModel monsterTestCreature = new CreatureModel("Antman", 1, 4, 5, 4, 5, "");
			MonsterModel testMonster = new MonsterModel(monsterTestCreature, 40, "Beast");
			testMonster.Reward = 4;
			Assert.IsTrue(testMonster.Reward == 4, "Monster reward must equal to 4");
		}
		[Test]
		public void MonsterRewardShouldNotBeLessThan1()
		{
			CreatureModel testCreature = new CreatureModel("Antman", 1, 4, 5, 4, 5, "");
			MonsterModel testMonster = new MonsterModel(testCreature, 40, "Beast");
			testMonster.Reward = 0;
			Assert.IsFalse(testMonster.Reward >= 1, "Monster reward must not be less than 1 ");
		}
		[Test]
		public void MonsterRewardShouldBeLessThan50()
		{
			CreatureModel testCreature = new CreatureModel("Antman", 1, 4, 5, 4, 5, "");
			MonsterModel testMonster = new MonsterModel(testCreature, 40, "Beast");
			testMonster.Reward = 48;
			Assert.IsTrue(testMonster.Reward < 50, "Monster reward must be max 50");
		}
		[Test]
		public void MonsterRewardShouldNotBeGreaterThan50()
		{
			CreatureModel testCreature = new CreatureModel("Antman", 1, 4, 5, 4, 5, "");
			MonsterModel testMonster = new MonsterModel(testCreature, 40, "Beast");
			testMonster.Reward = 52;
			Assert.IsFalse(testMonster.Reward <= 50, "Monster reward should not be greater than 50");
		}

		//tests for monster's category. Monster category should not be null
		[Test]
		public void MonsterCategoryMustEqualToBeast()
		{
			CreatureModel testCreature = new CreatureModel("Antman", 1, 4, 5, 4, 5, "");
			MonsterModel testMonster = new MonsterModel(testCreature, 40, "Beast");
			Assert.IsTrue(testMonster.Category == "Beast", "Monster category must be equal to Beast");
		}

		[Test]
		public void MonsterCategoryMustNotBeNull()
		{
			CreatureModel testCreature = new CreatureModel("Antman", 1, 4, 5, 4, 5, "");
			MonsterModel testMonster = new MonsterModel(testCreature, 40, "Beast");
			testMonster.Category = null;
			Assert.IsFalse(testMonster.Category != null, "Monster category is NULL");
		}

		//tests to make sure a monster object is not null 
		[Test]
		public void MonsterMustNotBeNull()
		{
			CreatureModel testCreature = new CreatureModel("Antman", 1, 4, 5, 4, 5, "");
			MonsterModel testMonster = new MonsterModel(testCreature, 40, "Beast");
			Assert.NotNull(testMonster, "Monster object must not be null");
		}

		//tests monster controller isDead functon. Monster should return true if health is 0.
		[Test]
		public void MonsterIsDeadWhenHealthIs0()
		{
			CreatureModel testCreature = new CreatureModel("Antman", 1, 4, 5, 4, 5, "");
			MonsterModel testMonster = new MonsterModel(testCreature, 40, "Beast");
			testMonster.Health = 0;
			MonsterController testMonsterController = new MonsterController();
			Assert.IsTrue(testMonsterController.isDead(testMonster), "Monster is dead");
		}
		//tests monster controller isDead functon. Monster isDead should return false if health is greater than 0
		[Test]
		public void MonsterIsAliveWhenHealthIsGreaterThan0()
		{
			CreatureModel testCreature = new CreatureModel("Antman", 1, 4, 5, 4, 5, "");
			MonsterModel testMonster = new MonsterModel(testCreature, 40, "Beast");
			testMonster.Health = 10;
			MonsterController testMonsterController = new MonsterController();
			Assert.IsFalse(testMonsterController.isDead(testMonster), "Monster is alive");
		}

		//tests monster controller giveReward function. Monster gives away 10 points when it is dead (health = 0)
		[Test]
		public void MonsterGivesAwayRewards()
		{
			CreatureModel testCreature = new CreatureModel("Antman", 1, 4, 5, 4, 5, "");
			MonsterModel testMonster = new MonsterModel(testCreature, 40, "Beast");
			testMonster.Reward = 10;
			testMonster.Health = 0;
			MonsterController testMonsterController = new MonsterController();
			Assert.IsTrue(testMonsterController.giveReward(testMonster) == 10, "Monster is dead therefore the rewards should give Character 10 points");
		}

		//tests monster controller giveReward function. Monster does not give away 10 points when it is alive (health > 0)
		[Test]
		public void MonsterDoesNotGiveAwayRewards()
		{
			CreatureModel testCreature = new CreatureModel("Antman", 1, 4, 5, 4, 5, "");
			MonsterModel testMonster = new MonsterModel(testCreature, 40, "Beast");
			testMonster.Reward = 10;
			testMonster.Health = 20;
			MonsterController testMonsterController = new MonsterController();
			Assert.IsTrue(testMonsterController.giveReward(testMonster) == 0, "Monster still has rewards 10 because it has health 20");
		}
	}
}
