using PokemonGame.Assets.Scripts.Character;
using System;
using UnityEngine;

namespace PokemonGame.Assets.Scripts.Battle.Attacks
{
    [CreateAssetMenu(menuName = "Attacks/Status Attack")]
    [Serializable]
    public class StatusApplyingAttack : Attack
    {
        public StatusType StatusToApply;
        public int ChanceToApply;

        public override void ApplyEffect(Pokemon target, Pokemon attacker)
        {
            if (target.CurrentStatus == StatusType.None)
            {
                int random = UnityEngine.Random.Range(0, 100);

                if (random <= ChanceToApply)
                    target.ApplyStatus(StatusToApply);
            }
        }
    }
}
