using System;

namespace PokemonGame.Assets.Scripts.Character.Stats
{
    [Serializable]
    public class HiddenBase
    {
        [IntLimiter(0, 31)]
        public int Health;

        [IntLimiter(0, 31)]
        public int Attack;

        [IntLimiter(0, 31)]
        public int Defense;

        [IntLimiter(0, 31)]
        public int SpAttack;

        [IntLimiter(0, 31)]
        public int SpDefense;

        [IntLimiter(0, 31)]
        public int Speed;
    }
}
