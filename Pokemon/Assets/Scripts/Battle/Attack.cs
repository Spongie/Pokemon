using PokemonGame.Assets.Scripts.Character.Stats;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace PokemonGame.Assets.Scripts.Battle
{
    public enum AttackType
    {
        Physical,
        Special
    }

    public class Attack : MonoBehaviour
    {
        public string Name;
        public AttackType attackType;
        public int Power;
        public string Description;
        public PokemonType type;
    }
}
