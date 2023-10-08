using System.Collections.Generic;
using System.Data;
using NUnit.Compatibility;
using NUnit.Framework;
using RoleplayGame;

namespace Test.Library
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }
        [Test]
         public void TestHero()
        {
            Knight rex = new Knight ("Rex");

            Assert.AreEqual( 100 , rex.Health);
            Assert.AreEqual( "Rex" , rex.Name);
            Assert.AreEqual( 0 , rex.Vp);
        }


        [Test]
        public void TestEnemy()
        {
            Giant giant = new Giant("Pepe");
            Assert.AreEqual( 100 , giant.Health);
            Assert.AreEqual( "Pepe" , giant.Name);
            Assert.AreEqual( 50 , giant.Vp);

        }

        [Test]

        public void testAddItem() 
        {
            Knight  rex = new Knight ("Rex");
            Sword strom = new Sword();
            rex.AddItem(strom); //tiene 2 espadas que hacen 40 de daño en total
            Assert.AreEqual( 40 , rex.AttackValue);
        }

        [Test]
        public void TestAtackEnemy()
        {
            Giant giant = new Giant("Pepe");
            Knight  rex = new Knight ("Rex");
            rex.AttackCharacter(giant);
            Assert.AreEqual( 80 , giant.Health);
        }

        [Test]
        public void TestEnemyAtackHero()
        {
            Giant giant = new Giant("Pepe");
            Knight rex = new Knight ("Rex");
            giant.AttackCharacter(rex);
            Assert.AreEqual( 89 , rex.Health);
        }

        [Test]
        public void TestEncounter()
        {
            Giant giant = new Giant("Pepe");
            Giant doc = new Giant("doc");
            Knight rex = new Knight ("Rex");

            Sword strom = new Sword();
            rex.AddItem(strom);

            List<Hero> heroes = new List<Hero>();
            heroes.Add(rex);

            List<Enemy> enemies = new List<Enemy>();
            enemies.Add(giant);
            enemies.Add(doc);

            Encounter prueba = new Encounter(heroes, enemies);
            prueba.DoEncounter();

            Assert.AreEqual( 0 , giant.Health); 
            Assert.AreEqual( 0 , rex.Health);
            Assert.AreNotEqual( 0 , rex.Vp); // No debería ser 0 porque mató a los dos enemy.
        }
    }
}