using PokemonGame.Assets.Scripts.Character;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace PokemonGame.Assets.Scripts.Utility
{
    [CreateAssetMenu(menuName = "SpawnGroup")]
    public class SpawnGroup : ScriptableObject
    {
        [Range(2, 100)]
        public int MinLevel;

        [Range(2, 100)]
        public int MaxLevel;

        public List<GameObject> Pokemons;

        public Pokemon GetRandomPokemon()
        {
            Pokemon pokemon = Pokemons.OrderBy(x => Random.Range(0, int.MaxValue)).First().GetComponent<Pokemon>().Copy();
            pokemon.Stats.GenereateHiddenStats();
            pokemon.SetLevel(Random.Range(MinLevel, MaxLevel));

            return pokemon;
        }

        [ExecuteInEditMode]
        void OnValidate()
        {
            if (MaxLevel < MinLevel)
                MaxLevel = MinLevel;
        }
    }
}
