using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PokemonGame.Assets.Scripts.Character
{
    public class Party
    {
        public List<Pokemon> Pokemons;

        public Party()
        {
            Pokemons = new List<Pokemon>(6);
        }

        public Pokemon GetFirstAlivePokemon()
        {
            foreach (Pokemon pokemon in Pokemons)
            {
                if (pokemon.IsAlive())
                    return pokemon;
            }

            return null;
        }

        public bool IsAllPokemonDead()
        {
            return Pokemons.Count(pokemon => !pokemon.IsAlive()) == Pokemons.Count;
        }
    }
}
