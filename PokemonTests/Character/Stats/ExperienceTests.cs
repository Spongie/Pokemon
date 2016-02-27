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

            exp.RecalculateMax();

            exp.RewardExp(20);

            Assert.AreEqual(3, exp.Level);
        }

        [TestMethod]
        [TestCategory("Experience")]
        public void RewardXp_LevelUp2Times()
        {
            Experience exp = new Experience()
            {
                Level = 2,
                Group = ExpGroup.Erratic
            };

            exp.RecalculateMax();

            exp.RewardExp(55);

            Assert.AreEqual(4, exp.Level);
        }

        [TestMethod]
        [TestCategory("Experience")]
        public void RecalculateMaxExperience_Erratic_10()
        {
            Experience exp = new Experience()
            {
                Level = 10,
                Group = ExpGroup.Erratic
            };

            exp.RecalculateMax();

            Assert.AreEqual(1800, exp.Max);
        }

        [TestMethod]
        [TestCategory("Experience")]
        public void RecalculateMaxExperience_Erratic_55()
        {
            Experience exp = new Experience()
            {
                Level = 55,
                Group = ExpGroup.Erratic
            };

            exp.RecalculateMax();

            Assert.AreEqual(158056, exp.Max);
        }

        [TestMethod]
        [TestCategory("Experience")]
        public void RecalculateMaxExperience_Erratic_77()
        {
            Experience exp = new Experience()
            {
                Level = 77,
                Group = ExpGroup.Erratic
            };

            exp.RecalculateMax();

            Assert.AreEqual(346965, exp.Max);
        }

        [TestMethod]
        [TestCategory("Experience")]
        public void RecalculateMaxExperience_Erratic_99()
        {
            Experience exp = new Experience()
            {
                Level = 99,
                Group = ExpGroup.Erratic
            };

            exp.RecalculateMax();

            Assert.AreEqual(591882, exp.Max);
        }

        [TestMethod]
        [TestCategory("Experience")]
        public void RecalculateMaxExperience_Fluctuating_10()
        {
            Experience exp = new Experience()
            {
                Level = 10,
                Group = ExpGroup.Fluctuating
            };

            exp.RecalculateMax();

            Assert.AreEqual(540, exp.Max);
        }

        [TestMethod]
        [TestCategory("Experience")]
        public void RecalculateMaxExperience_Fluctuating_30()
        {
            Experience exp = new Experience()
            {
                Level = 30,
                Group = ExpGroup.Fluctuating
            };

            exp.RecalculateMax();

            Assert.AreEqual(23760, exp.Max);
        }


        [TestMethod]
        [TestCategory("Experience")]
        public void RecalculateMaxExperience_Fluctuating_50()
        {
            Experience exp = new Experience()
            {
                Level = 50,
                Group = ExpGroup.Fluctuating
            };

            exp.RecalculateMax();

            Assert.AreEqual(142500, exp.Max);
        }

        [TestMethod]
        [TestCategory("Experience")]
        public void RecalculateMaxExperience_Slow_50()
        {
            Experience exp = new Experience()
            {
                Level = 50,
                Group = ExpGroup.Slow
            };

            exp.RecalculateMax();

            Assert.AreEqual(156250, exp.Max);
        }

        [TestMethod]
        [TestCategory("Experience")]
        public void RecalculateMaxExperience_Slow_24()
        {
            Experience exp = new Experience()
            {
                Level = 24,
                Group = ExpGroup.Slow
            };

            exp.RecalculateMax();

            Assert.AreEqual(17280, exp.Max);
        }

        [TestMethod]
        [TestCategory("Experience")]
        public void RecalculateMaxExperience_MediumSlow_50()
        {
            Experience exp = new Experience()
            {
                Level = 50,
                Group = ExpGroup.MediumSlow
            };

            exp.RecalculateMax();

            Assert.AreEqual(117360, exp.Max);
        }

        [TestMethod]
        [TestCategory("Experience")]
        public void RecalculateMaxExperience_MediumSlow_24()
        {
            Experience exp = new Experience()
            {
                Level = 24,
                Group = ExpGroup.MediumSlow
            };

            exp.RecalculateMax();

            Assert.AreEqual(10208, exp.Max);
        }

        [TestMethod]
        [TestCategory("Experience")]
        public void RecalculateMaxExperience_MediumFast_50()
        {
            Experience exp = new Experience()
            {
                Level = 50,
                Group = ExpGroup.MediumFast
            };

            exp.RecalculateMax();

            Assert.AreEqual(125000, exp.Max);
        }

        [TestMethod]
        [TestCategory("Experience")]
        public void RecalculateMaxExperience_MediumFast_24()
        {
            Experience exp = new Experience()
            {
                Level = 24,
                Group = ExpGroup.MediumFast
            };

            exp.RecalculateMax();

            Assert.AreEqual(13824, exp.Max);
        }

        [TestMethod]
        [TestCategory("Experience")]
        public void RecalculateMaxExperience_Fast_50()
        {
            Experience exp = new Experience()
            {
                Level = 50,
                Group = ExpGroup.Fast
            };

            exp.RecalculateMax();

            Assert.AreEqual(100000, exp.Max);
        }

        [TestMethod]
        [TestCategory("Experience")]
        public void RecalculateMaxExperience_Fast_24()
        {
            Experience exp = new Experience()
            {
                Level = 24,
                Group = ExpGroup.Fast
            };

            exp.RecalculateMax();

            Assert.AreEqual(11059, exp.Max);
        }
    }
}
