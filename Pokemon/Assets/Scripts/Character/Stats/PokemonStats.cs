using System.Reflection;
using UnityEngine;

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
        }

        private IntLimiter GetMinMaxOfStat(PropertyInfo property)
        {
            return (IntLimiter)property.GetCustomAttributes(typeof(IntLimiter), false)[0];
        }

        public BaseStats GetRealStats()
        {
            var stats = new BaseStats();

            stats.Health = ((baseStats.Health * 2 + hiddenStats.Health + (trainedStats.Health / 4)) * Exp.Level / 100 + 10);
            stats.Attack = ((baseStats.Attack * 2 + hiddenStats.Attack + (trainedStats.Attack / 4)) * Exp.Level / 100 + 5);
            stats.SpAttack = ((baseStats.Attack * 2 + hiddenStats.SpAttack + (trainedStats.SpAttack/ 4)) * Exp.Level / 100 + 5);
            stats.SpDefense = ((baseStats.Attack * 2 + hiddenStats.SpDefense + (trainedStats.SpDefense / 4)) * Exp.Level / 100 + 5);
            stats.Defense = ((baseStats.Attack * 2 + hiddenStats.Defense + (trainedStats.Defense / 4)) * Exp.Level / 100 + 5);
            stats.Speed = ((baseStats.Attack * 2 + hiddenStats.Speed + (trainedStats.Speed / 4)) * Exp.Level / 100 + 5);

            return stats;
        }
    }
}
