/*using System;
using System.IO;
using System.Linq;
using NUnit.Framework;
//using Xamarin.UITest;
//using Xamarin.UITest.Queries;
using CadmusDND;
using System.Collections.Generic;

namespace UnitTests
{
	public class ItemUnitTest
	{
		public ItemUnitTest()
		{
		}
		[SetUp]
		public void BeforeEachTest()
		{
		}
		//Tests Item Model
		[Test]
		public void ItemTypeMustEqualToPotion()
		{
			ItemModel testItem = new ItemModel("Potion", "Chilly Potion", "strength", 10);
			Assert.IsTrue(testItem.type == "Potion", "Item type must be equal to potion");
		}
		//tests for Item type. Item type should not be null
		[Test]
		public void ItemTypeMustNotBeNull()
		{
			ItemModel testItem = new ItemModel("Potion", "Chilly Potion", "strength", 10);
			testItem.type = null;
			Assert.IsFalse(testItem.type != null, "Item name is NULL");
		}
		[Test]
		public void ItemNameMustEqualToChillyPotion()
		{
			ItemModel testItem = new ItemModel("Potion", "Chilly Potion", "strength", 10);
			testItem.name = "Chilly Potion";
			Assert.IsTrue(testItem.name == "Chilly Potion", "Item name must be equal to Chilly Potion");
		}
		//tests for Item name. Item name should not be null
		[Test]
		public void ItemNameMustNotBeNull()
		{
			ItemModel testItem = new ItemModel("Potion", "Chilly Potion", "strength", 10);
			testItem.name = null;
			Assert.IsFalse(testItem.name != null, "Item name is NULL");
		}
		[Test]
		public void ItemUpgradeAttributeMustEqualToStrength()
		{
			ItemModel testItem = new ItemModel("Potion", "Chilly Potion", "strength", 10);
			testItem.upgradeAttribute = "strength";
			Assert.IsTrue(testItem.upgradeAttribute == "strength", "Item upgradeAttribute must be equal to strength");
		}
		//tests for Item upgradeAttribute. Item upgradeAttribute should not be null
		[Test]
		public void ItemUpgradeAttributeMustNotBeNull()
		{
			ItemModel testItem = new ItemModel("Potion", "Chilly Potion", "strength", 10);
			testItem.upgradeAttribute = null;
			Assert.IsFalse(testItem.upgradeAttribute != null, "Item upgradeAttribute is NULL");
		}
		//tests for Item upgradeValue. Item upgrade value should not < 0
		[Test]
		public void ItemUpgradeValueMustNotBeLessThan0()
		{
			ItemModel testItem = new ItemModel("Potion", "Chilly Potion", "strength", 10);
			testItem.upgradeValue = 10;
			Assert.IsFalse(testItem.upgradeValue < 0, "Item upgradeValue is > 0");
		}
		//tests for Item upgradeValue. Item upgrade value should not < 0
		[Test]
		public void ItemUpgradeValueMustNotBeEqualTo0()
		{
			ItemModel testItem = new ItemModel("Potion", "Chilly Potion", "strength", 10);
			testItem.upgradeValue = 10;
			Assert.IsFalse(testItem.upgradeValue == 0, "Item upgradeValue is > 0");
		}
        //tests for controller.addItems
        [Test]
        public void UpgradeItemDictionaryIsModifiedOnAddingNewItem()
        {
            ItemModel testItemModel = new ItemModel("Potion", "Chilly Potion", "strength", 10);
            ItemController testItemController = new ItemController(testItemModel);
            testItemController.UpgradeStats.Add("dexterity", 200);
            testItemController.addItem(testItemModel);
            Assert.IsTrue(testItemController.UpgradeStats.ContainsKey(testItemModel.upgradeAttribute), "An item with new upgrade attribute should be added to the upgradeStats dictionary");
        }
		
		[Test]
		public void UpdateUpgradeStatsOnAddingItemWithExistingAttribute()
		{
			ItemModel testItemModel = new ItemModel("Potion", "Chilly Potion", "strength", 10);
			ItemController testItemController = new ItemController(testItemModel);
			testItemController.UpgradeStats.Add("dexterity", 200);
            var originalupgradeAttribute = testItemController.UpgradeStats[testItemModel.upgradeAttribute];
			testItemController.addItem(testItemModel);
			Assert.IsTrue(testItemController.UpgradeStats[testItemModel.upgradeAttribute]>originalupgradeAttribute, "The upgrade value is increased when a new item with existing upgradeType is added");
		}

		[Test]
		public void UpgradeStatsMustNotDecreaseOnAddingItemWithExistingAttribute()
		{
			ItemModel testItemModel = new ItemModel("Potion", "Chilly Potion", "strength", 10);
			ItemController testItemController = new ItemController(testItemModel);
			testItemController.UpgradeStats.Add("dexterity", 200);
			var originalupgradeAttribute = testItemController.UpgradeStats[testItemModel.upgradeAttribute];
			testItemController.addItem(testItemModel);
			Assert.IsFalse(testItemController.UpgradeStats[testItemModel.upgradeAttribute] < originalupgradeAttribute, "The upgrade value is increased when a new item with existing upgradeType is added");
		}

		//tests for controller.removeItems
		[Test]
		public void UpgradeItemValueShouldBeGreaterThanZero()
		{
			ItemModel testItemModel = new ItemModel("Potion", "Chilly Potion", "strength", 10);
			ItemController testItemController = new ItemController(testItemModel);
			testItemController.UpgradeStats.Add("dexterity", 200);
            testItemController.removeItem(testItemModel);
			Assert.IsTrue(testItemController.UpgradeStats[testItemModel.upgradeAttribute]>0, "The upgrade value must be greater than zero after removing an items");
		}

		[Test]
		public void UpgradeItemValueShouldNotBeLesserThanZero()
		{
			ItemModel testItemModel = new ItemModel("Potion", "Chilly Potion", "strength", 10);
			ItemController testItemController = new ItemController(testItemModel);
			testItemController.UpgradeStats.Add("dexterity", 200);
			var originalupgradeAttribute = testItemController.UpgradeStats[testItemModel.upgradeAttribute];
			testItemController.addItem(testItemModel);
			Assert.IsFalse(testItemController.UpgradeStats[testItemModel.upgradeAttribute] < 0, "The upgrade value must not be lesser than zero after removing an items");
		}

		//Tests for itemController.TotalStatUpgrades()
		[Test]
		public void totalStatsUpgradeCannotBeLessThanZero()
		{
			ItemModel testItemModel = new ItemModel("Potion", "Chilly Potion", "strength", 10);
			ItemController testItemController = new ItemController(testItemModel);
			testItemController.UpgradeStats.Add("dexterity", 200);
            string attribute = "strength";
            int totalStatUpgrade= testItemController.TotalStatUpgrades(attribute);
			Assert.IsFalse(totalStatUpgrade < 0, "The totalStatUpgrade value cannot be lesser than 0");
		}
		[Test]
		public void totalStatsUpgradeMustBeGreaterThanZeroWhenAttributeExists()
		{
			ItemModel testItemModel = new ItemModel("Potion", "Chilly Potion", "strength", 10);
			ItemController testItemController = new ItemController(testItemModel);
			testItemController.UpgradeStats.Add("dexterity", 200);
			string attribute = "strength";
			int totalStatUpgrade = testItemController.TotalStatUpgrades(attribute);
            Assert.IsTrue(totalStatUpgrade > 0, "The totalStatUpgrade value must be greater than 0 when upgrade attribute is present");
		}

		[Test]
		public void totalStatsUpgradeMustBeLesserThanZeroWhenAttributeNotPresent()
		{
			ItemModel testItemModel = new ItemModel("Potion", "Chilly Potion", "strength", 10);
			ItemController testItemController = new ItemController(testItemModel);
			testItemController.UpgradeStats.Add("dexterity", 200);
			string attribute = "energy";
			int totalStatUpgrade = testItemController.TotalStatUpgrades(attribute);
			Assert.IsTrue(totalStatUpgrade == 0, "The totalStatUpgrade value must be  0 when upgrade attribute is absent");
		}

		[Test]
		public void totalStatsMustNotBeZeroWhenAttributeIsPresent()
		{
			ItemModel testItemModel = new ItemModel("Potion", "Chilly Potion", "strength", 10);
			ItemController testItemController = new ItemController(testItemModel);
			testItemController.UpgradeStats.Add("dexterity", 200);
			string attribute = "strength";
			int totalStatUpgrade = testItemController.TotalStatUpgrades(attribute);
            Assert.IsFalse(totalStatUpgrade == 0, "The totalStatUpgrade value must not be  0 when upgrade attribute is present");
		}
	}
}
*/