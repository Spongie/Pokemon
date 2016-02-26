using System;

namespace PokemonGame.Assets.Scripts.Character.Stats
{
    [Serializable]
    public class HiddenBase
    {
        [IntLimiter(0, 31)]
        public float Health;

        [IntLimiter(0, 31)]
        public float Attack;

        [IntLimiter(0, 31)]
        public float Defense;

        [IntLimiter(0, 31)]
        public float SpAttack;

        [IntLimiter(0, 31)]
        public float SpDefense;

        [IntLimiter(0, 31)]
        public float Speed;
    }
}
