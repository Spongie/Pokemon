using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace PokemonGame.Assets.Scripts.Character
{
    public class Trainer : MonoBehaviour
    {
        public List<GameObject> TrainerPokemon;
        public List<string> Dialog;

        public Party GetTrainerParty()
        {
            var pokemons = new List<Pokemon>();

            foreach (GameObject pokemonObject in TrainerPokemon)
            {
                Pokemon pokemon = pokemonObject.GetComponent<PokemonBehaviour>().PokemonEntity.Copy();
                pokemon.FullyRestore();
                pokemons.Add(pokemon);
            }

            return new Party()
            {
                Pokemons = pokemons
            };
        }
    }
}
