﻿using PokemonGame.Assets.Scripts.Battle;
using PokemonGame.Assets.Scripts.Battle.Attacks;
using PokemonGame.Assets.Scripts.Character.Stats;
using PokemonGame.Assets.Scripts.Utility;
using System;
using System.Linq;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
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
        public List<AttackCost> Resources;

        public Pokemon()
        {
            Attacks = new Attack[4];
            Types = new List<PokemonType>();
            Info = new PokemonInfo();
            Stats = new PokemonStats();
            CurrentStatus = StatusType.None;
            Resources = new List<AttackCost>();
        }

        public Pokemon Copy()
        {
            using (MemoryStream buffer = new MemoryStream())
            {
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(buffer, this);
                buffer.Position = 0;
                Pokemon copy = (Pokemon)formatter.Deserialize(buffer);
                return copy;
            }
        }

        public void FullyRestore()
        {
            Stats.CurrentHealth = Stats.GetRealStats(CurrentStatus).Health;
            CurrentStatus = StatusType.None;
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

        internal void DrainResources(List<AttackCost> attackCost)
        {
            foreach (AttackCost cost in attackCost)
            {
                AttackCost resource = Resources.First(c => c.CostType == cost.CostType);
                resource.Amount -= cost.Amount;

                if (resource.Amount == 0)
                    Resources.Remove(resource);
            }
        }
    }
}
