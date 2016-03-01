using PokemonGame.Assets.Scripts.Character;

namespace PokemonGame.Assets.Scripts.Battle.Attacks
{
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
