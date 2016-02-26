using PokemonGame.Assets.Scripts.Character.Stats;
using PokemonGame.Assets.Scripts.Utility;
using UnityEngine;

namespace PokemonGame.Assets.Scripts.Character
{
    [RequireComponent(typeof(PokemonStats))]
    [RequireComponent(typeof(PokemonInfo))]
    public class Pokemon : MonoBehaviour
    {
        public PokemonInfo Info;
        public PokemonStats Stats;

        void Start()
        {
            Info = GetComponent<PokemonInfo>();
            Stats = GetComponent<PokemonStats>();
        }

        public void FullyRestore()
        {
            Stats.CurrentHealth = (int)Stats.GetRealStats().Health;
        }
    }
}
