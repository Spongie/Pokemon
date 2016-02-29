using PokemonGame.Assets.Scripts.Battle;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

namespace PokemonGame.Assets.Scripts.UI
{
    public class BattleUI : MonoBehaviour
    {
        public Text playerActiveText;
        public Text enemyActiveText;
        public PokemonBattle battle;

        void Start()
        {
            playerActiveText = GameObject.Find("PlayerActiveHealth").GetComponent<Text>();
            enemyActiveText = GameObject.Find("EnemyActiveHealth").GetComponent<Text>();
        }

        void Update()
        {
            playerActiveText.text = string.Format("Player - {0}/{1}", battle.PlayerActivePokemon.Stats.CurrentHealth, battle.PlayerActivePokemon.Stats.GetRealStats().Health);
            enemyActiveText.text =  string.Format("Enemy  - {0}/{1}", battle.EnemyActivePokemon.Stats.CurrentHealth, battle.EnemyActivePokemon.Stats.GetRealStats().Health);
        }
    }
}
