using System;
using System.IO;
using System.Linq;
using NUnit.Framework;
//using Xamarin.UITest;
//using Xamarin.UITest.Queries;
using CadmusDND;

namespace UnitTests
{
    public class DiceUnitTest
    {
        public DiceUnitTest() {}

		[SetUp]
		public void BeforeEachTest()
		{
		}
        //Tests Dice Model
        //tests for Roll. Whatever the number of faces the controller sends, the random number must be b/w 1 and faces + 1
        [Test]
        public void RollIsBetween1AndFacesPlus1()
        {
            DiceModel testDice = new DiceModel(5);
            int dice = testDice.Roll;
            Assert.IsTrue(dice <= 5 + 1 && dice >= 1, "The dice roll is greater or equal to 5 and is greater or equal to 1");
        }
		//Tests Dice Controller
		//Tests for DiceRoll method. The outcome of a 4 sided dice should be between 1 - 5 
		[Test]
		public void DiceRollShouldBeBetween1And5()
		{
            DiceController testDiceController = new DiceController();
            int roll = testDiceController.DiceRoll(1, 4);
            Assert.IsTrue(roll <= 5 && roll >= 1, "The outcome of the 4 sided dice is between 1 and 5. ");
		}
		//Tests for DiceRoll method. The outcome of a 6 sided dice should be between 1 and 7
		[Test]
		public void DiceRollShouldBeBetween1And7()
		{
			DiceController testDiceController = new DiceController();
			int roll = testDiceController.DiceRoll(1, 6);
			Assert.IsTrue(roll <= 7 && roll >= 1, "The outcome of the 6 sided dice is between 1 and 7. ");
		}
		//Tests for DiceRoll method. The outcome of a 8 sided dice should be between 1 - 9
		[Test]
		public void DiceRollShouldBeBetween1And9()
		{
			DiceController testDiceController = new DiceController();
			int roll = testDiceController.DiceRoll(1, 8);
			Assert.IsTrue(roll <= 9 && roll >= 1, "The outcome of the 8 sided dice is between 1 and 9. ");
		}
		//Tests for DiceRoll method. The outcome of a 10 sided dice should be between 1 - 11 
		[Test]
		public void DiceRollShouldBeBetween1And11()
		{
			DiceController testDiceController = new DiceController();
			int roll = testDiceController.DiceRoll(1, 10);
			Assert.IsTrue(roll <= 11 && roll >= 1, "The outcome of the 10 sided dice is between 1 and 11. ");
		}
		//Tests for DiceRoll method. The outcome of a 12 sided dice should be between 1 - 13
		[Test]
		public void DiceRollShouldBeBetween1And13()
		{
			DiceController testDiceController = new DiceController();
			int roll = testDiceController.DiceRoll(1, 12);
			Assert.IsTrue(roll <= 13 && roll >= 1, "The outcome of the 4 sided dice is between 1 and 13. ");
		}
		//Tests for DiceRoll method. The outcome of a dice that is not 4 or 6 or 8 or 10 or 12 sided but instead 20 should be 0.
		[Test]
		public void DiceRollShouldBe0IfInputIs20()
		{
			DiceController testDiceController = new DiceController();
			int roll = testDiceController.DiceRoll(1, 20);
			Assert.IsTrue(roll == 0, "The outcome of the 20 should be 0. ");
		}
		//Tests for DiceRoll method. The outcome of a dice that is not 4 or 6 or 8 or 10 or 12 sided but instead a negative number should be 0.
		[Test]
		public void DiceRollShouldBe0IfInputIsNegative()
		{
			DiceController testDiceController = new DiceController();
			int roll = testDiceController.DiceRoll(1, -10);
			Assert.IsTrue(roll == 0, "The outcome of the 20 should be 0. ");
		}
	}
}
