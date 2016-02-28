using System.Reflection;
using UnityEngine;
using System.Linq;

namespace PokemonGame.Assets.Scripts.Character.Stats
{
    [System.Serializable]
    public class PokemonStats
    {
        public IVStats IVs;
        public EVStats EVs;
        public BaseStats baseStats;
        public Experience Exp;
        public int CurrentHealth;

        public PokemonStats()
        {
            IVs = new IVStats();
            EVs = new EVStats();
            baseStats = new BaseStats();
        }

        public void GenereateHiddenStats()
        {
            Range statRange = GetMinMaxOfStat(IVs.GetType().GetProperty("Health"));
            IVs.Health = Random.Range(statRange.Min, statRange.Max);

            statRange = GetMinMaxOfStat(IVs.GetType().GetProperty("Attack"));
            IVs.Attack = Random.Range(statRange.Min, statRange.Max);

            statRange = GetMinMaxOfStat(IVs.GetType().GetProperty("SpAttack"));
            IVs.SpAttack = Random.Range(statRange.Min, statRange.Max);

            statRange = GetMinMaxOfStat(IVs.GetType().GetProperty("Defense"));
            IVs.Defense = Random.Range(statRange.Min, statRange.Max);

            statRange = GetMinMaxOfStat(IVs.GetType().GetProperty("SpDefense"));
            IVs.SpDefense = Random.Range(statRange.Min, statRange.Max);

            statRange = GetMinMaxOfStat(IVs.GetType().GetProperty("Speed"));
            IVs.Speed = Random.Range(statRange.Min, statRange.Max);

            baseStats.Nature = (Natures)Random.Range(0, System.Enum.GetValues(typeof(Natures)).Cast<int>().Max());
        }

        internal BaseStats GetRealStats()
        {
            return baseStats.GetRealStats(IVs, EVs, Exp.Level);
        }

        private Range GetMinMaxOfStat(PropertyInfo property)
        {
            return (Range)property.GetCustomAttributes(typeof(Range), false)[0];
        }        
    }
}
