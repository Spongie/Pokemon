using Microsoft.VisualStudio.TestTools.UnitTesting;
using PokemonGame.Assets.Scripts.Battle;
using PokemonGame.Assets.Scripts.Character.Stats;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonTests.Battle
{
    [TestClass]
    public class BattleCalculationsTests
    {
        [TestMethod]
        [TestCategory("Battle")]
        public void GetEffectivenessModifer_SingeSuper()
        {
            var attackType = PokemonType.Fire;
            var defenderTypes = new List<PokemonType>
            {
                PokemonType.Grass
            };

            Assert.AreEqual(2f, BattleCalculations.GetEffectivnessModifer(attackType, defenderTypes));
        }

        [TestMethod]
        [TestCategory("Battle")]
        public void GetEffectivenessModifer_DoubleSuper()
        {
            var attackType = PokemonType.Fire;
            var defenderTypes = new List<PokemonType>
            {
                PokemonType.Grass,
                PokemonType.Bug
            };

            Assert.AreEqual(4f, BattleCalculations.GetEffectivnessModifer(attackType, defenderTypes));
        }

        [TestMethod]
        [TestCategory("Battle")]
        public void GetEffectivenessModifer_SingeWeak()
        {
            var attackType = PokemonType.Fire;
            var defenderTypes = new List<PokemonType>
            {
                PokemonType.Water
            };

            Assert.AreEqual(0.5f, BattleCalculations.GetEffectivnessModifer(attackType, defenderTypes));
        }

        [TestMethod]
        [TestCategory("Battle")]
        public void GetEffectivenessModifer_DoubleWeak()
        {
            var attackType = PokemonType.Fire;
            var defenderTypes = new List<PokemonType>
            {
                PokemonType.Water,
                PokemonType.Rock
            };

            Assert.AreEqual(0.25f, BattleCalculations.GetEffectivnessModifer(attackType, defenderTypes));
        }

        [TestMethod]
        [TestCategory("Battle")]
        public void GetEffectivenessModifer_Normal()
        {
            var attackType = PokemonType.Normal;
            var defenderTypes = new List<PokemonType>
            {
                PokemonType.Rock
            };

            Assert.AreEqual(0.5f, BattleCalculations.GetEffectivnessModifer(attackType, defenderTypes));

            defenderTypes = new List<PokemonType>
            {
                PokemonType.Ghost
            };

            Assert.AreEqual(0f, BattleCalculations.GetEffectivnessModifer(attackType, defenderTypes));

            defenderTypes = new List<PokemonType>
            {
                PokemonType.Steel
            };

            Assert.AreEqual(0.5f, BattleCalculations.GetEffectivnessModifer(attackType, defenderTypes));
        }

        [TestMethod]
        [TestCategory("Battle")]
        public void GetEffectivenessModifer_Fight()
        {
            var attackType = PokemonType.Fighting;
            var defenderTypes = new List<PokemonType>
            {
                PokemonType.Normal
            };

            Assert.AreEqual(2f, BattleCalculations.GetEffectivnessModifer(attackType, defenderTypes));

            defenderTypes = new List<PokemonType>
            {
                PokemonType.Flying,
                PokemonType.Poison
            };

            Assert.AreEqual(0.25f, BattleCalculations.GetEffectivnessModifer(attackType, defenderTypes));

            defenderTypes = new List<PokemonType>
            {
                PokemonType.Rock,
                PokemonType.Bug
            };

            Assert.AreEqual(1f, BattleCalculations.GetEffectivnessModifer(attackType, defenderTypes));

            defenderTypes = new List<PokemonType>
            {
                PokemonType.Ghost
            };

            Assert.AreEqual(0f, BattleCalculations.GetEffectivnessModifer(attackType, defenderTypes));

            defenderTypes = new List<PokemonType>
            {
                PokemonType.Steel,
                PokemonType.Ice
            };

            Assert.AreEqual(4f, BattleCalculations.GetEffectivnessModifer(attackType, defenderTypes));

            defenderTypes = new List<PokemonType>
            {
                PokemonType.Psychic,
                PokemonType.Fairy
            };

            Assert.AreEqual(0.25f, BattleCalculations.GetEffectivnessModifer(attackType, defenderTypes));

            defenderTypes = new List<PokemonType>
            {
                PokemonType.Dark
            };

            Assert.AreEqual(2f, BattleCalculations.GetEffectivnessModifer(attackType, defenderTypes));
        }

        [TestMethod]
        [TestCategory("Battle")]
        public void GetEffectivenessModifer_Flying()
        {
            var attackType = PokemonType.Flying;
            var defenderTypes = new List<PokemonType>
            {
                PokemonType.Fighting,
                PokemonType.Rock
            };

            Assert.AreEqual(1f, BattleCalculations.GetEffectivnessModifer(attackType, defenderTypes));

            defenderTypes = new List<PokemonType>
            {
                PokemonType.Grass
            };

            Assert.AreEqual(2f, BattleCalculations.GetEffectivnessModifer(attackType, defenderTypes));

            defenderTypes = new List<PokemonType>
            {
                PokemonType.Steel,
                PokemonType.Bug
            };

            Assert.AreEqual(1f, BattleCalculations.GetEffectivnessModifer(attackType, defenderTypes));

            defenderTypes = new List<PokemonType>
            {
                PokemonType.Electric
            };

            Assert.AreEqual(0.5f, BattleCalculations.GetEffectivnessModifer(attackType, defenderTypes));     
        }

        [TestMethod]
        [TestCategory("Battle")]
        public void GetEffectivenessModifer_Poison()
        {
            var attackType = PokemonType.Poison;
            var defenderTypes = new List<PokemonType>
            {
                PokemonType.Poison,
                PokemonType.Ground
            };

            Assert.AreEqual(0.25f, BattleCalculations.GetEffectivnessModifer(attackType, defenderTypes));

            defenderTypes = new List<PokemonType>
            {
                PokemonType.Steel
            };

            Assert.AreEqual(0f, BattleCalculations.GetEffectivnessModifer(attackType, defenderTypes));

            defenderTypes = new List<PokemonType>
            {
                PokemonType.Rock,
                PokemonType.Ghost
            };

            Assert.AreEqual(0.25f, BattleCalculations.GetEffectivnessModifer(attackType, defenderTypes));

            defenderTypes = new List<PokemonType>
            {
                PokemonType.Grass,
                PokemonType.Fairy
            };

            Assert.AreEqual(4f, BattleCalculations.GetEffectivnessModifer(attackType, defenderTypes));
        }

        [TestMethod]
        [TestCategory("Battle")]
        public void GetEffectivenessModifer_Ground()
        {
            var attackType = PokemonType.Ground;
            var defenderTypes = new List<PokemonType>
            {
                PokemonType.Poison,
                PokemonType.Rock
            };

            Assert.AreEqual(4f, BattleCalculations.GetEffectivnessModifer(attackType, defenderTypes));

            defenderTypes = new List<PokemonType>
            {
                PokemonType.Flying
            };

            Assert.AreEqual(0f, BattleCalculations.GetEffectivnessModifer(attackType, defenderTypes));

            defenderTypes = new List<PokemonType>
            {
                PokemonType.Steel,
                PokemonType.Bug
            };

            Assert.AreEqual(1f, BattleCalculations.GetEffectivnessModifer(attackType, defenderTypes));

            defenderTypes = new List<PokemonType>
            {
                PokemonType.Electric,
                PokemonType.Fire
            };

            Assert.AreEqual(4f, BattleCalculations.GetEffectivnessModifer(attackType, defenderTypes));

            defenderTypes = new List<PokemonType>
            {
                PokemonType.Grass
            };

            Assert.AreEqual(0.5f, BattleCalculations.GetEffectivnessModifer(attackType, defenderTypes));
        }

        [TestMethod]
        [TestCategory("Battle")]
        public void GetEffectivenessModifer_Rock()
        {
            var attackType = PokemonType.Rock;
            var defenderTypes = new List<PokemonType>
            {
                PokemonType.Ground,
                PokemonType.Fighting
            };

            Assert.AreEqual(0.25f, BattleCalculations.GetEffectivnessModifer(attackType, defenderTypes));

            defenderTypes = new List<PokemonType>
            {
                PokemonType.Flying,
                PokemonType.Bug
            };

            Assert.AreEqual(4f, BattleCalculations.GetEffectivnessModifer(attackType, defenderTypes));

            defenderTypes = new List<PokemonType>
            {
                PokemonType.Steel,
                PokemonType.Fire
            };

            Assert.AreEqual(1f, BattleCalculations.GetEffectivnessModifer(attackType, defenderTypes));

            defenderTypes = new List<PokemonType>
            {
                PokemonType.Ice
            };

            Assert.AreEqual(2f, BattleCalculations.GetEffectivnessModifer(attackType, defenderTypes));
        }

        [TestMethod]
        [TestCategory("Battle")]
        public void GetEffectivenessModifer_Bug()
        {
            var attackType = PokemonType.Bug;
            var defenderTypes = new List<PokemonType>
            {
                PokemonType.Fighting,
                PokemonType.Flying
            };

            Assert.AreEqual(0.25f, BattleCalculations.GetEffectivnessModifer(attackType, defenderTypes));

            defenderTypes = new List<PokemonType>
            {
                PokemonType.Poison
            };

            Assert.AreEqual(0.5f, BattleCalculations.GetEffectivnessModifer(attackType, defenderTypes));

            defenderTypes = new List<PokemonType>
            {
                PokemonType.Ghost,
                PokemonType.Steel
            };

            Assert.AreEqual(0.25f, BattleCalculations.GetEffectivnessModifer(attackType, defenderTypes));

            defenderTypes = new List<PokemonType>
            {
                PokemonType.Fairy,
                PokemonType.Fire
            };

            Assert.AreEqual(0.25f, BattleCalculations.GetEffectivnessModifer(attackType, defenderTypes));

            defenderTypes = new List<PokemonType>
            {
                PokemonType.Grass,
                PokemonType.Psychic
            };

            Assert.AreEqual(4f, BattleCalculations.GetEffectivnessModifer(attackType, defenderTypes));

            defenderTypes = new List<PokemonType>()
            {
                PokemonType.Dark
            };

            Assert.AreEqual(2f, BattleCalculations.GetEffectivnessModifer(attackType, defenderTypes));
        }

        [TestMethod]
        [TestCategory("Battle")]
        public void GetEffectivenessModifer_Ghost()
        {
            var attackType = PokemonType.Ghost;
            var defenderTypes = new List<PokemonType>
            {
                PokemonType.Ghost
            };

            Assert.AreEqual(2f, BattleCalculations.GetEffectivnessModifer(attackType, defenderTypes));

            defenderTypes = new List<PokemonType>
            {
                PokemonType.Psychic,
                PokemonType.Dark
            };

            Assert.AreEqual(1f, BattleCalculations.GetEffectivnessModifer(attackType, defenderTypes));

            defenderTypes = new List<PokemonType>
            {
                PokemonType.Normal
            };

            Assert.AreEqual(0f, BattleCalculations.GetEffectivnessModifer(attackType, defenderTypes));
        }

        [TestMethod]
        [TestCategory("Battle")]
        public void GetEffectivenessModifer_Steel()
        {
            var attackType = PokemonType.Steel;
            var defenderTypes = new List<PokemonType>
            {
                PokemonType.Steel,
                PokemonType.Rock
            };

            Assert.AreEqual(1f, BattleCalculations.GetEffectivnessModifer(attackType, defenderTypes));

            defenderTypes = new List<PokemonType>
            {
                PokemonType.Fire,
                PokemonType.Water
            };

            Assert.AreEqual(0.25f, BattleCalculations.GetEffectivnessModifer(attackType, defenderTypes));

            defenderTypes = new List<PokemonType>
            {
                PokemonType.Electric,
                PokemonType.Ice
            };

            Assert.AreEqual(1f, BattleCalculations.GetEffectivnessModifer(attackType, defenderTypes));

            defenderTypes = new List<PokemonType>
            {
                PokemonType.Fairy
            };

            Assert.AreEqual(2f, BattleCalculations.GetEffectivnessModifer(attackType, defenderTypes));
        }

        [TestMethod]
        [TestCategory("Battle")]
        public void GetEffectivenessModifer_Fire()
        {
            var attackType = PokemonType.Fire;
            var defenderTypes = new List<PokemonType>
            {
                PokemonType.Bug,
                PokemonType.Rock
            };

            Assert.AreEqual(1f, BattleCalculations.GetEffectivnessModifer(attackType, defenderTypes));

            defenderTypes = new List<PokemonType>
            {
                PokemonType.Steel,
                PokemonType.Grass
            };

            Assert.AreEqual(4f, BattleCalculations.GetEffectivnessModifer(attackType, defenderTypes));

            defenderTypes = new List<PokemonType>
            {
                PokemonType.Fire,
                PokemonType.Water
            };

            Assert.AreEqual(0.25f, BattleCalculations.GetEffectivnessModifer(attackType, defenderTypes));

            defenderTypes = new List<PokemonType>
            {
                PokemonType.Ice,
                PokemonType.Dragon
            };

            Assert.AreEqual(1f, BattleCalculations.GetEffectivnessModifer(attackType, defenderTypes));
        }

        [TestMethod]
        [TestCategory("Battle")]
        public void GetEffectivenessModifer_Water()
        {
            var attackType = PokemonType.Water;
            var defenderTypes = new List<PokemonType>
            {
                PokemonType.Ground,
                PokemonType.Rock
            };

            Assert.AreEqual(4f, BattleCalculations.GetEffectivnessModifer(attackType, defenderTypes));

            defenderTypes = new List<PokemonType>
            {
                PokemonType.Fire,
                PokemonType.Water
            };

            Assert.AreEqual(1f, BattleCalculations.GetEffectivnessModifer(attackType, defenderTypes));

            defenderTypes = new List<PokemonType>
            {
                PokemonType.Grass,
                PokemonType.Dragon
            };

            Assert.AreEqual(0.25f, BattleCalculations.GetEffectivnessModifer(attackType, defenderTypes));
        }

        [TestMethod]
        [TestCategory("Battle")]
        public void GetEffectivenessModifer_Grass()
        {
            var attackType = PokemonType.Grass;
            var defenderTypes = new List<PokemonType>
            {
                PokemonType.Flying,
                PokemonType.Poison
            };

            Assert.AreEqual(0.25f, BattleCalculations.GetEffectivnessModifer(attackType, defenderTypes));

            defenderTypes = new List<PokemonType>
            {
                PokemonType.Ground,
                PokemonType.Rock
            };

            Assert.AreEqual(4f, BattleCalculations.GetEffectivnessModifer(attackType, defenderTypes));

            defenderTypes = new List<PokemonType>
            {
                PokemonType.Bug,
                PokemonType.Steel
            };

            Assert.AreEqual(0.25f, BattleCalculations.GetEffectivnessModifer(attackType, defenderTypes));

            defenderTypes = new List<PokemonType>
            {
                PokemonType.Water,
                PokemonType.Fire
            };

            Assert.AreEqual(1f, BattleCalculations.GetEffectivnessModifer(attackType, defenderTypes));

            defenderTypes = new List<PokemonType>
            {
                PokemonType.Grass,
                PokemonType.Dragon
            };

            Assert.AreEqual(0.25f, BattleCalculations.GetEffectivnessModifer(attackType, defenderTypes));
        }

        [TestMethod]
        [TestCategory("Battle")]
        public void GetEffectivenessModifer_Electric()
        {
            var attackType = PokemonType.Electric;
            var defenderTypes = new List<PokemonType>
            {
                PokemonType.Flying,
                PokemonType.Water
            };

            Assert.AreEqual(4f, BattleCalculations.GetEffectivnessModifer(attackType, defenderTypes));

            defenderTypes = new List<PokemonType>
            {
                PokemonType.Grass,
                PokemonType.Electric
            };

            Assert.AreEqual(0.25f, BattleCalculations.GetEffectivnessModifer(attackType, defenderTypes));

            defenderTypes = new List<PokemonType>
            {
                PokemonType.Dragon
            };

            Assert.AreEqual(0.5f, BattleCalculations.GetEffectivnessModifer(attackType, defenderTypes));

            defenderTypes = new List<PokemonType>
            {
                PokemonType.Ground
            };

            Assert.AreEqual(0f, BattleCalculations.GetEffectivnessModifer(attackType, defenderTypes));
        }

        [TestMethod]
        [TestCategory("Battle")]
        public void GetEffectivenessModifer_Psychic()
        {
            var attackType = PokemonType.Psychic;
            var defenderTypes = new List<PokemonType>
            {
                PokemonType.Fighting,
                PokemonType.Poison
            };

            Assert.AreEqual(4f, BattleCalculations.GetEffectivnessModifer(attackType, defenderTypes));

            defenderTypes = new List<PokemonType>
            {
                PokemonType.Psychic,
                PokemonType.Steel
            };

            Assert.AreEqual(0.25f, BattleCalculations.GetEffectivnessModifer(attackType, defenderTypes));

            defenderTypes = new List<PokemonType>
            {
                PokemonType.Dark
            };

            Assert.AreEqual(0f, BattleCalculations.GetEffectivnessModifer(attackType, defenderTypes));        
        }

        [TestMethod]
        [TestCategory("Battle")]
        public void GetEffectivenessModifer_Ice()
        {
            var attackType = PokemonType.Ice;
            var defenderTypes = new List<PokemonType>
            {
                PokemonType.Flying,
                PokemonType.Ground
            };

            Assert.AreEqual(4f, BattleCalculations.GetEffectivnessModifer(attackType, defenderTypes));

            defenderTypes = new List<PokemonType>
            {
                PokemonType.Steel,
                PokemonType.Fire
            };

            Assert.AreEqual(0.25f, BattleCalculations.GetEffectivnessModifer(attackType, defenderTypes));

            defenderTypes = new List<PokemonType>
            {
                PokemonType.Water,
                PokemonType.Grass
            };

            Assert.AreEqual(1f, BattleCalculations.GetEffectivnessModifer(attackType, defenderTypes));

            defenderTypes = new List<PokemonType>
            {
                PokemonType.Dragon,
                PokemonType.Ice
            };

            Assert.AreEqual(1f, BattleCalculations.GetEffectivnessModifer(attackType, defenderTypes));
        }

        [TestMethod]
        [TestCategory("Battle")]
        public void GetEffectivenessModifer_Dragon()
        {
            var attackType = PokemonType.Dragon;
            var defenderTypes = new List<PokemonType>
            {
                PokemonType.Steel
            };

            Assert.AreEqual(0.5f, BattleCalculations.GetEffectivnessModifer(attackType, defenderTypes));

            defenderTypes = new List<PokemonType>
            {
                PokemonType.Dragon
            };

            Assert.AreEqual(2f, BattleCalculations.GetEffectivnessModifer(attackType, defenderTypes));

            defenderTypes = new List<PokemonType>
            {
                PokemonType.Fairy
            };

            Assert.AreEqual(0f, BattleCalculations.GetEffectivnessModifer(attackType, defenderTypes));           
        }

        [TestMethod]
        [TestCategory("Battle")]
        public void GetEffectivenessModifer_Dark()
        {
            var attackType = PokemonType.Dark;
            var defenderTypes = new List<PokemonType>
            {
                PokemonType.Fighting,
                PokemonType.Ghost
            };

            Assert.AreEqual(1f, BattleCalculations.GetEffectivnessModifer(attackType, defenderTypes));

            defenderTypes = new List<PokemonType>
            {
                PokemonType.Psychic
            };

            Assert.AreEqual(2f, BattleCalculations.GetEffectivnessModifer(attackType, defenderTypes));

            defenderTypes = new List<PokemonType>
            {
                PokemonType.Dark,
                PokemonType.Fairy
            };

            Assert.AreEqual(0.25f, BattleCalculations.GetEffectivnessModifer(attackType, defenderTypes));
        }

        [TestMethod]
        [TestCategory("Battle")]
        public void GetEffectivenessModifer_Fairy()
        {
            var attackType = PokemonType.Fairy;
            var defenderTypes = new List<PokemonType>
            {
                PokemonType.Fighting,
                PokemonType.Poison
            };

            Assert.AreEqual(1f, BattleCalculations.GetEffectivnessModifer(attackType, defenderTypes));

            defenderTypes = new List<PokemonType>
            {
                PokemonType.Steel,
                PokemonType.Fire
            };

            Assert.AreEqual(0.25f, BattleCalculations.GetEffectivnessModifer(attackType, defenderTypes));

            defenderTypes = new List<PokemonType>
            {
                PokemonType.Dragon,
                PokemonType.Dark
            };

            Assert.AreEqual(4f, BattleCalculations.GetEffectivnessModifer(attackType, defenderTypes));
        }
    }
}
