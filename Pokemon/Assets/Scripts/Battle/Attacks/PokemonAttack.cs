using System;

namespace PokemonGame.Assets.Scripts.Battle.Attacks
{
    [Serializable]
    public class PokemonAttack
    {
        public Attack attack;
        public int UnlockedAtLevel;

        public static explicit operator Attack(PokemonAttack pokemonAttack)
        {
            return pokemonAttack.attack;
        }
    }
}
