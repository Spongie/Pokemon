using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PokemonGame.Assets.Scripts.Character;

namespace PokemonGame.Assets.Scripts.Battle.Attacks
{
    public class ResourceGeneratingAttack : Attack
    {
        public override void ApplyEffect(Pokemon target, Pokemon attacker)
        {
            foreach (AttackCost cost in Cost)
            {
                AttackCost resource = attacker.Resources.FirstOrDefault(r => r.CostType == cost.CostType);

                if (resource != null)
                    resource.Amount += cost.Amount;
                else
                    attacker.Resources.Add(new AttackCost() { CostType = cost.CostType, Amount = cost.Amount });
            }
        }
    }
}
