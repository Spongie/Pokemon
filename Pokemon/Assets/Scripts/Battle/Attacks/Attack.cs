using PokemonGame.Assets.Scripts.Character;
using PokemonGame.Assets.Scripts.Character.Stats;
using System.Collections.Generic;
using UnityEngine;

namespace PokemonGame.Assets.Scripts.Battle.Attacks
{
    public enum AttackType
    {
        Physical,
        Special
    }

    public enum StatusType
    {
        Burn,
        Poison,
        BadlyPoison,
        Freeze,
        Confuse,
        Paralyze,
        None
    }

    public abstract class Attack : ScriptableObject
    {
        public string Name;
        public AttackType attackType;
        public int Power;
        public string Description;
        public PokemonType type;
        public List<AttackCost> Cost;

        public abstract void ApplyEffect(Pokemon target, Pokemon attacker);
    }
}
