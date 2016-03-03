using PokemonGame.Assets.Scripts.Battle.Attacks;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace PokemonGame.Assets.Scripts.Utility
{
    public class AttackManager : MonoBehaviour
    {
        public static List<Attack> Attacks;

        public void Start()
        {
            Attacks =  Resources.LoadAll<Attack>("Attacks/").ToList();

            PokemonLogger.Log(string.Format("Loaded {0} attacks to cache", Attacks.Count));
        }
    }
}
