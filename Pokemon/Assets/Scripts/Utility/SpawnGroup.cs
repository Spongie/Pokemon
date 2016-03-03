using PokemonGame.Assets.Scripts.Character;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace PokemonGame.Assets.Scripts.Utility
{
    public class SpawnGroup : ScriptableObject
    {
        public int MinLevel;
        public int MaxLevel;
        public List<GameObject> Pokemons;

        public Pokemon GetRandomPokemon()
        {
            Pokemon pokemon = Pokemons.OrderBy(x => Random.Range(0, int.MaxValue)).First().GetComponent<Pokemon>().Copy();
            pokemon.Stats.GenereateHiddenStats();
            pokemon.SetLevel(Random.Range(MinLevel, MaxLevel));

            return pokemon;
        }
    }
}
