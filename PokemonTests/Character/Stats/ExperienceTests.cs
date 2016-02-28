using Microsoft.VisualStudio.TestTools.UnitTesting;
using PokemonGame.Assets.Scripts.Character.Stats;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonTests.Character.Stats
{
    [TestClass]
    public class ExperienceTests
    {
        [TestMethod]
        [TestCategory("Experience")]
        public void RewardXp_LevelUp()
        {
            Experience exp = new Experience()
            {
                Level = 2,
                Group = ExpGroup.Erratic
            };

            exp.RewardExp(20);

            Assert.AreEqual(3, exp.Level);
        }

        [TestMethod]
        [TestCategory("Experience")]
        public void RewardXp_LevelUp2Times()
        {
            Experience exp = new Experience(2, ExpGroup.Erratic);

            exp.RewardExp(107);

            Assert.AreEqual(4, exp.Level);
        }

        [TestMethod]
        [TestCategory("Experience")]
        public void RecalculateMaxExperience_Erratic_10()
        {
            Experience exp = new Experience(10, ExpGroup.Erratic);

            Assert.AreEqual(1800, exp.Current);
        }

        [TestMethod]
        [TestCategory("Experience")]
        public void RecalculateMaxExperience_Erratic_55()
        {
            Experience exp = new Experience(55, ExpGroup.Erratic);

            Assert.AreEqual(158056, exp.Current);
        }

        [TestMethod]
        [TestCategory("Experience")]
        public void RecalculateMaxExperience_Erratic_77()
        {
            Experience exp = new Experience(77, ExpGroup.Erratic);

            Assert.AreEqual(346965, exp.Current);
        }

        [TestMethod]
        [TestCategory("Experience")]
        public void RecalculateMaxExperience_Erratic_99()
        {
            Experience exp = new Experience(99, ExpGroup.Erratic);

            Assert.AreEqual(591882, exp.Current);
        }

        [TestMethod]
        [TestCategory("Experience")]
        public void RecalculateMaxExperience_Fluctuating_10()
        {
            Experience exp = new Experience(10, ExpGroup.Fluctuating);

            Assert.AreEqual(540, exp.Current);
        }

        [TestMethod]
        [TestCategory("Experience")]
        public void RecalculateMaxExperience_Fluctuating_30()
        {
            Experience exp = new Experience(30, ExpGroup.Fluctuating);

            Assert.AreEqual(23760, exp.Current);
        }


        [TestMethod]
        [TestCategory("Experience")]
        public void RecalculateMaxExperience_Fluctuating_50()
        {
            Experience exp = new Experience(50, ExpGroup.Fluctuating);

            Assert.AreEqual(142500, exp.Current);
        }

        [TestMethod]
        [TestCategory("Experience")]
        public void RecalculateMaxExperience_Slow_50()
        {
            Experience exp = new Experience(50, ExpGroup.Slow);

            Assert.AreEqual(156250, exp.Current);
        }

        [TestMethod]
        [TestCategory("Experience")]
        public void RecalculateMaxExperience_Slow_24()
        {
            Experience exp = new Experience(24, ExpGroup.Slow);

            Assert.AreEqual(17280, exp.Current);
        }

        [TestMethod]
        [TestCategory("Experience")]
        public void RecalculateMaxExperience_MediumSlow_50()
        {
            Experience exp = new Experience(50, ExpGroup.MediumSlow);

            Assert.AreEqual(117360, exp.Current);
        }

        [TestMethod]
        [TestCategory("Experience")]
        public void RecalculateMaxExperience_MediumSlow_24()
        {
            Experience exp = new Experience(24, ExpGroup.MediumSlow);

            Assert.AreEqual(10208, exp.Current);
        }

        [TestMethod]
        [TestCategory("Experience")]
        public void RecalculateMaxExperience_MediumFast_50()
        {
            Experience exp = new Experience(50, ExpGroup.MediumFast);

            Assert.AreEqual(125000, exp.Current);
        }

        [TestMethod]
        [TestCategory("Experience")]
        public void RecalculateMaxExperience_MediumFast_24()
        {
            Experience exp = new Experience(24, ExpGroup.MediumFast);

            Assert.AreEqual(13824, exp.Current);
        }

        [TestMethod]
        [TestCategory("Experience")]
        public void RecalculateMaxExperience_Fast_50()
        {
            Experience exp = new Experience(50, ExpGroup.Fast);

            Assert.AreEqual(100000, exp.Current);
        }

        [TestMethod]
        [TestCategory("Experience")]
        public void RecalculateMaxExperience_Fast_24()
        {
            Experience exp = new Experience(24, ExpGroup.Fast);

            Assert.AreEqual(11059, exp.Current);
        }

        [TestMethod]
        [TestCategory("Experience")]
        public void GetCurrentExpPercentage_LowLevel()
        {
            Experience exp = new Experience(2, ExpGroup.Fast);

            Assert.AreEqual(0, exp.GetCurrentExperiencePercentage());

            exp.RewardExp(6);

            Assert.AreEqual(0.4f, exp.GetCurrentExperiencePercentage());
        }

        [TestMethod]
        [TestCategory("Experience")]
        public void GetCurrentExpPercentage_HighLevel()
        {
            Experience exp = new Experience(50, ExpGroup.Fast);

            Assert.AreEqual(0, exp.GetCurrentExperiencePercentage());

            exp.RewardExp(3060);

            Assert.AreEqual(0.5f, exp.GetCurrentExperiencePercentage());
        }
    }
}
