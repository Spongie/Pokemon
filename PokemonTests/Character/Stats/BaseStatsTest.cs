using Microsoft.VisualStudio.TestTools.UnitTesting;
using PokemonGame.Assets.Scripts.Battle.Attacks;
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
            var iv = new IVStats();
            var ev = new EVStats();

            var realStats = stats.GetRealStats(iv, ev, 50, StatusType.None);

            Assert.AreEqual(105, realStats.Health);
        }

        [TestMethod]
        [TestCategory("Stats")]
        public void HealthCalculation_FullEv()
        {
            BaseStats stats = GetPokemon();
            var iv = new IVStats();
            var ev = new EVStats() { Health = 255 };

            var realStats = stats.GetRealStats(iv, ev, 50, StatusType.None);

            Assert.AreEqual(136, realStats.Health);
        }

        [TestMethod]
        [TestCategory("Stats")]
        public void AttackCalculation_FullEv()
        {
            BaseStats stats = GetPokemon();
            var iv = new IVStats();
            var ev = new EVStats() { Attack = 255 };

            var realStats = stats.GetRealStats(iv, ev, 50, StatusType.None);

            Assert.AreEqual(85, realStats.Attack);
        }

        [TestMethod]
        [TestCategory("Stats")]
        public void AttackCalculation_0Ev()
        {
            BaseStats stats = GetPokemon();
            stats.Nature = Natures.Adamant;

            var iv = new IVStats();
            var ev = new EVStats();

            var realStats = stats.GetRealStats(iv, ev, 50, StatusType.None);

            Assert.AreEqual(59, realStats.Attack);
        }

        [TestMethod]
        [TestCategory("Stats")]
        public void AttackCalculation_PositiveNature()
        {
            BaseStats stats = GetPokemon();
            var iv = new IVStats();
            var ev = new EVStats();

            var realStats = stats.GetRealStats(iv, ev, 50, StatusType.None);

            Assert.AreEqual(54, realStats.Attack);
        }

        [TestMethod]
        [TestCategory("Stats")]
        public void AttackCalculation_NegativeNature()
        {
            BaseStats stats = GetPokemon();
            stats.Nature = Natures.Bold;

            var iv = new IVStats();
            var ev = new EVStats();

            var realStats = stats.GetRealStats(iv, ev, 50, StatusType.None);

            Assert.AreEqual(48, realStats.Attack);
        }

        [TestMethod]
        [TestCategory("Stats")]
        public void GetRealStats_AttackReducedByBurn()
        {
            var stats = GetPokemon();

            Assert.AreEqual(stats.GetRealStats(new IVStats(), new EVStats(), 50, StatusType.Burn).Attack, 40);
        }

        [TestMethod]
        [TestCategory("Stats")]
        public void GetRealStats_SpeedReducedByParalyze()
        {
            var stats = GetPokemon();

            Assert.AreEqual(stats.GetRealStats(new IVStats(), new EVStats(), 50, StatusType.Paralyze).Speed, 37);
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
