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
            IntLimiter minMax = GetMinMaxOfStat(hiddenStats.GetType().GetProperty("Health"));
            hiddenStats.Health = Random.Range(minMax.min, minMax.max);

            minMax = GetMinMaxOfStat(hiddenStats.GetType().GetProperty("Attack"));
            hiddenStats.Attack = Random.Range(minMax.min, minMax.max);

            minMax = GetMinMaxOfStat(hiddenStats.GetType().GetProperty("SpAttack"));
            hiddenStats.SpAttack = Random.Range(minMax.min, minMax.max);

            minMax = GetMinMaxOfStat(hiddenStats.GetType().GetProperty("Defense"));
            hiddenStats.Defense = Random.Range(minMax.min, minMax.max);

            minMax = GetMinMaxOfStat(hiddenStats.GetType().GetProperty("SpDefense"));
            hiddenStats.SpDefense = Random.Range(minMax.min, minMax.max);

            minMax = GetMinMaxOfStat(hiddenStats.GetType().GetProperty("Speed"));
            hiddenStats.Speed = Random.Range(minMax.min, minMax.max);

            baseStats.Nature = (Natures)Random.Range(0, System.Enum.GetValues(typeof(Natures)).Cast<int>().Max());
        }

        internal BaseStats GetRealStats()
        {
            return baseStats.GetRealStats(hiddenStats, trainedStats, Exp.Level);
        }

        private IntLimiter GetMinMaxOfStat(PropertyInfo property)
        {
            return (IntLimiter)property.GetCustomAttributes(typeof(IntLimiter), false)[0];
        }        
    }
}
