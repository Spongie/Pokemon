using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PokemonGame.Assets.Scripts.Character;

namespace PokemonGame.Assets.Scripts.Battle.Attacks
{
    public class StatusApplyingAttack : Attack
    {
        public StatusType StatusToApply;
        public int ChanceToApply;

        public override void ApplyEffect(Pokemon target)
        {

        }
    }
}
