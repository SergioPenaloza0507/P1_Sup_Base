using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace P1_Sup_Base.Logic.Tests
{
    [TestClass()]
    public class UnitTest1
    {
        
        // Descomentar cuando el código esté completo.
        // Character that dies with a single hit and only deals 1HP of damage.
        private Character c1 = new Character(1, 1, 0);

        // Character with high HP and resistance.
        private Character c2 = new Character(4, 3, 4);

        // Character with high strenght, low HP and resistance.
        private Character c3 = new Character(2, 10, 2);

        // Character with lots of HP but low stats.
        private Character c4 = new Character(10, 1, 0);

        // Hazard that has zero strength.
        private Hazard h1 = new Hazard(0);

        // Hazard with lots of strength.
        private Hazard h2 = new Hazard(10);

        // Hazard with small strength.
        private Hazard h3 = new Hazard(3);

        // Destructible with 0 HP. Should die with any damage.
        private Destructible d1 = new Destructible(0);

        // Destructible with some HP to test receiving damage.
        private Destructible d2 = new Destructible(5);

        [TestMethod()]
        public void ApplyDamageTest()
        {
            Character c1Clone = c1.Copy();
            Character c2Clone = c2.Copy();

            h1.ApplyDamage(c1Clone);
            h1.ApplyDamage(c2Clone);

            //  Character1 effectively died.
            Assert.AreEqual(c1Clone.HP, 0);

            // Character2 only lost 1 HP, regardless of hazard having 0 strength
            Assert.AreEqual(c2Clone.HP, 3);

            h2.ApplyDamage(c2Clone);

            //Character2 died because hazard 2 has 10 strength
            Assert.IsTrue(c2Clone.HP <= 0);
        }

        [TestMethod()]
        public void ReceiveDamageTest()
        {
            Character c1Clone = c1.Copy();
            Destructible d1Clone = d1.Copy();
            Destructible d2Clone = d2.Copy();

            c1Clone.ApplyDamage(d1Clone);

            // Character destroyed D1.
            Assert.IsTrue(d1Clone.HP <= 0);

            c1Clone.ApplyDamage(d2Clone);

            // D2 receives full damage of C1's strength of 1 point
            Assert.AreEqual(d2Clone.HP, 4);
        }

        [TestMethod()]
        public void LevelUpTest()
        {
            // Character with initial resistance of 0
            Character c4Clone = c4.Copy();

            // Hazard that deals 4 HP
            Hazard h3Clone = h3.Copy();

            // Destructible with 5 HP
            Destructible d2Clone = d2.Copy();

            h3Clone.ApplyDamage(c4Clone);

            // Since C4 has no resistance, hazard deals full damage
            Assert.AreEqual(c4Clone.HP, 7);

            for (int i = 0; i < 5; i++)
            {
                c4Clone.LevelUp();
            }

            // Character 1 grew up 5 levels
            Assert.AreEqual(c4Clone.Level, 6);

            //(int)System.Math.Ceiling(0 + (1 * (6 - 1) * 0.25)); = 2
            Assert.AreEqual(c4Clone.Resistance, 2);

            h3Clone.ApplyDamage(c4Clone);

            // After leveling up, hazard deals 1HP
            Assert.AreEqual(c4Clone.HP, 6);

            c4Clone.ApplyDamage(d2Clone);

            // After leveling up, C4 has 3 strength
            Assert.AreEqual(d2Clone.HP, 2);
        }
    }
}