using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PokemonGame.Assets.Scripts.Character;
using UnityEngine;

namespace PokemonGame.Assets.Scripts.Battle.Attacks
{
    [CreateAssetMenu(menuName = "Attacks/Basic Attack")]
    [Serializable]
    public class BasicAttack : Attack
    {
        public override void ApplyEffect(Pokemon target, Pokemon attacker)
        {

        }
    }
}
