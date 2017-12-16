﻿using System;
namespace CadmusDND
{
    public class MagicModel
    {
        private string type;
        private int itemid;
        private string name;
        private string attribMod;
        private int attribValues;
        public MagicModel()
        {
            
        }
        public MagicModel(int id, string n, string t, string am, int av)
        {
            this.Itemid = id;
            this.Name = n;
            this.Type = t;
            this.AttribMod = am;
            this.AttribValues = av;
        }

        public string Type { get; set; }

        public string AttribMod { get; set; }

        public int AttribValues { get; set; }
        public int Itemid { get; set; }
        public string Name { get; set; }
    }
}
