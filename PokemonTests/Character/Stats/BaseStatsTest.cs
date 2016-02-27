using Microsoft.VisualStudio.TestTools.UnitTesting;
using PokemonGame.Assets.Scripts.Character.Stats;

namespace PokemonTests.Character.Stats
{
    [TestClass]
    public class BaseStatsTest
    {
        [TestMethod]
        [TestCategory("Stats")]
        public void HealthCalculation_0EV()
        {
            BaseStats stats = GetPokemon();
            var iv = new HiddenBase();
            var ev = new TrainedStats();

            var realStats = stats.GetRealStats(iv, ev, 50);

            Assert.AreEqual(105, realStats.Health);
        }

        [TestMethod]
        [TestCategory("Stats")]
        public void HealthCalculation_FullEv()
        {
            BaseStats stats = GetPokemon();
            var iv = new HiddenBase();
            var ev = new TrainedStats() { Health = 255 };

            var realStats = stats.GetRealStats(iv, ev, 50);

            Assert.AreEqual(136, realStats.Health);
        }

        [TestMethod]
        [TestCategory("Stats")]
        public void AttackCalculation_FullEv()
        {
            BaseStats stats = GetPokemon();
            var iv = new HiddenBase();
            var ev = new TrainedStats() { Attack = 255 };

            var realStats = stats.GetRealStats(iv, ev, 50);

            Assert.AreEqual(85, realStats.Attack);
        }

        [TestMethod]
        [TestCategory("Stats")]
        public void AttackCalculation_0Ev()
        {
            BaseStats stats = GetPokemon();
            stats.Nature = Natures.Adamant;

            var iv = new HiddenBase();
            var ev = new TrainedStats();

            var realStats = stats.GetRealStats(iv, ev, 50);

            Assert.AreEqual(59, realStats.Attack);
        }

        [TestMethod]
        [TestCategory("Stats")]
        public void AttackCalculation_PositiveNature()
        {
            BaseStats stats = GetPokemon();
            var iv = new HiddenBase();
            var ev = new TrainedStats();

            var realStats = stats.GetRealStats(iv, ev, 50);

            Assert.AreEqual(54, realStats.Attack);
        }

        [TestMethod]
        [TestCategory("Stats")]
        public void AttackCalculation_NegativeNature()
        {
            BaseStats stats = GetPokemon();
            stats.Nature = Natures.Bold;

            var iv = new HiddenBase();
            var ev = new TrainedStats();

            var realStats = stats.GetRealStats(iv, ev, 50);

            Assert.AreEqual(48, realStats.Attack);
        }

        private static BaseStats GetPokemon()
        {
            //Really is a bulbasaur
            return new BaseStats()
            {
                Health = 45,
                Speed = 45,
                Attack = 49,
                Defense = 49,
                SpAttack = 65,
                SpDefense = 65
            };
        }
    }
}
