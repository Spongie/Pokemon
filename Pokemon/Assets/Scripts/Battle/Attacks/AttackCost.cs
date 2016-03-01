using PokemonGame.Assets.Scripts.Character.Stats;
using System;

namespace PokemonGame.Assets.Scripts.Battle.Attacks
{
    [Serializable]
    public class AttackCost
    {
        public int Amount;
        public PokemonType CostType;
    }
}
