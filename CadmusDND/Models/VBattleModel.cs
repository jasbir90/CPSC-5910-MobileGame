using System;
using System.Collections.Generic;

namespace CadmusDND
{
    public class VBattleModel
    {
        public static int MaxSlots = 4;
        public List<VGameObj> party = new List<VGameObj>();
        public List<VGameObj> monsters = new List<VGameObj>();
        public VBattleModel()
        {
            Reset();
        }

        public void Reset()
        {
		    party = new List<VGameObj>();
		    monsters = new List<VGameObj>();
	    }

        public void AddChar(CharacterModel cm)
        {
            VGameObj vgo = new VGameObj();
            vgo.SetCharacter(cm);
            party.Add(vgo);
        }
        public void AddMonster(MonsterModel mm)
        {
            VGameObj vgo = new VGameObj();
            vgo.SetMonster(mm);
            monsters.Add(vgo);
        }
    }
}
