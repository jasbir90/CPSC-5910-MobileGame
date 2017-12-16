﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using System.Net.Http;
using Newtonsoft.Json;

namespace CadmusDND
{
    public class BattleEvent
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Tier { get; set; }
        public string Target { get; set; }
        public string AttribMod { get; set; }
    }
	public class BattleEventRoot
	{
		public int error_code { get; set; }
		public string msg { get; set; }
		public IList<BattleEvent> data { get; set; }
	}
    public class GameController
    {
		// Singleton Implementation
		private static GameController instance;
		public static GameController Instance
		{
			get
			{
				if (instance == null)
				{
					instance = new GameController();
				}
				return instance;
			}
		}
        private Random rand = new Random();
        private bool inBattle = false;
        private bool aniBattle = false;
        private VGameObj offense;
        private VGameObj defense;
        private int battleCount = 0;
        private int aniCount = 0;
        private int charOrder = 0;
        private int monsterOrder = 0;
        private bool charTurn = true;
        private BattleController bc;
        private bool leveled;
        public bool itemServer;
        public bool itemRandom;
        public bool itemSuper;
        public bool battleEvent;
        public bool battleEventLoaded;
        public List<BattleEvent> battleEvents = new List<BattleEvent>();
        public BattleEvent currBE;
        public List<CreatureModel> currBETarget;

		public GameController()
        {
            bc = new BattleController();
            leveled = false;
		}

        public void Initialize()
        {
            
        }

        public void OnTimer()
        {
            BattlePage bp = GetBattlePage();
            if (bp != null)
            {
                bp.OnTimer();
            }
			TextBattlePage tbp = GetTextBattlePage();
			if (tbp != null)
			{
				tbp.OnTimer();
			}
			if (inBattle && aniBattle) {
                ProcessBattle();
            }
		}

        public void RestartGame()
        {
            GameModel.Instance.Restart();
        }

        public async void GetBattleEvents()
        {
			var values = new Dictionary<string, string>
				{
					{ "randomItemOption", itemRandom ? "1" : "0" },
					{ "superItemOption", itemSuper ? "1" : "0" },
				};
			var client = new System.Net.Http.HttpClient();
			var content = new FormUrlEncodedContent(values);
			var response = await client.PostAsync("http://gamehackathon.azurewebsites.net/API/GetBattleEffects/", content);
			var responseString = await response.Content.ReadAsStringAsync();

			BattleEventRoot jr = JsonConvert.DeserializeObject<BattleEventRoot>(responseString);
			if (jr.error_code == 0)
			{
                for (int i = 0; i < jr.data.Count; i++)
                    battleEvents.Add(jr.data[i]);
			}
            battleEventLoaded = true;
		}
        public void BattleEventAffect(string target, string attr, int tier)
        {
			GameModel gm = GameModel.Instance;
            if (target.Length > 0)
            {
                currBETarget = new List<CreatureModel>();
                if (target == "CHARACTERSINGLE")
                {
                    int ct = gm.Characters.Count;
                    if (ct > 0)
                        currBETarget.Add(gm.Characters[rand.Next() % ct]);
                }
                else if (target == "CHARACTERALL")
                {
                    foreach (CreatureModel cm in gm.Characters)
                    {
                        currBETarget.Add(cm);
                    }
                }
                else if (target == "MONSTERALL" || target == "MONSTERAALL")
                {
                    foreach (CreatureModel cm in gm.Monsters)
                    {
                        currBETarget.Add(cm);
                    }
                }
                else if (target == "MONSTERSINGLE")
                {
					int ct = gm.Monsters.Count;
					if (ct > 0)
						currBETarget.Add(gm.Monsters[rand.Next() % ct]);
				}
                else if (target == "ALL")
                {
                    foreach (CreatureModel cm in gm.Characters)
                    {
                        currBETarget.Add(cm);
                    }
                    foreach (CreatureModel cm in gm.Monsters)
                    {
                        currBETarget.Add(cm);
                    }
                }
            }

            if (currBETarget == null)
                return;

            foreach (CreatureModel cm in currBETarget)
            {
                if (attr == "STRENGTH")
                {
                    cm.Strength += tier;
                }
                else if (attr == "SPEED")
                {
                    cm.Speed += tier;
                }
				else if (attr == "DEFENSE")
				{
                    cm.Dexterity += tier;
				}
				else if (attr == "HP")
				{
					cm.Health += tier;
				}
			}
        }
        public string BattleEventStart()
        {
            string retMsg;
            currBE = null;
            if (battleEvents.Count == 0)
                return "";

            int idx = rand.Next() % battleEvents.Count;
            currBE = battleEvents[idx];
            retMsg = currBE.Name + ":" + currBE.Description;

            BattleEventAffect(currBE.Target, currBE.AttribMod, currBE.Tier);

            return retMsg;
        }
        public void BattleEventEnd()
        {
            if (currBE == null)
                return;

			// Revert
			BattleEventAffect("", currBE.AttribMod, -currBE.Tier);
		}
        // Battle
        public void PrepareBattle(bool animated)
        {
			GameModel gm = GameModel.Instance;

			// Set up game
			gm.battleModel.Reset();

            // Add characters
            foreach (CharacterModel cm in gm.Characters)
            {
                gm.battleModel.AddChar(cm);
            }

            int monsterCount = rand.Next(VBattleModel.MaxSlots - 1) + 2;
            for (int i = 0; i < monsterCount; i++)
            {
                int monsterNo = rand.Next(gm.Monsters.Count);
                gm.battleModel.AddMonster(gm.Monsters[monsterNo]);
            }
            inBattle = true;
            aniBattle = animated;
            battleCount = 0;
			gm.BattleTotal += 1;

            // Battle Event
            battleEventLoaded = false;
            battleEvents.Clear();
            if (battleEvent)
            {
                GetBattleEvents();
			}
            else
            {
                battleEventLoaded = true;
            }
		}

		public void ProcessBattle()
		{
            if (battleEventLoaded == false)
                return;
			// Have some interval
			battleCount++;
			if (battleCount < 10)
				return;

			GameModel gm = GameModel.Instance;

			// No targets
			if (offense == null)
			{
				// EndCheck
				if (gm.battleModel.party.Count == 0)
				{
					inBattle = false;
					DependencyService.Get<i_audio>().PlayAudioFile("lose.mp3");
					EndBattlePage(false);
					gm.AddCharToParty();
					gm.AddCharToParty(); // Add by 2
					return;
				}
				if (gm.battleModel.monsters.Count == 0)
				{
					inBattle = false;
					DependencyService.Get<i_audio>().PlayAudioFile("bestwin.mp3");
					gm.BattleVictory += 1;
					EndBattlePage(true);
					gm.AddCharToParty();
					gm.AddCharToParty(); // Add by 2
					return;
				}

				// Select objects
				if (charTurn)
				{
					offense = gm.battleModel.party[charOrder % gm.battleModel.party.Count];
					int target = rand.Next(gm.battleModel.monsters.Count);
					defense = gm.battleModel.monsters[target];
					charOrder++;
				}
				else
				{
					offense = gm.battleModel.monsters[monsterOrder % gm.battleModel.monsters.Count];
					int target = rand.Next(gm.battleModel.party.Count);
					defense = gm.battleModel.party[target];
					monsterOrder++;
				}
				charTurn = !charTurn;
				aniCount = 0;
			}
			else
			{
				aniCount++;
				double factor;
				double space = BattlePage.ImgSize * 0.7;
				if (!offense.isCharacter) space *= -1;

				if (aniCount <= 12)
				{
					factor = aniCount / 8.0;
				}
				else
				{
					int newCount = 24 - aniCount;
					factor = newCount / 8.0;
				}

				if (factor < 0.0) factor = 0.0;
				if (factor > 1.0) factor = 1.0;
				double aniX = offense.PositionX * (1 - factor) + (defense.PositionX - space) * factor;
				double aniY = offense.PositionY * (1 - factor) + defense.PositionY * factor;
				offense.SetPos(aniX, aniY);

				if (aniCount == 10)
				{
                    BattleEventStart();
					// Impact
					string msg;
                    int damage = 0;
                    if (offense.Creature.Magic && offense.isCharacter)
                    int damage = bc.GetDamage(offense.Creature, defense.Creature);

                    if (damage == 0)
                        msg = "Miss";
                    else if (damage == 1)
                    {
                        MagicController mc = new MagicController((CharacterModel)offense.Creature);
                        CharacterController cc = new CharacterController((CharacterModel)offense.Creature);
                        cc.buildMagicGrid();
                        List<MagicModel> magiclist = new List<MagicModel>();
                        foreach(string key in cc.magicList.Keys)
                        {
                            magiclist.Add(cc.magicList[key]);
                        }
                        Random rand = new Random();
                        int num = rand.Next(magiclist.Count);
                        MagicModel magic = magiclist[num];

                        // make a list of all the creatures
                        ObservableCollection<MonsterModel> mons = gm.Monsters;
                        List<CreatureModel> creaturelist = new List<CreatureModel>();
                        creaturelist.Add(defense.Creature);
                        foreach(CreatureModel c in mons)
                        {
                            if(!c.Equals(creaturelist[0]))
                            {
                                creaturelist.Add(c);
                                
                            }
                        }

                        Tuple<string, int, List<CreatureModel>> result = mc.UseMagic(magic.Name, creaturelist);
                        damage = result.Item2;
                        msg = result.Item1;
                        mons.Clear();

                        foreach(CreatureModel c in result.Item3)
                        {
                            mons.Add((MonsterModel)c);
                    }
					else
					{
                        if (offense.isCharacter)
                        {
                            CharacterModel character = (CadmusDND.CharacterModel)offense.Creature;
							//FIST FIGHT WITH DAMAGE 2 INFLICTED
							if (character.Inventory.Count == 0)
                                damage = 2;
							if (bc.isCritical())
							{
								msg = string.Format("{0} (CRITICAL)", damage);
							}
							else
							{
                                msg = string.Format("{0} (DAMAGE WITH FIST)", damage);
							}
                        }
                        else
                        {
                            if (bc.isCritical())
                            {
                                msg = string.Format("{0} (CRITICAL)", damage);
                            }
                            else
                            {
                                msg = string.Format("{0}", damage);
                            }
                        }

                        gm.Monsters = mons;

                     }

                    else
                    {
						damage = bc.GetDamage(offense.Creature, defense.Creature);
						if (damage == 0)
							msg = "Miss";
						else if (damage == 1)
						{
							msg = "Critical Miss";
							damage = 0;
							if (offense.isCharacter)
							{
								bool DiDShieldBreak = CriticalMissConsequence((CharacterModel)offense.Creature);
							}
						}
						else
						{
							if (bc.isCritical())
							{
								msg = string.Format("{0} (CRITICAL)", damage);
							}
							else
							{
								msg = string.Format("{0}", damage);
							}
						}
                    }

					DamageMessage(msg, defense.PositionX - space / 2 + 5, defense.PositionY);
					defense.CurHealth -= damage;
					if (defense.CurHealth <= 0)
					{
						CharacterModel cm = offense.Creature as CharacterModel;
						MonsterModel mm = defense.Creature as MonsterModel;
						if (cm != null)
						{
							cm.Experience += rand.Next(8) + 3;
							gm.MonsterKill += 1;
							if (mm != null)
							{
								gm.Gold += mm.Reward;
							}

							if (cm.Experience >= gm.GetExperience(cm.Level + 1))
							{
								leveled = true;
								List<int> lvl = gm.leveling;
								cm.Level = cm.Level + lvl[0];
								cm.Strength = cm.Strength + lvl[1];
								cm.Dexterity = cm.Dexterity + lvl[2];
								cm.Speed = cm.Speed + lvl[3];
								cm.Health = cm.Health + lvl[4];
							}

							cm.UpdateText();
						}
						Dying(defense);
					}
					BattleEventEnd();
				}

				if (aniCount == 24)
				{
					offense.SetPos();
					if (defense.CurHealth <= 0)
					{
						if (defense.isCharacter)
							gm.battleModel.party.Remove(defense);
						else
							gm.battleModel.monsters.Remove(defense);
					}
					offense = null;
					defense = null;
					aniCount = 0;
				}
			}
		}

        public void ProcessBattleText(TextBattlePage tbp)
		{
			GameModel gm = GameModel.Instance;

			while (true)
            {
				// No targets
				if (offense == null)
				{
					// EndCheck
					if (gm.battleModel.party.Count == 0)
					{
						inBattle = false;
						tbp.AddBattleLog("Defeat!", "You should be stronger!");
						gm.AddCharToParty();
						gm.AddCharToParty(); // Add by 2
						return;
					}
					if (gm.battleModel.monsters.Count == 0)
					{
						inBattle = false;
						tbp.AddBattleLog("Victory!", "You got rewards!");
						gm.BattleVictory += 1;
						gm.AddCharToParty();
						gm.AddCharToParty(); // Add by 2
						return;
					}

					// Select objects
					if (charTurn)
					{
						offense = gm.battleModel.party[charOrder % gm.battleModel.party.Count];
						int target = rand.Next(gm.battleModel.monsters.Count);
						defense = gm.battleModel.monsters[target];
						charOrder++;
					}
					else
					{
						offense = gm.battleModel.monsters[monsterOrder % gm.battleModel.monsters.Count];
						int target = rand.Next(gm.battleModel.party.Count);
						defense = gm.battleModel.party[target];
						monsterOrder++;
					}
					charTurn = !charTurn;
				}
				else
				{
                    string beMsg = BattleEventStart();
                    if (beMsg.Length > 0)
                        tbp.AddBattleLog("Battle Event!!!", beMsg);

					// Impact
					string msgDamage;
                    int damage = 0;
                    if (offense.isCharacter)
                    {
                        ItemModel tomb = new ItemModel("MAGICALL", "Tomb Frost Cone", "HP", -5);
                        tomb.itemID = 554;
                        tomb.usage = 20;
                        CharacterController cc = new CharacterController((CharacterModel)offense.Creature);
                        cc.AddToInventory(tomb);
                        cc.buildMagicGrid();
                    }
					if (offense.Creature.Magic && offense.isCharacter)
					{
						MagicController mc = new MagicController((CharacterModel)offense.Creature);
						CharacterController cc = new CharacterController((CharacterModel)offense.Creature);
						cc.buildMagicGrid();
						List<MagicModel> magiclist = new List<MagicModel>();
						foreach (string key in cc.magicList.Keys)
						{
							magiclist.Add(cc.magicList[key]);
						}
						Random rand = new Random();
						int num = rand.Next(0,magiclist.Count);
						MagicModel magic = magiclist[num];

						// make a list of all the creatures
						ObservableCollection<MonsterModel> mons = gm.Monsters;
						List<CreatureModel> creaturelist = new List<CreatureModel>();
						creaturelist.Add(defense.Creature);
						foreach (CreatureModel c in mons)
						{
							if (!c.Equals(creaturelist[0]))
							{
								creaturelist.Add(c);

							}
						}

						Tuple<string, int, List<CreatureModel>> result = mc.UseMagic(magic.Name, creaturelist);
                        msgDamage = offense.Creature.Name + " used " + magic.Name + ": " + result.Item1  ;
                        damage = result.Item2;
						mons.Clear();

						foreach (CreatureModel c in result.Item3)
						{
							mons.Add((MonsterModel)c);
						}

						gm.Monsters = mons;

					}

                    else
                    {
						damage = bc.GetDamage(offense.Creature, defense.Creature);
						if (damage == 0)
						{
							msgDamage = "Miss";
						}
						else if (damage == 1)
						{
							msgDamage = "Critical Miss";
							damage = 0;
							if (offense.isCharacter)
							{
								bool DiDShieldBreak = CriticalMissConsequence((CharacterModel)offense.Creature);
								if (DiDShieldBreak)
								{
									msgDamage = "Critical Miss. Your shield broke!";
								}
							}
						}
						else
						{
							if (bc.isCritical())
							{
								msgDamage = string.Format("Damage: {0} (CRITICAL)", damage);
							}
							else
							{
								msgDamage = string.Format("Damage: {0}", damage);
							}
						}
                    }
					else
					{
                        if (offense.isCharacter)
                        {
                            CharacterModel character = (CadmusDND.CharacterModel)offense.Creature;
                            //FIST FIGHT WITH DAMAGE 2 INFLICTED
                            if (character.Inventory.Count == 0)
                                damage = 2;
                            if (bc.isCritical())
                            {
                                msgDamage = string.Format("{0} (CRITICAL)", damage);
                            }
                            else
                            {
                                msgDamage = string.Format("{0} (DAMAGE WITH FIST)", damage);
                            }
                        }
                        else
                        {
                            if (bc.isCritical())
                            {
                                msgDamage = string.Format("Damage: {0} (CRITICAL)", damage);
                            }
                            else
                            {
                                msgDamage = string.Format("Damage: {0}", damage);
                            }
                        }
					}
                    tbp.AddBattleLog($"{offense.Creature.Name} attacks {defense.Creature.Name}", msgDamage);

					defense.CurHealth -= damage;
					if (defense.CurHealth <= 0)
					{
                        string msgTitle = "";
                        string msgDesc = "";
						CharacterModel cm = offense.Creature as CharacterModel;
						MonsterModel mm = defense.Creature as MonsterModel;

                        msgTitle = $"{offense.Creature.Name} killed {defense.Creature.Name}";
						if (cm != null)
						{
                            int expGain = rand.Next(8) + 3;
                            cm.Experience += expGain;
							gm.MonsterKill += 1;
                            msgDesc += $"Exp: +{expGain} ";
							if (mm != null)
							{
								gm.Gold += mm.Reward;
								msgDesc += $"Gold: +{mm.Reward} ";
							}
                            tbp.AddBattleLog(msgTitle, msgDesc);

							if (cm.Experience >= gm.GetExperience(cm.Level + 1))
							{
								leveled = true;
								List<int> lvl = gm.leveling;
								cm.Level = cm.Level + lvl[0];
								cm.Strength = cm.Strength + lvl[1];
								cm.Dexterity = cm.Dexterity + lvl[2];
								cm.Speed = cm.Speed + lvl[3];
								cm.Health = cm.Health + lvl[4];
                                tbp.AddBattleLog($"{offense.Creature.Name} levels Up!", $"Now the level is {cm.Level}");
							}
							cm.UpdateText();
						}
                        else
                        {
							tbp.AddBattleLog(msgTitle, msgDesc);
						}
						if (defense.isCharacter)
							gm.battleModel.party.Remove(defense);
						else
							gm.battleModel.monsters.Remove(defense);
					}
					BattleEventEnd();
					offense = null;
					defense = null;
				}
			}
		}

		public void Surrender()
		{
			EndBattlePage(false);
		}

		// Animated Battle
		private async void EndBattlePage(bool victory)
		{
			inBattle = false;
			BattlePage bp = GetBattlePage();
			if (bp != null)
			{
				if (victory)
				{
					await bp.DisplayAlert("Victory!", "You got rewards!", "OK");
					if (leveled)
					{
						DependencyService.Get<i_audio>().PlayAudioFile("levelUp.mp3");
						await bp.DisplayAlert("Level Up!", "A character leveled up. Check the character screen for details.", "OK");
					}
				}
				else
				{
					await bp.DisplayAlert("Defeat!", "You should be stronger!", "OK");
				}

				await bp.Navigation.PopAsync();
			}
		}

        public bool SetSlot(int side, int no, Image img, double xPos, double yPos)
        {
			GameModel gm = GameModel.Instance;
            VGameObj vgo = null;
            if (side == 0)
            {
                if (no < gm.battleModel.party.Count)
                    vgo = gm.battleModel.party[no];
            }
            else
            {
				if (no < gm.battleModel.monsters.Count)
					vgo = gm.battleModel.monsters[no];
            }
            if (vgo != null)
            {
                vgo.PositionX = xPos;
                vgo.PositionY = yPos;
                vgo.image = img;
                vgo.image.Source = vgo.Creature.Image;
                vgo.SetPos();
                return true;
            }
            else
                return false;
        }

        private void DamageMessage(string msg, double xPos, double yPos)
        {
			BattlePage bp = GetBattlePage();
			if (bp != null)
			{
				bp.SetDamage(msg, xPos, yPos);
			}
        }

        public bool CriticalMissConsequence(CharacterModel c)
        {
            bool DidShieldBreak = false;
            CharacterController cc = new CharacterController(c);
            // Randomly drop an item
            int sizeOfInventory = c.inventory.Count;
            if(sizeOfInventory > 0)
            {
				Random rand = new Random();
				ItemModel item = c.inventory[rand.Next(0, sizeOfInventory)];
				cc.deleteItem(item);

				// Determine if the character's shield breaks
				if (cc.HasItemType("Shield"))
				{
					DiceController dice = new DiceController();
					if (dice.DiceRoll(1, 10) > 6)
					{
						cc.deleteItemType("Shield");
						DidShieldBreak = true;
					}
				}
            }
            return DidShieldBreak;

        }

        private void Dying(VGameObj dyingObj)
        {
            BattlePage bp = GetBattlePage();
            if (bp != null)
            {
                bp.SetDying(dyingObj);
            }
        }

		private BattlePage GetBattlePage()
		{
			// Temporary Propagation
			Page currPage = null;
			if (Application.Current.MainPage.Navigation.NavigationStack.Count > 0)
			{
				int index = Application.Current.MainPage.Navigation.NavigationStack.Count - 1;
				currPage = Application.Current.MainPage.Navigation.NavigationStack[index];
			}
			if (currPage != null)
			{
				return currPage as BattlePage;
			}
			return null;
		}
		private TextBattlePage GetTextBattlePage()
		{
			// Temporary Propagation
			Page currPage = null;
			if (Application.Current.MainPage.Navigation.NavigationStack.Count > 0)
			{
				int index = Application.Current.MainPage.Navigation.NavigationStack.Count - 1;
				currPage = Application.Current.MainPage.Navigation.NavigationStack[index];
			}
			if (currPage != null)
			{
				return currPage as TextBattlePage;
			}
			return null;
		}
	}
}
