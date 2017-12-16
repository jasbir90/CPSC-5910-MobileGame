using System;
using System.Collections.Generic;

namespace CadmusDND
{
    public class BattleModel
    {

        // Hold all the creatures that participate in the battle
        private List<CharacterModel> characters;
        private List<MonsterModel> monsters;
        private bool isOver;

        public BattleModel()
        {
            characters = new List<CharacterModel>();
            monsters = new List<MonsterModel>();
            isOver = false;
        }

        // Returns a list of all the characters participating in the battle
        public List<CharacterModel> CharacterCombatants
        {
            get { return characters; }
            set { characters = value; }
        }

        // Returns a list of all the monsters participating in the battle
        public List<MonsterModel> MonsterCombatants
        {
            get { return monsters; }
            set { monsters = value; }
        }

        // Returns the state of the battle:
        // False if not over, true if over.
        public bool State
        {
            get { return isOver; }
            set { isOver = value; }
        }
    }
}
