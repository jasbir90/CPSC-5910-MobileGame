/*using System;
using System.IO;
using System.Linq;
using NUnit.Framework;
//using Xamarin.UITest;
//using Xamarin.UITest.Queries;
using CadmusDND;

namespace UnitTests
{
public class CharacterUnitTest
	{
		public CharacterUnitTest() { }

		[SetUp]
		public void BeforeEachTest()
		{
			
		}

		//tests to verify Character's Name. Character name should not be null
		[Test]
		public void CharacterNameMustEqualToCad()
		{
			CreatureModel testCreature = new CreatureModel("Cad", 1, 4, 5, 4, 5, "");
			ItemModel testItem = new ItemModel("Weapon", "Sword", "Strength", 20);
			CharacterModel testCharacter = new CharacterModel(testCreature, 5, testItem);
			Assert.IsTrue(testCharacter.Name == "Cad", "Character Name must be equal to Cad");
		}

		[Test]
		public void CharacterNameMustNotBeNull()
		{
			CreatureModel testCreature = new CreatureModel("Cad", 1, 4, 5, 4, 5, "");
			ItemModel testItem = new ItemModel("Weapon", "Sword", "Strength", 20);
			CharacterModel testCharacter = new CharacterModel(testCreature, 5, testItem);
			testCharacter.Name = null;
			Assert.IsFalse(testCharacter.Name != null, "Character Name is NULL");
		}

		//tests for Character's Strength. Character strength should be positive
		[Test]
		public void CharacterStrengthMustBeGreaterThanZero()
		{
			
			CreatureModel testCreature= new CreatureModel("Cad", 1, 4, 5, 4, 5, "");
			ItemModel testItem = new ItemModel("Weapon", "Sword", "Strength", 20);
			CharacterModel testCharacter=new CharacterModel(testCreature, 5,testItem);
			Assert.IsTrue(testCharacter.Strength > 0, "Character Strength must be greater than zero ");
		}

		[Test]
		public void CharacterStrengthIsEqualTo4()
		{
			CreatureModel testCreature = new CreatureModel("Cad", 1, 4, 5, 4, 5, "");
			ItemModel testItem = new ItemModel("Weapon", "Sword", "Strength", 20);
			CharacterModel testCharacter = new CharacterModel(testCreature, 5, testItem);
			testCharacter.Strength = 4;
			Assert.IsTrue(testCharacter.Strength ==4, "Character Strength must be equal to 4 ");
		}

		[Test]
		public void CharacterStrengthShouldNotBeLessThan1()
		{
			CreatureModel testCreature = new CreatureModel("Cad", 1, 4, 5, 4, 5, "");
			ItemModel testItem = new ItemModel("Weapon", "Sword", "Strength", 20);
			CharacterModel testCharacter = new CharacterModel(testCreature, 5, testItem);
			testCharacter.Strength = 0;
			Assert.IsFalse(testCharacter.Strength >=1 , "Character Strength must not be lesser than 1 ");
		}
		[Test]
		public void CharacterStrengthShouldBeLessThan50()
		{
			CreatureModel testCreature = new CreatureModel("Cad", 1, 4, 5, 4, 5, "");
			ItemModel testItem = new ItemModel("Weapon", "Sword", "Strength", 20);
			CharacterModel testCharacter = new CharacterModel(testCreature, 5, testItem);
			testCharacter.Strength = 48;
			Assert.IsTrue(testCharacter.Strength < 50, "Character strength must be max 50");
		}
		[Test]
		public void CharacterStrengthShouldNotBeGreaterThan50()
		{
			CreatureModel testCreature = new CreatureModel("Cad", 1, 4, 5, 4, 5, "");
			ItemModel testItem = new ItemModel("Weapon", "Sword", "Strength", 20);
			CharacterModel testCharacter = new CharacterModel(testCreature, 5, testItem);
			testCharacter.Strength = 52;
			Assert.IsFalse(testCharacter.Strength <= 50, "Character strength should not be greater than 50");
		}

		//tests for Character's Dexterity. Character Dexterity should be positive
		[Test]
		public void CharacterDexterityMustBeGreaterThanZero()
		{

			CreatureModel testCreature = new CreatureModel("Cad", 1, 4, 5, 4, 5, "");
			ItemModel testItem = new ItemModel("Weapon", "Sword", "Strength", 20);
			CharacterModel testCharacter = new CharacterModel(testCreature, 5, testItem);
			testCharacter.Strength = 4;
			Assert.IsTrue(testCharacter.Strength > 0, "Character Dexterity must be greater than zero ");
		}

		[Test]
		public void CharacterDexterityIsEqualTo5()
		{
			CreatureModel testCreature = new CreatureModel("Cad", 1, 4, 5, 4, 5, "");
			ItemModel testItem = new ItemModel("Weapon", "Sword", "Strength", 20);
			CharacterModel testCharacter = new CharacterModel(testCreature, 5, testItem);
			testCharacter.Dexterity = 5;
			Assert.IsTrue(testCharacter.Dexterity == 5, "Character Dexterity must be equal to 5 ");
		}

		[Test]
		public void CharacterDexterityShouldNotBeLessThan1()
		{
			CreatureModel testCreature = new CreatureModel("Cad", 1, 4, 5, 4, 5, "");
			ItemModel testItem = new ItemModel("Weapon", "Sword", "Strength", 20);
			CharacterModel testCharacter = new CharacterModel(testCreature, 5, testItem);
			testCharacter.Dexterity = 0;
			Assert.IsFalse(testCharacter.Dexterity >= 1, "Character Dexterity must not be lesser than 1 ");
		}
		[Test]
		public void CharacterDexterityShouldBeLessThan50()
		{
			CreatureModel testCreature = new CreatureModel("Cad", 1, 4, 5, 4, 5, "");
			ItemModel testItem = new ItemModel("Weapon", "Sword", "Strength", 20);
			CharacterModel testCharacter = new CharacterModel(testCreature, 5, testItem);
			testCharacter.Dexterity = 49;
			Assert.IsTrue(testCharacter.Dexterity < 50, "Character Dexterity must be max 50");
		}
		[Test]
		public void CharacterDexterityShouldNotBeGreaterThan50()
		{
			CreatureModel testCreature = new CreatureModel("Cad", 1, 4, 5, 4, 5, "");
			ItemModel testItem = new ItemModel("Weapon", "Sword", "Strength", 20);
			CharacterModel testCharacter = new CharacterModel(testCreature, 5, testItem);
			testCharacter.Dexterity = 51;
			Assert.IsFalse(testCharacter.Dexterity <= 50, "Character Dexterity should not be greater than 50");
		}
		//tests for Character's Health. Character Health should be positive
		[Test]
		public void CharacterHealthMustBeGreaterThanZero()
		{

			CreatureModel testCreature = new CreatureModel("Cad", 1, 4, 5, 4, 5, "");
			ItemModel testItem = new ItemModel("Weapon", "Sword", "Strength", 20);
			CharacterModel testCharacter = new CharacterModel(testCreature, 5, testItem);
			testCharacter.Health = 8;
			Assert.IsTrue(testCharacter.Health > 0, "Character Health must be greater than zero ");
		}

		[Test]
		public void CharacterHealthIsEqualTo8()
		{
			CreatureModel testCreature = new CreatureModel("Cad", 1, 4, 5, 4, 5, "");
			ItemModel testItem = new ItemModel("Weapon", "Sword", "Strength", 20);
			CharacterModel testCharacter = new CharacterModel(testCreature, 5, testItem);
			testCharacter.Health = 8;
			Assert.IsTrue(testCharacter.Health == 8, "Character Health must be equal to 5 ");
		}

		[Test]
		public void CharacterHealthShouldNotBeLessThan0()
		{
			CreatureModel testCreature = new CreatureModel("Cad", 1, 4, 5, 4, 5, "");
			ItemModel testItem = new ItemModel("Weapon", "Sword", "Strength", 20);
			CharacterModel testCharacter = new CharacterModel(testCreature, 5, testItem);
			testCharacter.Health = 0;
			Assert.IsFalse(testCharacter.Health >= 1, "Character Health must not be lesser than 0 ");
		}
		[Test]
		public void CharacterHealthShouldBeLessThan50()
		{
			CreatureModel testCreature = new CreatureModel("Cad", 1, 4, 5, 4, 5, "");
			ItemModel testItem = new ItemModel("Weapon", "Sword", "Strength", 20);
			CharacterModel testCharacter = new CharacterModel(testCreature, 5, testItem);
			testCharacter.Health = 49;
			Assert.IsTrue(testCharacter.Health < 50, "Character Health must be max 50");
		}
		[Test]
		public void CharacterHealthShouldNotBeGreaterThan50()
		{
			CreatureModel testCreature = new CreatureModel("Cad", 1, 4, 5, 4, 5, "");
			ItemModel testItem = new ItemModel("Weapon", "Sword", "Strength", 20);
			CharacterModel testCharacter = new CharacterModel(testCreature, 5, testItem);
			testCharacter.Health = 52;
			Assert.IsFalse(testCharacter.Health <= 50, "Character Health should not be greater than 50");
		}
		//tests for Character's Speed. Character Speed should be positive
		[Test]
		public void CharacterSpeedMustBeGreaterThanZero()
		{

			CreatureModel testCreature = new CreatureModel("Cad", 1, 4, 5, 4, 5, "");
			ItemModel testItem = new ItemModel("Weapon", "Sword", "Strength", 20);
			CharacterModel testCharacter = new CharacterModel(testCreature, 5, testItem);
			testCharacter.Speed = 5;
			Assert.IsTrue(testCharacter.Speed > 0, "Character Speed must be greater than zero ");
		}

		[Test]
		public void CharacterSpeedIsEqualTo5()
		{
			CreatureModel testCreature = new CreatureModel("Cad", 1, 4, 5, 4, 5, "");
			ItemModel testItem = new ItemModel("Weapon", "Sword", "Strength", 20);
			CharacterModel testCharacter = new CharacterModel(testCreature, 5, testItem);
			testCharacter.Speed = 5;
			Assert.IsTrue(testCharacter.Speed == 5, "Character Speed must be equal to 5 ");
		}

		[Test]
		public void CharacterSpeedShouldNotBeLessThan1()
		{
			CreatureModel testCreature = new CreatureModel("Cad", 1, 4, 5, 4, 5, "");
			ItemModel testItem = new ItemModel("Weapon", "Sword", "Strength", 20);
			CharacterModel testCharacter = new CharacterModel(testCreature, 5, testItem);
			testCharacter.Speed = 0;
			Assert.IsFalse(testCharacter.Speed >= 1, "Character Speed must not be lesser than 1 ");
		}
		[Test]
		public void CharacterSpeedShouldBeLessThan50()
		{
			CreatureModel testCreature = new CreatureModel("Cad", 1, 4, 5, 4, 5, "");
			ItemModel testItem = new ItemModel("Weapon", "Sword", "Strength", 20);
			CharacterModel testCharacter = new CharacterModel(testCreature, 5, testItem);
			testCharacter.Speed = 49;
			Assert.IsTrue(testCharacter.Speed < 50, "Character Speed must be max 50");
		}
		[Test]
		public void CharacterSpeedShouldNotBeGreaterThan50()
		{
			CreatureModel testCreature = new CreatureModel("Cad", 1, 4, 5, 4, 5, "");
			ItemModel testItem = new ItemModel("Weapon", "Sword", "Strength", 20);
			CharacterModel testCharacter = new CharacterModel(testCreature, 5, testItem);
			testCharacter.Speed = 52;
			Assert.IsFalse(testCharacter.Speed <= 50, "Character Speed should not be greater than 50");
		}
		//tests for Character's Level. Character Level should be positive
		[Test]
		public void CharacterLevelMustBeGreaterThanZero()
		{

			CreatureModel testCreature = new CreatureModel("Cad", 1, 4, 5, 4, 5, "");
			ItemModel testItem = new ItemModel("Weapon", "Sword", "Strength", 20);
			CharacterModel testCharacter = new CharacterModel(testCreature, 5, testItem);
			testCharacter.Level = 1;
			Assert.IsTrue(testCharacter.Level > 0, "Character Level must be greater than zero ");
		}

		[Test]
		public void CharacterLevelIsEqualTo2()
		{
			CreatureModel testCreature = new CreatureModel("Cad", 1, 4, 5, 4, 5, "");
			ItemModel testItem = new ItemModel("Weapon", "Sword", "Strength", 20);
			CharacterModel testCharacter = new CharacterModel(testCreature, 5, testItem);
			testCharacter.Level = 2;
			Assert.IsTrue(testCharacter.Level == 2, "Character Level must be equal to 5 ");
		}

		[Test]
		public void CharacterLevelShouldNotBeLessThan1()
		{
			CreatureModel testCreature = new CreatureModel("Cad", 1, 4, 5, 4, 5, "");
			ItemModel testItem = new ItemModel("Weapon", "Sword", "Strength", 20);
			CharacterModel testCharacter = new CharacterModel(testCreature, 5, testItem);
			testCharacter.Level = 0;
			Assert.IsFalse(testCharacter.Level >= 1, "Character Level must not be lesser than 1 ");
		}
		[Test]
		public void CharacterLevelShouldBeLessThan20()
		{
			CreatureModel testCreature = new CreatureModel("Cad", 1, 4, 5, 4, 5, "");
			ItemModel testItem = new ItemModel("Weapon", "Sword", "Strength", 20);
			CharacterModel testCharacter = new CharacterModel(testCreature, 5, testItem);
			testCharacter.Level = 49;
			Assert.IsTrue(testCharacter.Level < 50, "Character Level must be max 20");
		}
		[Test]
		public void CharacterLevelShouldNotBeGreaterThan20()
		{
			CreatureModel testCreature = new CreatureModel("Cad", 1, 4, 5, 4, 5, "");
			ItemModel testItem = new ItemModel("Weapon", "Sword", "Strength", 20);
			CharacterModel testCharacter = new CharacterModel(testCreature, 5, testItem);
			testCharacter.Level = 21;
			Assert.IsFalse(testCharacter.Level <= 20, "Character Level should not be greater than 50");
		}
		//tests for Character's Experience. Character Experience should be positive
		[Test]
		public void CharacterExperienceMustBeGreaterThanZero()
		{

			CreatureModel testCreature = new CreatureModel("Cad", 1, 4, 5, 4, 5, "");
			ItemModel testItem = new ItemModel("Weapon", "Sword", "Strength", 20);
			CharacterModel testCharacter = new CharacterModel(testCreature, 5, testItem);
			testCharacter.Experience = 5;
			Assert.IsTrue(testCharacter.Experience > 0, "Character Experience must be greater than zero ");
		}

		[Test]
		public void CharacterExperienceIsEqualTo5()
		{
			CreatureModel testCreature = new CreatureModel("Cad", 1, 4, 5, 4, 5, "");
			ItemModel testItem = new ItemModel("Weapon", "Sword", "Strength", 20);
			CharacterModel testCharacter = new CharacterModel(testCreature, 5, testItem);
			testCharacter.Experience = 5;
			Assert.IsTrue(testCharacter.Experience == 5, "Character Experience must be equal to 5 ");
		}

		[Test]
		public void CharacterExperienceShouldNotBeLessThan1()
		{
			CreatureModel testCreature = new CreatureModel("Cad", 1, 4, 5, 4, 5, "");
			ItemModel testItem = new ItemModel("Weapon", "Sword", "Strength", 20);
			CharacterModel testCharacter = new CharacterModel(testCreature, 5, testItem);
			testCharacter.Experience = 0;
			Assert.IsFalse(testCharacter.Experience >= 1, "Character Experience must not be lesser than 1 ");
		}
		[Test]
		public void CharacterExperienceShouldBeLessThan50()
		{
			CreatureModel testCreature = new CreatureModel("Cad", 1, 4, 5, 4, 5, "");
			ItemModel testItem = new ItemModel("Weapon", "Sword", "Strength", 20);
			CharacterModel testCharacter = new CharacterModel(testCreature, 5, testItem);
			testCharacter.Experience = 49;
			Assert.IsTrue(testCharacter.Experience < 50, "Character Experience must be max 50");
		}
		[Test]
		public void CharacterExperienceShouldNotBeGreaterThan50()
		{
			CreatureModel testCreature = new CreatureModel("Cad", 1, 4, 5, 4, 5, "");
			ItemModel testItem = new ItemModel("Weapon", "Sword", "Strength", 20);
			CharacterModel testCharacter = new CharacterModel(testCreature, 5, testItem);
			testCharacter.Experience = 52;
			Assert.IsFalse(testCharacter.Experience <= 50, "Character Experience should not be greater than 50");
		}
		//tests to check if the character is dead when health is less than equal to zero and alive when health is greater than zero

		[Test]
		public void CharacterShouldBeAliveIfHealthIsGreaterThanZero()
		{
			CreatureModel testCreature = new CreatureModel("Cad", 1, 4, 5, 4, 5, "");
			ItemModel testItem = new ItemModel("Weapon", "Sword", "Strength", 20);
			CharacterModel testCharacter = new CharacterModel(testCreature, 5, testItem);
			CharacterController testCharacterController = new CharacterController();
			testCharacter.Health = 4;
			Assert.IsFalse(testCharacterController.isDead(testCharacter), "Character should be alive when health is greater than zero");
		}
		[Test]
		public void CharacterShouldBeDeadIfHealthIsZero()
		{

			CreatureModel testCreature = new CreatureModel("Cad", 1, 4, 5, 4, 5, "");
			ItemModel testItem = new ItemModel("Weapon", "Sword", "Strength", 20);
			CharacterModel testCharacter = new CharacterModel(testCreature, 5, testItem);
			CharacterController testCharacterController = new CharacterController();
			testCharacter.Health = 0;
			Assert.IsTrue(testCharacterController.isDead(testCharacter), "Character should be dead if health is equal to zero");
		}
		//tests to check the strength of character after equipping item
		[Test]
		public void CharacterStrengthCannotBeZeroAfterEquippingItem()
		{
			CreatureModel testCreature = new CreatureModel("Cad", 1, 4, 5, 4, 5, "");
			ItemModel testItem = new ItemModel("Weapon", "Sword", "Strength", 20);
			CharacterModel testCharacter = new CharacterModel(testCreature, 5, testItem);
			CharacterController testCharacterController= new CharacterController();
			var modifiedCharacterObject = testCharacterController.useItem(testCharacter);
			Assert.IsFalse(modifiedCharacterObject.Strength==0, "Character strength cannot be zero after equipping item");
		}
		[Test]
		public void CharacterStrengthShouldIncreaseAfterUsingItem()
		{
			CreatureModel testCreature = new CreatureModel("Cad", 1, 4, 5, 4, 5, "");
			ItemModel testItem = new ItemModel("Weapon", "Sword", "Strength", 20);
			CharacterModel testCharacter = new CharacterModel(testCreature, 5, testItem);
			CharacterController testCharacterController = new CharacterController();
			int originalStrength = testCharacter.Strength;
			var modifiedCharacterObject = testCharacterController.useItem(testCharacter);
			Assert.IsTrue((modifiedCharacterObject.Strength > originalStrength), "Character strength should be greater than its original strength after using the item");
		}
		[Test]
		public void CharacterStrengthShouldNotDecreaseAfterUsingItem()
		{
			CreatureModel testCreature = new CreatureModel("Cad", 1, 4, 5, 4, 5, "");
			ItemModel testItem = new ItemModel("Weapon", "Sword", "Strength", 20);
			CharacterModel testCharacter = new CharacterModel(testCreature, 5, testItem);
			CharacterController testCharacterController = new CharacterController();
			int originalStrength = testCharacter.Strength;
			var modifiedCharacterObject = testCharacterController.useItem(testCharacter);
			Assert.IsFalse(modifiedCharacterObject.Strength < originalStrength, "Character strength should not decrease than its original strength after using the item");
		}
		[Test]
		public void CharacterStrengthShouldBeSumOfStrengthAndItemValue()
		{
			CreatureModel testCreature = new CreatureModel("Cad", 1, 4, 5, 4, 5, "");
			ItemModel testItem = new ItemModel("Weapon", "Sword", "Strength", 20);
			CharacterModel testCharacter = new CharacterModel(testCreature, 5, testItem);
			CharacterController testCharacterController = new CharacterController();
			int originalStrength = testCharacter.Strength;
			var modifiedCharacterObject = testCharacterController.useItem(testCharacter);
			Assert.IsTrue(modifiedCharacterObject.Strength == (originalStrength+ (testCharacter.item.upgradeValue)), "Character strength should be sum of its original strength and item's upgrade value");
		}
		//tests to check the strength of character after deleting item

		[Test]
		public void CharacterStrengthShouldDecreaseAfterDeletingItem()
		{
			CreatureModel testCreature = new CreatureModel("Cad", 1, 4, 5, 4, 5, "");
			ItemModel testItem = new ItemModel("Weapon", "Sword", "Strength", 20);
			CharacterModel testCharacter = new CharacterModel(testCreature, 5, testItem);
			CharacterController testCharacterController = new CharacterController();
			int originalStrength = testCharacter.Strength;
			//var modifiedCharacterObject = testCharacterController.deleteItem(testCharacter);
			//Assert.IsTrue((modifiedCharacterObject.Strength < originalStrength), "Character strength should be lesser than its original strength after deleting the item");
		}
		[Test]
		public void CharacterStrengthShouldNotBeMoreThanOriginalAfterDeletingItem()
		{
			CreatureModel testCreature = new CreatureModel("Cad", 1, 4, 5, 4, 5, "");
			ItemModel testItem = new ItemModel("Weapon", "Sword", "Strength", 20);
			CharacterModel testCharacter = new CharacterModel(testCreature, 5, testItem);
			CharacterController testCharacterController = new CharacterController();
			int originalStrength = testCharacter.Strength;
		//	var modifiedCharacterObject = testCharacterController.deleteItem(testCharacter);
			//Assert.IsFalse(modifiedCharacterObject.Strength > originalStrength, "Character strength should not be more than its original strength after deleting the item");
		}
		[Test]
		public void CharacterStrengthShouldBeDifferenceOfStrengthAndItemValue()
		{
			CreatureModel testCreature = new CreatureModel("Cad", 1, 4, 5, 4, 5, "");
			ItemModel testItem = new ItemModel("Weapon", "Sword", "Strength", 20);
			CharacterModel testCharacter = new CharacterModel(testCreature, 5, testItem);
			CharacterController testCharacterController = new CharacterController();
			int originalStrength = testCharacter.Strength;
			//var modifiedCharacterObject = testCharacterController.deleteItem(testCharacter);
			//Assert.IsTrue(modifiedCharacterObject.Strength == (originalStrength - (testCharacter.item.upgradeValue)), "Modified Character strength should be its original strength- item's value");
		}

		//tests to check the defense Rate of character

		[Test]
		public void CharacterDefenseRateShouldNotBeLessThanZero()
		{
			CreatureModel testCreature = new CreatureModel("Cad", 1, 4, 5, 4, 5, "");
			ItemModel testItem = new ItemModel("Weapon", "Sword", "Strength", 20);
			CharacterModel testCharacter = new CharacterModel(testCreature, 5, testItem);
			CharacterController testCharacterController = new CharacterController();
			int testDefenseRate = testCharacterController.defenseRate(testCharacter);
			Assert.IsFalse((testDefenseRate < 0), "Character defense rate cannot be less than 0");
		}
		[Test]
		public void CharacterDefenseRateShouldBGreaterThanZero()
		{
			CreatureModel testCreature = new CreatureModel("Cad", 1, 4, 5, 4, 5, "");
			ItemModel testItem = new ItemModel("Weapon", "Sword", "Strength", 20);
			CharacterModel testCharacter = new CharacterModel(testCreature, 5, testItem);
			CharacterController testCharacterController = new CharacterController();
			int testDefenseRate = testCharacterController.defenseRate(testCharacter);
			Assert.IsTrue((testDefenseRate > 0), "Character defense rate has to be greater than 0");
		}
		[Test]
		public void CalculateDefenseRateTest()
		{
			CreatureModel testCreature = new CreatureModel("Cad", 1, 4, 5, 4, 5, "");
			ItemModel testItem = new ItemModel("Weapon", "Sword", "Strength", 20);
			CharacterModel testCharacter = new CharacterModel(testCreature, 5, testItem);
			CharacterController testCharacterController = new CharacterController();
			int testDefenseRate = testCharacterController.defenseRate(testCharacter);
			Assert.IsTrue((testDefenseRate== (testCharacter.Dexterity * testCharacter.Speed)), "Character defense rate has to be product of character's dexterity and speed");
		}
	//tests to check the experience of character after level up

		[Test]
		public void CharacterExperienceMustNotBeLessThanZeroAfterLevelUp()
		{
			CreatureModel testCreature = new CreatureModel("Cad", 1, 4, 5, 4, 5, "");
			ItemModel testItem = new ItemModel("Weapon", "Sword", "Strength", 20);
			CharacterModel testCharacter = new CharacterModel(testCreature, 5, testItem);
			CharacterController testCharacterController = new CharacterController();
			int testExperience = testCharacterController.levelup(testCharacter);
			Assert.IsFalse((testExperience < 0), "Character's experience cannot be less than zero after level up ");
		}
		[Test]
		public void CharacterExperienceMusttBeGreaterThanZeroAfterLevelUp()
		{
			CreatureModel testCreature = new CreatureModel("Cad", 1, 4, 5, 4, 5, "");
			ItemModel testItem = new ItemModel("Weapon", "Sword", "Strength", 20);
			CharacterModel testCharacter = new CharacterModel(testCreature, 5, testItem);
			CharacterController testCharacterController = new CharacterController();
			int testExperience = testCharacterController.levelup(testCharacter);
			Assert.IsTrue((testExperience > 0), "Character's experience must be greater than zero after level up ");
		}
		[Test]
		public void CharacterExperienceMustIncreaseAfterLevelUp()
		{
			CreatureModel testCreature = new CreatureModel("Cad", 1, 4, 5, 4, 5, "");
			ItemModel testItem = new ItemModel("Weapon", "Sword", "Strength", 20);
			CharacterModel testCharacter = new CharacterModel(testCreature, 5, testItem);
			CharacterController testCharacterController = new CharacterController();
			int originalExperience = testCharacter.Experience;
			int testExperience= testCharacterController.levelup(testCharacter);
			Assert.IsTrue((testExperience > originalExperience), "Character's experience must be greater than original experience");
		}
		[Test]
		public void CharacterExperienceMustNotDecreaseAfterLevelUp()
		{
			CreatureModel testCreature = new CreatureModel("Cad", 1, 4, 5, 4, 5, "");
			ItemModel testItem = new ItemModel("Weapon", "Sword", "Strength", 20);
			CharacterModel testCharacter = new CharacterModel(testCreature, 5, testItem);
			CharacterController testCharacterController = new CharacterController();
			int originalExperience = testCharacter.Experience;
			int testExperience = testCharacterController.levelup(testCharacter);
			Assert.IsFalse((testExperience < originalExperience), "Character's experience must be not be lesser than original experience");
		}
		[Test]
		public void CalculateExperienceAfterLevelUpTest()
		{
			CreatureModel testCreature = new CreatureModel("Cad", 1, 4, 5, 4, 5, "");
			ItemModel testItem = new ItemModel("Weapon", "Sword", "Strength", 20);
			CharacterModel testCharacter = new CharacterModel(testCreature, 5, testItem);
			CharacterController testCharacterController = new CharacterController();
			int originalExperience = testCharacter.Experience;
			int testExperience = testCharacterController.levelup(testCharacter);
			Assert.IsTrue((testExperience == (originalExperience+10)), "Character's experience must increase by 10 with a level up");
		}

	}
}

*/