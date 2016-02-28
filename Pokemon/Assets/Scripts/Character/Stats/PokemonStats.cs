using System.Reflection;
using UnityEngine;
using System.Linq;

namespace PokemonGame.Assets.Scripts.Character.Stats
{
    public class PokemonStats : MonoBehaviour
    {
        public HiddenBase hiddenStats;
        public TrainedStats trainedStats;
        public BaseStats baseStats;
        public Experience Exp;
        public int CurrentHealth;

        public PokemonStats()
        {
            hiddenStats = new HiddenBase();
            trainedStats = new TrainedStats();
            baseStats = new BaseStats();
        }

        public void GenereateHiddenStats()
        {
            Range statRange = GetMinMaxOfStat(hiddenStats.GetType().GetProperty("Health"));
            hiddenStats.Health = Random.Range(statRange.Min, statRange.Max);

            statRange = GetMinMaxOfStat(hiddenStats.GetType().GetProperty("Attack"));
            hiddenStats.Attack = Random.Range(statRange.Min, statRange.Max);

            statRange = GetMinMaxOfStat(hiddenStats.GetType().GetProperty("SpAttack"));
            hiddenStats.SpAttack = Random.Range(statRange.Min, statRange.Max);

            statRange = GetMinMaxOfStat(hiddenStats.GetType().GetProperty("Defense"));
            hiddenStats.Defense = Random.Range(statRange.Min, statRange.Max);

            statRange = GetMinMaxOfStat(hiddenStats.GetType().GetProperty("SpDefense"));
            hiddenStats.SpDefense = Random.Range(statRange.Min, statRange.Max);

            statRange = GetMinMaxOfStat(hiddenStats.GetType().GetProperty("Speed"));
            hiddenStats.Speed = Random.Range(statRange.Min, statRange.Max);

            baseStats.Nature = (Natures)Random.Range(0, System.Enum.GetValues(typeof(Natures)).Cast<int>().Max());
        }

        internal BaseStats GetRealStats()
        {
            return baseStats.GetRealStats(hiddenStats, trainedStats, Exp.Level);
        }

        private Range GetMinMaxOfStat(PropertyInfo property)
        {
            return (Range)property.GetCustomAttributes(typeof(Range), false)[0];
        }        
    }
}
