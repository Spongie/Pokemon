using UnityEngine;
using System.Collections;
using UnityEditor;
using System.Linq;
using PokemonGame.Assets.Scripts.Character.Stats;
using PokemonGame.Assets.Scripts.Character;
using System.Collections.Generic;

[CustomEditor(typeof(PokemonBehaviour), true)]
public class PokemonBehaviourEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        if (GUILayout.Button("Randomize IV's"))
        {
            IVStats ivs = ((PokemonBehaviour)target).PokemonEntity.Stats.IVs;

            ivs.Health = Random.Range(0, 31);
            ivs.Attack = Random.Range(0, 31);
            ivs.Defense = Random.Range(0, 31);
            ivs.SpAttack = Random.Range(0, 31);
            ivs.SpDefense = Random.Range(0, 31);
            ivs.Speed = Random.Range(0, 31);
        }

        if (GUILayout.Button("Randomize EV's"))
        {
            ((PokemonBehaviour)target).PokemonEntity.Stats.EVs = GetRandomEvPreset();
        }
    }

    private EVStats GetRandomEvPreset()
    {
        return GetEvPresets().OrderBy(r => Random.Range(0, int.MaxValue)).FirstOrDefault();
    }

    private List<EVStats> GetEvPresets()
    {
        var evList = new List<EVStats>();

        evList.Add(new EVStats()
        {
            Attack = 252,
            Speed = 252,
            Defense = 6
        });

        evList.Add(new EVStats()
        {
            SpDefense = 252,
            Health = 252,
            Defense = 6
        });

        evList.Add(new EVStats()
        {
            Defense = 252,
            Health = 252,
            SpDefense = 6
        });

        evList.Add(new EVStats()
        {
            Attack = 252,
            Health = 252,
            Defense = 6
        });

        evList.Add(new EVStats()
        {
            SpAttack = 252,
            Speed = 252,
            Defense = 6
        });

        evList.Add(new EVStats()
        {
            Attack = 252,
            Speed = 252,
            Health = 6
        });

        evList.Add(new EVStats()
        {
            SpAttack = 252,
            Speed = 252,
            Health = 6
        });

        evList.Add(new EVStats()
        {
            SpDefense = 252,
            Defense = 252,
            Health = 6
        });

        evList.Add(new EVStats()
        {
            Attack = 252,
            Defense = 252,
            SpDefense = 6
        });

        return evList;
    }
}
