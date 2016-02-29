using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace PokemonGame.Assets.Scripts.Utility
{
    public class AttackManager : MonoBehaviour
    {
        public static List<GameObject> Attacks;

        public void Start()
        {
            Attacks = new List<GameObject>();

            var attacks = Resources.LoadAll<GameObject>("Attacks/");

            foreach (var attack in attacks)
            {
                GameObject spawned = Instantiate(attack);
                spawned.transform.SetParent(transform);
                spawned.transform.position = Vector3.zero;

                spawned.name = spawned.name.Replace("(Clone)", string.Empty);

                Attacks.Add(spawned);
            }

            PokemonLogger.Log(string.Format("Loaded {0} attacks to cache", Attacks.Count));
        }
    }
}
