using PokemonGame.Assets.Scripts.Character;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace PokemonGame.Assets.Scripts.Utility
{
    public class PokemonManager : MonoBehaviour
    {
        private static Dictionary<int, GameObject> Pokemons;
        
        public void Start()
        {
            Pokemons = new Dictionary<int, GameObject>();

            var pokemons = Resources.LoadAll<GameObject>("Pokemons/");

            foreach (var pokemon in pokemons)
            {
                GameObject spawned = Instantiate(pokemon);
                spawned.transform.SetParent(transform);
                spawned.transform.position = Vector3.zero;

                Pokemons.Add(spawned.GetComponent<PokemonInfo>().ID, spawned);
            }

            PokemonLogger.Log(string.Format("Loaded {0} pokemons to cache", Pokemons.Count));
        }

        public static GameObject GetPokemonById(int id)
        {
            return Pokemons[id];
        }

        public static PokemonInfo GetPokemonInfo(GameObject pokemon)
        {
            return pokemon.GetComponent<PokemonInfo>();
        }

        public static PokemonInfo GetPokemonInfo(int id)
        {
            return Pokemons[id].GetComponent<PokemonInfo>();
        }
    }
}
