using PokemonGame.Assets.Scripts.Battle.Attacks;
using PokemonGame.Assets.Scripts.Character;
using PokemonGame.Assets.Scripts.Character.Stats;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PokemonGame.Assets.Scripts.Battle
{
    public class BattleCalculations
    {
        public static int CalculateDamage(Pokemon attacker, Pokemon defender, Attack attack)
        {
            return 30;
        }

        public static int CalculateStatusDamage(Pokemon pokemon)
        {
            if (pokemon.CurrentStatus == StatusType.Burn || pokemon.CurrentStatus == StatusType.Poison)
                return pokemon.GetStats().Health / 16;
            else if (pokemon.CurrentStatus == StatusType.BadlyPoison)
            {
                return (pokemon.GetStats().Health / 16) * pokemon.TurnsWithCurrentStatus;
            }

            return 0;
        }

        public static float GetEffectivnessModifer(PokemonType attackType, List<PokemonType> defenderTypes)
        {
            switch (attackType)
            {
                case PokemonType.Normal:
                    return GetNormalModifiers(defenderTypes);
                case PokemonType.Fire:
                    return GetFireModifiers(defenderTypes);
                case PokemonType.Fighting:
                    return GetFightingModifiers(defenderTypes);
                case PokemonType.Water:
                    return GetWaterModifiers(defenderTypes);
                case PokemonType.Flying:
                    return GetFlyingModifiers(defenderTypes);
                case PokemonType.Grass:
                    return GetGrassModifiers(defenderTypes);
                case PokemonType.Poison:
                    return GetPoisonModifiers(defenderTypes);
                case PokemonType.Electric:
                    return GetElectricModifiers(defenderTypes);
                case PokemonType.Ground:
                    return GetGroundModifiers(defenderTypes);
                case PokemonType.Psychic:
                    return GetPsycichModifiers(defenderTypes);
                case PokemonType.Rock:
                    return GetRockModifiers(defenderTypes);
                case PokemonType.Ice:
                    return GetIceModifiers(defenderTypes);
                case PokemonType.Bug:
                    return GetBugModifiers(defenderTypes);
                case PokemonType.Dragon:
                    return GetDragonModifiers(defenderTypes);
                case PokemonType.Ghost:
                    return GetGhostModifiers(defenderTypes);
                case PokemonType.Dark:
                    return GetDarkModifiers(defenderTypes);
                case PokemonType.Steel:
                    return GetSteelModifiers(defenderTypes);
                case PokemonType.Fairy:
                    return GetFairyModifiers(defenderTypes);
                default:
                    return 0f;
            }
        }

        private static float GetNormalModifiers(List<PokemonType> defenderTypes)
        {
            float modifier = 1f;

            if (defenderTypes.Contains(PokemonType.Rock))
                modifier -= 0.25f;
            if (defenderTypes.Contains(PokemonType.Steel))
                modifier -= 0.25f;
            if (defenderTypes.Contains(PokemonType.Ghost))
                modifier = 0f;

            if (modifier == 0.5f)
                modifier = 0.25f;
            else if (modifier == 0.75f)
                modifier = 0.5f;
            else if (modifier == 1.25f)
                modifier = 2f;
            else if (modifier == 1.5f)
                modifier = 4f;

            return modifier;
        }

        private static float GetFightingModifiers(List<PokemonType> defenderTypes)
        {
            float modifier = 1f;

            if (defenderTypes.Contains(PokemonType.Flying))
                modifier -= 0.25f;
            if (defenderTypes.Contains(PokemonType.Poison))
                modifier -= 0.25f;
            if (defenderTypes.Contains(PokemonType.Normal))
                modifier += 0.25f;
            if (defenderTypes.Contains(PokemonType.Rock))
                modifier += 0.25f;
            if (defenderTypes.Contains(PokemonType.Bug))
                modifier -= 0.25f;
            if (defenderTypes.Contains(PokemonType.Steel))
                modifier += 0.25f;
            if (defenderTypes.Contains(PokemonType.Psychic))
                modifier -= 0.25f;
            if (defenderTypes.Contains(PokemonType.Ice))
                modifier += 0.25f;
            if (defenderTypes.Contains(PokemonType.Fairy))
                modifier -= 0.25f;
            if (defenderTypes.Contains(PokemonType.Dark))
                modifier += 0.25f;
            if (defenderTypes.Contains(PokemonType.Ghost))
                modifier = 0f;

            if (modifier == 0.5f)
                modifier = 0.25f;
            else if (modifier == 0.75f)
                modifier = 0.5f;
            else if (modifier == 1.25f)
                modifier = 2f;
            else if (modifier == 1.5f)
                modifier = 4f;

            return modifier;
        }

        private static float GetFlyingModifiers(List<PokemonType> defenderTypes)
        {
            float modifier = 1f;

            if (defenderTypes.Contains(PokemonType.Fighting))
                modifier += 0.25f;
            if (defenderTypes.Contains(PokemonType.Rock))
                modifier -= 0.25f;
            if (defenderTypes.Contains(PokemonType.Bug))
                modifier += 0.25f;
            if (defenderTypes.Contains(PokemonType.Steel))
                modifier -= 0.25f;
            if (defenderTypes.Contains(PokemonType.Psychic))
                modifier -= 0.25f;
            if (defenderTypes.Contains(PokemonType.Grass))
                modifier += 0.25f;
            if (defenderTypes.Contains(PokemonType.Electric))
                modifier -= 0.25f;

            if (modifier == 0.5f)
                modifier = 0.25f;
            else if (modifier == 0.75f)
                modifier = 0.5f;
            else if (modifier == 1.25f)
                modifier = 2f;
            else if (modifier == 1.5f)
                modifier = 4f;

            return modifier;
        }

        private static float GetPoisonModifiers(List<PokemonType> defenderTypes)
        {
            float modifier = 1f;

            if (defenderTypes.Contains(PokemonType.Poison))
                modifier -= 0.25f;
            if (defenderTypes.Contains(PokemonType.Rock))
                modifier -= 0.25f;
            if (defenderTypes.Contains(PokemonType.Ground))
                modifier -= 0.25f;
            if (defenderTypes.Contains(PokemonType.Ghost))
                modifier -= 0.25f;
            if (defenderTypes.Contains(PokemonType.Grass))
                modifier += 0.25f;
            if (defenderTypes.Contains(PokemonType.Fairy))
                modifier += 0.25f;
            if (defenderTypes.Contains(PokemonType.Steel))
                modifier = 0f;

            if (modifier == 0.5f)
                modifier = 0.25f;
            else if (modifier == 0.75f)
                modifier = 0.5f;
            else if (modifier == 1.25f)
                modifier = 2f;
            else if (modifier == 1.5f)
                modifier = 4f;

            return modifier;
        }

        private static float GetGroundModifiers(List<PokemonType> defenderTypes)
        {
            float modifier = 1f;

            if (defenderTypes.Contains(PokemonType.Poison))
                modifier += 0.25f;
            if (defenderTypes.Contains(PokemonType.Rock))
                modifier += 0.25f;
            if (defenderTypes.Contains(PokemonType.Bug))
                modifier -= 0.25f;
            if (defenderTypes.Contains(PokemonType.Steel))
                modifier += 0.25f;
            if (defenderTypes.Contains(PokemonType.Fire))
                modifier += 0.25f;
            if (defenderTypes.Contains(PokemonType.Grass))
                modifier -= 0.25f;
            if (defenderTypes.Contains(PokemonType.Electric))
                modifier += 0.25f;
            if (defenderTypes.Contains(PokemonType.Flying))
                modifier = 0f;

            if (modifier == 0.5f)
                modifier = 0.25f;
            else if (modifier == 0.75f)
                modifier = 0.5f;
            else if (modifier == 1.25f)
                modifier = 2f;
            else if (modifier == 1.5f)
                modifier = 4f;

            return modifier;
        }

        private static float GetRockModifiers(List<PokemonType> defenderTypes)
        {
            float modifier = 1f;

            if (defenderTypes.Contains(PokemonType.Fighting))
                modifier -= 0.25f;
            if (defenderTypes.Contains(PokemonType.Flying))
                modifier += 0.25f;
            if (defenderTypes.Contains(PokemonType.Ground))
                modifier -= 0.25f;
            if (defenderTypes.Contains(PokemonType.Bug))
                modifier += 0.25f;
            if (defenderTypes.Contains(PokemonType.Fire))
                modifier += 0.25f;
            if (defenderTypes.Contains(PokemonType.Steel))
                modifier -= 0.25f;
            if (defenderTypes.Contains(PokemonType.Ice))
                modifier += 0.25f;

            if (modifier == 0.5f)
                modifier = 0.25f;
            else if (modifier == 0.75f)
                modifier = 0.5f;
            else if (modifier == 1.25f)
                modifier = 2f;
            else if (modifier == 1.5f)
                modifier = 4f;

            return modifier;
        }

        private static float GetBugModifiers(List<PokemonType> defenderTypes)
        {
            float modifier = 1f;

            if (defenderTypes.Contains(PokemonType.Fighting))
                modifier -= 0.25f;
            if (defenderTypes.Contains(PokemonType.Flying))
                modifier -= 0.25f;
            if (defenderTypes.Contains(PokemonType.Poison))
                modifier -= 0.25f;
            if (defenderTypes.Contains(PokemonType.Ghost))
                modifier -= 0.25f;
            if (defenderTypes.Contains(PokemonType.Fire))
                modifier -= 0.25f;
            if (defenderTypes.Contains(PokemonType.Steel))
                modifier -= 0.25f;
            if (defenderTypes.Contains(PokemonType.Psychic))
                modifier += 0.25f;
            if (defenderTypes.Contains(PokemonType.Grass))
                modifier += 0.25f;
            if (defenderTypes.Contains(PokemonType.Dark))
                modifier += 0.25f;
            if (defenderTypes.Contains(PokemonType.Fairy))
                modifier -= 0.25f;

            if (modifier == 0.5f)
                modifier = 0.25f;
            else if (modifier == 0.75f)
                modifier = 0.5f;
            else if (modifier == 1.25f)
                modifier = 2f;
            else if (modifier == 1.5f)
                modifier = 4f;

            return modifier;
        }

        private static float GetGhostModifiers(List<PokemonType> defenderTypes)
        {
            float modifier = 1f;

            if (defenderTypes.Contains(PokemonType.Ghost))
                modifier += 0.25f;
            if (defenderTypes.Contains(PokemonType.Psychic))
                modifier += 0.25f;
            if (defenderTypes.Contains(PokemonType.Dark))
                modifier -= 0.25f;
            if (defenderTypes.Contains(PokemonType.Normal))
                modifier = 0f;

            if (modifier == 0.5f)
                modifier = 0.25f;
            else if (modifier == 0.75f)
                modifier = 0.5f;
            else if (modifier == 1.25f)
                modifier = 2f;
            else if (modifier == 1.5f)
                modifier = 4f;

            return modifier;
        }

        private static float GetSteelModifiers(List<PokemonType> defenderTypes)
        {
            float modifier = 1f;

            if (defenderTypes.Contains(PokemonType.Rock))
                modifier += 0.25f;
            if (defenderTypes.Contains(PokemonType.Steel))
                modifier -= 0.25f;
            if (defenderTypes.Contains(PokemonType.Fire))
                modifier -= 0.25f;
            if (defenderTypes.Contains(PokemonType.Water))
                modifier -= 0.25f;
            if (defenderTypes.Contains(PokemonType.Electric))
                modifier -= 0.25f;
            if (defenderTypes.Contains(PokemonType.Ice))
                modifier += 0.25f;
            if (defenderTypes.Contains(PokemonType.Fairy))
                modifier += 0.25f;

            if (modifier == 0.5f)
                modifier = 0.25f;
            else if (modifier == 0.75f)
                modifier = 0.5f;
            else if (modifier == 1.25f)
                modifier = 2f;
            else if (modifier == 1.5f)
                modifier = 4f;

            return modifier;
        }

        private static float GetFireModifiers(List<PokemonType> defenderTypes)
        {
            float modifier = 1f;

            if (defenderTypes.Contains(PokemonType.Rock))
                modifier -= 0.25f;
            if (defenderTypes.Contains(PokemonType.Bug))
                modifier += 0.25f;
            if (defenderTypes.Contains(PokemonType.Steel))
                modifier += 0.25f;
            if (defenderTypes.Contains(PokemonType.Water))
                modifier -= 0.25f;
            if (defenderTypes.Contains(PokemonType.Fire))
                modifier -= 0.25f;
            if (defenderTypes.Contains(PokemonType.Grass))
                modifier += 0.25f;
            if (defenderTypes.Contains(PokemonType.Ice))
                modifier += 0.25f;
            if (defenderTypes.Contains(PokemonType.Dragon))
                modifier -= 0.25f;

            if (modifier == 0.5f)
                modifier = 0.25f;
            else if (modifier == 0.75f)
                modifier = 0.5f;
            else if (modifier == 1.25f)
                modifier = 2f;
            else if (modifier == 1.5f)
                modifier = 4f;

            return modifier;
        }

        private static float GetWaterModifiers(List<PokemonType> defenderTypes)
        {
            float modifier = 1f;

            if (defenderTypes.Contains(PokemonType.Rock))
                modifier += 0.25f;
            if (defenderTypes.Contains(PokemonType.Ground))
                modifier += 0.25f;
            if (defenderTypes.Contains(PokemonType.Fire))
                modifier += 0.25f;
            if (defenderTypes.Contains(PokemonType.Water))
                modifier -= 0.25f;
            if (defenderTypes.Contains(PokemonType.Grass))
                modifier -= 0.25f;
            if (defenderTypes.Contains(PokemonType.Dragon))
                modifier -= 0.25f;

            if (modifier == 0.5f)
                modifier = 0.25f;
            else if (modifier == 0.75f)
                modifier = 0.5f;
            else if (modifier == 1.25f)
                modifier = 2f;
            else if (modifier == 1.5f)
                modifier = 4f;

            return modifier;
        }

        private static float GetGrassModifiers(List<PokemonType> defenderTypes)
        {
            float modifier = 1f;

            if (defenderTypes.Contains(PokemonType.Flying))
                modifier -= 0.25f;
            if (defenderTypes.Contains(PokemonType.Poison))
                modifier -= 0.25f;
            if (defenderTypes.Contains(PokemonType.Rock))
                modifier += 0.25f;
            if (defenderTypes.Contains(PokemonType.Ground))
                modifier += 0.25f;
            if (defenderTypes.Contains(PokemonType.Bug))
                modifier -= 0.25f;
            if (defenderTypes.Contains(PokemonType.Steel))
                modifier -= 0.25f;
            if (defenderTypes.Contains(PokemonType.Fire))
                modifier -= 0.25f;
            if (defenderTypes.Contains(PokemonType.Water))
                modifier += 0.25f;
            if (defenderTypes.Contains(PokemonType.Grass))
                modifier -= 0.25f;
            if (defenderTypes.Contains(PokemonType.Dragon))
                modifier -= 0.25f;

            if (modifier == 0.5f)
                modifier = 0.25f;
            else if (modifier == 0.75f)
                modifier = 0.5f;
            else if (modifier == 1.25f)
                modifier = 2f;
            else if (modifier == 1.5f)
                modifier = 4f;

            return modifier;
        }

        private static float GetElectricModifiers(List<PokemonType> defenderTypes)
        {
            float modifier = 1f;

            if (defenderTypes.Contains(PokemonType.Flying))
                modifier += 0.25f;
            if (defenderTypes.Contains(PokemonType.Water))
                modifier += 0.25f;
            if (defenderTypes.Contains(PokemonType.Grass))
                modifier -= 0.25f;
            if (defenderTypes.Contains(PokemonType.Electric))
                modifier -= 0.25f;
            if (defenderTypes.Contains(PokemonType.Dragon))
                modifier -= 0.25f;
            if (defenderTypes.Contains(PokemonType.Ground))
                modifier = 0f;

            if (modifier == 0.5f)
                modifier = 0.25f;
            else if (modifier == 0.75f)
                modifier = 0.5f;
            else if (modifier == 1.25f)
                modifier = 2f;
            else if (modifier == 1.5f)
                modifier = 4f;

            return modifier;
        }

        private static float GetPsycichModifiers(List<PokemonType> defenderTypes)
        {
            float modifier = 1f;

            if (defenderTypes.Contains(PokemonType.Fighting))
                modifier += 0.25f;
            if (defenderTypes.Contains(PokemonType.Poison))
                modifier += 0.25f;
            if (defenderTypes.Contains(PokemonType.Steel))
                modifier -= 0.25f;
            if (defenderTypes.Contains(PokemonType.Psychic))
                modifier -= 0.25f;
            if (defenderTypes.Contains(PokemonType.Dark))
                modifier = 0f;

            if (modifier == 0.5f)
                modifier = 0.25f;
            else if (modifier == 0.75f)
                modifier = 0.5f;
            else if (modifier == 1.25f)
                modifier = 2f;
            else if (modifier == 1.5f)
                modifier = 4f;

            return modifier;
        }

        private static float GetIceModifiers(List<PokemonType> defenderTypes)
        {
            float modifier = 1f;

            if (defenderTypes.Contains(PokemonType.Flying))
                modifier += 0.25f;
            if (defenderTypes.Contains(PokemonType.Ground))
                modifier += 0.25f;
            if (defenderTypes.Contains(PokemonType.Steel))
                modifier -= 0.25f;
            if (defenderTypes.Contains(PokemonType.Fire))
                modifier -= 0.25f;
            if (defenderTypes.Contains(PokemonType.Water))
                modifier -= 0.25f;
            if (defenderTypes.Contains(PokemonType.Grass))
                modifier += 0.25f;
            if (defenderTypes.Contains(PokemonType.Dragon))
                modifier += 0.25f;
            if (defenderTypes.Contains(PokemonType.Ice))
                modifier -= 0.25f;

            if (modifier == 0.5f)
                modifier = 0.25f;
            else if (modifier == 0.75f)
                modifier = 0.5f;
            else if (modifier == 1.25f)
                modifier = 2f;
            else if (modifier == 1.5f)
                modifier = 4f;

            return modifier;
        }

        private static float GetDragonModifiers(List<PokemonType> defenderTypes)
        {
            float modifier = 1f;

            if (defenderTypes.Contains(PokemonType.Steel))
                modifier -= 0.25f;
            if (defenderTypes.Contains(PokemonType.Dragon))
                modifier += 0.25f;
            if (defenderTypes.Contains(PokemonType.Fairy))
                modifier = 0f;

            if (modifier == 0.5f)
                modifier = 0.25f;
            else if (modifier == 0.75f)
                modifier = 0.5f;
            else if (modifier == 1.25f)
                modifier = 2f;
            else if (modifier == 1.5f)
                modifier = 4f;

            return modifier;
        }

        private static float GetDarkModifiers(List<PokemonType> defenderTypes)
        {
            float modifier = 1f;

            if (defenderTypes.Contains(PokemonType.Fighting))
                modifier -= 0.25f;
            if (defenderTypes.Contains(PokemonType.Ghost))
                modifier += 0.25f;
            if (defenderTypes.Contains(PokemonType.Psychic))
                modifier += 0.25f;
            if (defenderTypes.Contains(PokemonType.Dark))
                modifier -= 0.25f;
            if (defenderTypes.Contains(PokemonType.Fairy))
                modifier -= 0.25f;

            if (modifier == 0.5f)
                modifier = 0.25f;
            else if (modifier == 0.75f)
                modifier = 0.5f;
            else if (modifier == 1.25f)
                modifier = 2f;
            else if (modifier == 1.5f)
                modifier = 4f;

            return modifier;
        }

        private static float GetFairyModifiers(List<PokemonType> defenderTypes)
        {
            float modifier = 1f;

            if (defenderTypes.Contains(PokemonType.Fighting))
                modifier += 0.25f;
            if (defenderTypes.Contains(PokemonType.Poison))
                modifier -= 0.25f;
            if (defenderTypes.Contains(PokemonType.Steel))
                modifier -= 0.25f;
            if (defenderTypes.Contains(PokemonType.Fire))
                modifier -= 0.25f;
            if (defenderTypes.Contains(PokemonType.Dragon))
                modifier += 0.25f;
            if (defenderTypes.Contains(PokemonType.Dark))
                modifier += 0.25f;

            if (modifier == 0.5f)
                modifier = 0.25f;
            else if (modifier == 0.75f)
                modifier = 0.5f;
            else if (modifier == 1.25f)
                modifier = 2f;
            else if (modifier == 1.5f)
                modifier = 4f;

            return modifier;
        }
    }
}
