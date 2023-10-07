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
            Knight  Rex = new Knight ("Rex");

            Assert.AreEqual( 100 , Rex.Health);
            Assert.AreEqual( "Rex" , Rex.Name);
            Assert.AreEqual( 0 , Rex.Vp);
        }


        [Test]
        public void TestEnemy()
        {
            Giant Giant = new Giant("Pepe");
            Assert.AreEqual( 100 , Giant.Health);
            Assert.AreEqual( "Pepe" , Giant.Name);
            Assert.AreEqual( 180 , Giant.Vp);

        }

        [Test]

        public void testAddItem() 
        {
             Knight  Rex = new Knight ("Rex");
             Sword strom = new Sword();
             Rex.AddItem(strom); //tiene 2 espadas que hacen 40 de daño en total
            Assert.AreEqual( 40 , Rex.AttackValue);
        }

        [Test]
        public void TestAtackEnemy()
        {
            Giant Giant = new Giant("Pepe");
            Knight  Rex = new Knight ("Rex");
            Rex.AttackCharacter(Giant);
            Assert.AreEqual( 80 , Giant.Health);
        }
        [Test]
        public void TestEnemyAtackHero()
        {
            Giant Giant = new Giant("Pepe");
            Knight  Rex = new Knight ("Rex");
            Giant.AttackCharacter(Rex);
            Assert.AreEqual( 89 , Rex.Health);
        }

        [Test]
        public void TestEncounter()
        {
            Giant Giant = new Giant("Pepe");
            Giant Doc = new Giant("doc");
            Knight  Rex = new Knight ("Rex");
            Sword strom = new Sword();
            Rex.AddItem(strom);
            List<Hero> heroes = new List<Hero>();
            heroes.Add(Rex);
            List<Enemy> enemies = new List<Enemy>();
            enemies.Add(Giant);
            enemies.Add(Doc);
            Encounter prueba = new Encounter(heroes, enemies);
            
            Assert.AreNotEqual( 100 , Giant.Health);// no deveria ser 100, porque el caballero venceria al gigante

            Assert.AreNotEqual( 100 , Rex.Health);//no deveria ser 100, porque salio de un combate 

            Assert.AreNotEqual( 0 , Rex.Vp);//no deveria ser 0, porque vencio al gigante
        }
    }
}