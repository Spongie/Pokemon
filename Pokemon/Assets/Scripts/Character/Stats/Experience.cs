using System;

namespace PokemonGame.Assets.Scripts.Character.Stats
{
    public enum ExpGroup
    {
        Erratic,
        Fast,
        MediumFast,
        MediumSlow,
        Slow,
        Fluctuating
    }

    [Serializable]
    public class Experience
    {
        public event EventHandler OnLevelUp;

        public int Current;
        public int Max;
        public int Level;
        public ExpGroup Group;

        public Experience()
        {
            Group = ExpGroup.Erratic;
        }

        public Experience(int level, ExpGroup group)
        {
            Level = level;
            Group = group;
            Current = (int)RecalculateExp();
            Max = (int)new Experience() { Level = level + 1, Group = group }.RecalculateExp();
        }

        public void RewardExp(int amount)
        {
            if (Max - Current <= amount)
            {
                int extraXp = amount - (Max - Current);
                Current += (Max - Current);
                LevelUp();
                RewardExp(extraXp);
            }
            else
                Current += amount;
        }

        private void LevelUp()
        {
            Level++;
            Max = (int)new Experience(Level + 1, Group).RecalculateExp();

            if (OnLevelUp != null)
                OnLevelUp(this, new EventArgs());
        }

        private float RecalculateExp()
        {
            switch (Group)
            {
                case ExpGroup.Erratic:
                    SetErraticExp();
                    break;
                case ExpGroup.Fast:
                    SetFastExp();
                    break;
                case ExpGroup.MediumFast:
                    MediumFastExp();
                    break;
                case ExpGroup.MediumSlow:
                    SetMediumSlowExp();
                    break;
                case ExpGroup.Slow:
                    SetSlowExp();
                    break;
                case ExpGroup.Fluctuating:
                    SetFluctuatingExp();
                    break;
                default:
                    break;
            }

            return Max;
        }

        private void SetFastExp()
        {
            Max = (4 * (Level * Level * Level)) / 5;
        }

        private void MediumFastExp()
        {
            Max = Level * Level * Level;
        }

        private void SetMediumSlowExp()
        {
            Max = (int)(((6 / 5f) * (Level * Level * Level)) - (15 * (Level * Level)) + (100 * Level) - 140);
        }

        private void SetSlowExp()
        {
            Max = (5 * (Level * Level * Level)) / 4;
        }

        private void SetFluctuatingExp()
        {
            if (Level <= 15)
                Max = (int)((Level * Level * Level) * ((((Level + 1) / 3) + 24) / 50f));
            else if (Level <= 36)
                Max = (int)((Level * Level * Level) * ((Level + 14) / 50f));
            else
                Max = (int)((Level * Level * Level) * ((((Level / 2)) + 32) / 50f));
        }

        private void SetErraticExp()
        {
            if (Level <= 50)
                Max = ((Level * Level * Level) * (100 - Level)) / 50;
            else if (Level <= 68)
                Max = ((Level * Level * Level) * (150 - Level)) / 100;
            else if (Level <= 98)
                Max = ((Level * Level * Level) * (((1911 - (Level * 10)) / 3))) / 500;
            else
                Max = ((Level * Level * Level) * (160 - Level)) / 100;
        }

        public float GetCurrentExperiencePercentage()
        {
            float min = new Experience(Level, Group).RecalculateExp();
            float max = new Experience(Level + 1, Group).RecalculateExp();

            float required = max - min;
            float current = Current - min;

            return current / required;
        }
    }
}
