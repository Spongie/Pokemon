using System;

namespace PokemonGame.Assets.Scripts.Character.Stats
{
    [Serializable]
    public class BaseStats
    {
        public int Health;
        public int Attack;
        public int Defense;
        public int SpAttack;
        public int SpDefense;
        public int Speed;
        public Natures Nature;

        public BaseStats GetRealStats(IVStats hiddenStats, EVStats trainedStats, int level)
        {
            var stats = new BaseStats();

            stats.Health = ((Health * 2 + hiddenStats.Health + (trainedStats.Health / 4)) * level / 100 + 10 + level);
            stats.Attack = (int)(((Attack * 2 + hiddenStats.Attack + (trainedStats.Attack / 4)) * level / 100 + 5) * GetAttackModifier());
            stats.SpAttack = (int)(((Attack * 2 + hiddenStats.SpAttack + (trainedStats.SpAttack / 4)) * level / 100 + 5) * GetSpAttackModifiers());
            stats.SpDefense = (int)(((Attack * 2 + hiddenStats.SpDefense + (trainedStats.SpDefense / 4)) * level / 100 + 5) * GetSpDefenseModifiers());
            stats.Defense = (int)(((Attack * 2 + hiddenStats.Defense + (trainedStats.Defense / 4)) * level / 100 + 5) * GetDefenseModifiers());
            stats.Speed = (int)(((Attack * 2 + hiddenStats.Speed + (trainedStats.Speed / 4)) * level / 100 + 5) * GetSpeedModifiers());
            stats.Nature = Nature;

            return stats;
        }       

        private float GetSpeedModifiers()
        {
            if (Nature == Natures.Timid || Nature == Natures.Hasty || Nature == Natures.Jolly || Nature == Natures.Naive)
                return 1.1f;
            else if (Nature == Natures.Brave || Nature == Natures.Relaxed || Nature == Natures.Quiet || Nature == Natures.Sassy)
                return 0.9f;
            else
                return 1f;
        }

        private float GetSpAttackModifiers()
        {
            if (Nature == Natures.Modest || Nature == Natures.Mild || Nature == Natures.Quiet || Nature == Natures.Rash)
                return 1.1f;
            else if (Nature == Natures.Adamant || Nature == Natures.Impish || Nature == Natures.Lax || Nature == Natures.Naughty)
                return 0.9f;
            else
                return 1f;
        }

        private float GetSpDefenseModifiers()
        {
            if (Nature == Natures.Calm || Nature == Natures.Gentle || Nature == Natures.Sassy || Nature == Natures.Careful)
                return 1.1f;
            else if (Nature == Natures.Rash || Nature == Natures.Naive || Nature == Natures.Jolly || Nature == Natures.Careful)
                return 0.9f;
            else
                return 1f;
        }

        private float GetDefenseModifiers()
        {
            if (Nature == Natures.Bold || Nature == Natures.Relaxed || Nature == Natures.Impish || Nature == Natures.Lax)
                return 1.1f;
            else if (Nature == Natures.Lonely || Nature == Natures.Hasty || Nature == Natures.Mild || Nature == Natures.Gentle)
                return 0.9f;
            else
                return 1f;
        }

        private float GetAttackModifier()
        {
            if (Nature == Natures.Lonely || Nature == Natures.Brave || Nature == Natures.Adamant || Nature == Natures.Naughty)
                return 1.1f;
            else if (Nature == Natures.Bold || Nature == Natures.Modest || Nature == Natures.Timid || Nature == Natures.Calm)
                return 0.9f;
            else
                return 1f;
        }
    }
}
