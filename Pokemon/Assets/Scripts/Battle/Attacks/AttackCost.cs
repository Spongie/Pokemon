using PokemonGame.Assets.Scripts.Character.Stats;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PokemonGame.Assets.Scripts.Battle.Attacks
{
    [Serializable]
    public class AttackCost
    {
        public int Amount;
        public PokemonType CostType;
    }
}
