using PokemonGame.Assets.Scripts.Battle;
using PokemonGame.Assets.Scripts.Battle.Attacks;
using PokemonGame.Assets.Scripts.Character.Stats;
using PokemonGame.Assets.Scripts.Utility;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace PokemonGame.Assets.Scripts.Character
{
    [Serializable]
    public class Pokemon
    {
        public PokemonInfo Info;
        public PokemonStats Stats;
        public List<PokemonType> Types;
        public Attack[] Attacks;

        public Pokemon()
        {
            Attacks = new Attack[4];
            Types = new List<PokemonType>();
            Info = new PokemonInfo();
            Stats = new PokemonStats();
        }

        public void FullyRestore()
        {
            Stats.CurrentHealth = (int)Stats.GetRealStats().Health;
        }

        public bool IsAlive()
        {
            return Stats.CurrentHealth > 0;
        }
    }
}
