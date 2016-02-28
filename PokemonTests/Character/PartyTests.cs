using Microsoft.VisualStudio.TestTools.UnitTesting;
using PokemonGame.Assets.Scripts.Character;
using PokemonGame.Assets.Scripts.Character.Stats;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonTests.Character
{
    [TestClass]
    public class PartyTests
    {
        [TestMethod]
        [TestCategory("Party")]
        public void IsAllPokemonDead_1Alive()
        {
            var party = new Party();
            party.Pokemons.Add(new Pokemon());
            party.Pokemons.Add(new Pokemon());
            party.Pokemons.Add(new Pokemon());

            party.Pokemons.First().Stats.CurrentHealth = 100;

            Assert.IsFalse(party.IsAllPokemonDead());
        }

        [TestMethod]
        [TestCategory("Party")]
        public void IsAllPokemonDead_0Alive()
        {
            var party = new Party();
            party.Pokemons.Add(new Pokemon());
            party.Pokemons.Add(new Pokemon());
            party.Pokemons.Add(new Pokemon());

            Assert.IsTrue(party.IsAllPokemonDead());
        }

        [TestMethod]
        [TestCategory("Party")]
        public void GetFirstAlivePokemon_FirstAlive()
        {
            var party = new Party();
            party.Pokemons.Add(new Pokemon());
            party.Pokemons.Add(new Pokemon());
            party.Pokemons.Add(new Pokemon());

            party.Pokemons.First().Stats.CurrentHealth = 100;
            party.Pokemons[1].Stats.CurrentHealth = 100;
            party.Pokemons[2].Stats.CurrentHealth = 100;

            Assert.AreEqual(party.Pokemons.First(), party.GetFirstAlivePokemon());
        }

        [TestMethod]
        [TestCategory("Party")]
        public void GetFirstAlivePokemon_FirstDead()
        {
            var party = new Party();
            party.Pokemons.Add(new Pokemon());
            party.Pokemons.Add(new Pokemon());
            party.Pokemons.Add(new Pokemon());

            party.Pokemons[1].Stats.CurrentHealth = 100;
            party.Pokemons[2].Stats.CurrentHealth = 100;

            Assert.AreEqual(party.Pokemons[1], party.GetFirstAlivePokemon());
        }
    }
}
