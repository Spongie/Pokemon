using System;

namespace PokemonGame.Assets.Scripts.Character.Stats
{
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
    public class Range : Attribute
    {
        private int min;
        private int max;

        public Range(int min, int max)
        {
            Min = min;
            Max = max;
        }

        public int Max
        {
            get
            {
                return max;
            }

            set
            {
                max = value;
            }
        }

        public int Min
        {
            get
            {
                return min;
            }

            set
            {
                min = value;
            }
        }
    }
}
