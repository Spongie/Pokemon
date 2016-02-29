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
        public StatusType CurrentStatus;
        public int TurnsWithCurrentStatus;

        public Pokemon()
        {
            Attacks = new Attack[4];
            Types = new List<PokemonType>();
            Info = new PokemonInfo();
            Stats = new PokemonStats();
            CurrentStatus = StatusType.None;
        }

        public void FullyRestore()
        {
            Stats.CurrentHealth = Stats.GetRealStats(CurrentStatus).Health;
        }

        public bool IsAlive()
        {
            return Stats.CurrentHealth > 0;
        }

        public bool IsParalyzed()
        {
            return UnityEngine.Random.Range(0, 100) <= 25;
        }

        public BaseStats GetStats()
        {
            return Stats.GetRealStats(CurrentStatus);
        }

        public void ApplyStatus(StatusType status)
        {
            CurrentStatus = status;
            TurnsWithCurrentStatus = 0;
        }
    }
}
