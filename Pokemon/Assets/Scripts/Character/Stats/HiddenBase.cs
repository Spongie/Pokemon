using System;

namespace PokemonGame.Assets.Scripts.Character.Stats
{
    [Serializable]
    public class HiddenBase
    {
        [Range(0, 31)]
        public int Health { get; set; }

        [Range(0, 31)]
        public int Attack { get; set; }

        [Range(0, 31)]
        public int Defense { get; set; }

        [Range(0, 31)]
        public int SpAttack { get; set; }

        [Range(0, 31)]
        public int SpDefense { get; set; }

        [Range(0, 31)]
        public int Speed { get; set; }
    }
}
