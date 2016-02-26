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

        public float Current;
        public float Max;
        public int Level;
        public ExpGroup Group;

        public void RewardExp(float amount)
        {
            if (Max - Current > amount)
            {
                Current += (Max - Current);
                amount -= (Max - Current);
                LevelUp();
                RewardExp(amount);
            }
            else
                Current += (Max - Current);
        }

        private void LevelUp()
        {
            Level++;
            RecalculateMax();

            if (OnLevelUp != null)
                OnLevelUp(this, new EventArgs());
        }

        private void RecalculateMax()
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
            Max = ((6 / 5) * (Level * Level * Level)) - (15 * (Level * Level) + (100 * Level)) - 140;
        }

        private void SetSlowExp()
        {
            Max = (5 * (Level * Level * Level)) / 4;
        }

        private void SetFluctuatingExp()
        {
            if (Level <= 15)
                Max = (Level * Level * Level) * ((((Level + 1) / 3) + 24) / 50);
            else if (Level <= 36)
                Max = (Level * Level * Level) * ((((Level + 14)) + 14) / 50);
            else
                Max = (Level * Level * Level) * ((((Level / 2)) + 32) / 50);
        }

        private void SetErraticExp()
        {
            if (Level <= 50)
                Max = ((Level * Level * Level) * (100 - Level)) / 50;
            else if (Level <= 68)
                Max = ((Level * Level * Level) * (150 - Level)) / 100;
            else if (Level <= 98)
                Max = ((Level * Level * Level) * ((1911 - (Level * 10) / 3))) / 500;
            else
                Max = ((Level * Level * Level) * (160 - Level)) / 100;
        }
    }
}
