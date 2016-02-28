using System;

namespace PokemonGame.Assets.Scripts.Character.Stats
{
    [Serializable]
    public class IVStats
    {
        [Range(0, 31)]
        public int Health;

        [Range(0, 31)]
        public int Attack;

        [Range(0, 31)]
        public int Defense;

        [Range(0, 31)]
        public int SpAttack;

        [Range(0, 31)]
        public int SpDefense;

        [Range(0, 31)]
        public int Speed;
    }
}
