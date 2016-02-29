using PokemonGame.Assets.Scripts.Battle;
using PokemonGame.Assets.Scripts.Character;
using PokemonGame.Assets.Scripts.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

namespace PokemonGame.Assets.Scripts
{
    public class BattleTester : MonoBehaviour
    {
        public GameObject battleObject;

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.K))
            {
                PokemonBattle battle = battleObject.GetComponent<PokemonBattle>();

                Party playerParty = new Party();
                playerParty.Pokemons.Add(PokemonManager.Pokemons.First().Value.GetComponent<PokemonBehaviour>().PokemonEntity);
                playerParty.Pokemons[0].Stats.Exp.Level = 50;
                playerParty.Pokemons[0].Stats.CurrentHealth = playerParty.Pokemons[0].Stats.GetRealStats().Health;

                Party enemyParty = new Party();
                enemyParty.Pokemons.Add(PokemonManager.Pokemons[1].GetComponent<PokemonBehaviour>().PokemonEntity);
                enemyParty.Pokemons[0].Stats.Exp.Level = 50;
                enemyParty.Pokemons[0].Stats.CurrentHealth = enemyParty.Pokemons[0].Stats.GetRealStats().Health;

                battle.player = playerParty;
                battle.enemy = enemyParty;

                battleObject.SetActive(true);
            }
        }
    }
}
