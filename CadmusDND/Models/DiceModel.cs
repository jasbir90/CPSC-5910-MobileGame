using System;
namespace CadmusDND
{
    public class DiceModel
    {
        private int faces;
        private Random rand;
        public DiceModel(int size)
        {
            faces = size;
            rand = new Random();
        }

        public int Roll
        {
            get
            {
                return rand.Next(1, faces + 1);
            }
        }
    }
}
