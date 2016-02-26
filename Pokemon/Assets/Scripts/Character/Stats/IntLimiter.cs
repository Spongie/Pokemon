using System;

namespace PokemonGame.Assets.Scripts.Character.Stats
{
    [AttributeUsage(AttributeTargets.Field)]
    public class IntLimiter : Attribute
    {
        public int min;
        public int max;

        public IntLimiter(int min, int max)
        {
            this.min = min;
            this.max = max;
        }
    }
}
