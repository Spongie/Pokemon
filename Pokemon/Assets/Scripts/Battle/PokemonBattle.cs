using PokemonGame.Assets.Scripts.Character;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PokemonGame.Assets.Scripts.Battle
{
    public class PokemonBattle
    {
        public Party player;
        public Party enemy;

        public Pokemon PlayerActivePokemon;
        public Pokemon EnemyActivePokemon;

        public void Start()
        {
            PlayerActivePokemon = player.GetFirstAlivePokemon();
            EnemyActivePokemon = enemy.GetFirstAlivePokemon();
        }
    }
}
