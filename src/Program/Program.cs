using System;
using System.Collections.Generic;
using RoleplayGame;

namespace Program
{
    class Program
    {
        static void Main(string[] args)
        {
            SpellsBook book = new SpellsBook();
            book.AddSpell(new SpellOne());
            book.AddSpell(new SpellOne());

            Wizard gandalf = new Wizard("Gandalf");
            gandalf.AddItem(book);

            Dwarf gimli = new Dwarf("Gimli");

            // Console.WriteLine($"Gimli has ❤️ {gimli.Health}");
            // Console.WriteLine($"Gandalf attacks Gimli with ⚔️ {gandalf.AttackValue}");

            // gimli.ReceiveAttack(gandalf.AttackValue);

            // Console.WriteLine($"Gimli has ❤️ {gimli.Health}");

            gimli.Cure();

            // Console.WriteLine($"Someone cured Gimli. Gimli now has ❤️ {gimli.Health}");

            // Giant giant = new Giant("Rodolfo the Giant");
            // Console.WriteLine($"{giant.Name} has ❤️ {giant.Health}");
            // giant.ReceiveAttack(gimli.AttackValue);
            // Console.WriteLine($"{giant.Name} was attacked and now has ❤️ {giant.Health}");

            Ogre ogre = new Ogre("Shrek");
            // Console.WriteLine($"{ogre.Name} has ❤️ {ogre.Health}");
            // gandalf.ReceiveAttack(ogre.AttackValue);
            // Console.WriteLine($"{gandalf.Name} was attacked by {ogre.Name} and now has ❤️ {gandalf.Health}");

            Gargoyle pedro = new Gargoyle("Pedro");
            // gandalf.AttackCharacter(pedro);
            // Console.WriteLine($"{pedro.Name} has been attacked by {gandalf.Name}, now he has {pedro.Health} and {gandalf.Name} has {gandalf.Vp} victory points.");
            // gandalf.AttackCharacter(pedro);
            // Console.WriteLine($"{pedro.Name} has been attacked by {gandalf.Name}, now he has {pedro.Health} and {gandalf.Name} has {gandalf.Vp} victory points.");

            //PARTE SANTIAGO

            // Verificar si el personaje ha muerto antes de realizar una acción
            if (pedro.IsDead())
            {
                Console.WriteLine($"{pedro.Name} ha muerto.");
            }
            Sword sword = new Sword();

            // List<Hero> heroes = new List<Hero>();
            // heroes.Add(gimli);
            // gimli.AddItem(sword);
            // Console.WriteLine($"{gimli.AttackValue} --- {gimli.DefenseValue}");
            // heroes.Add(gandalf);
            // Console.WriteLine($"{gandalf.AttackValue} --- {gandalf.DefenseValue}");
            // List<Enemy> enemies = new List<Enemy>();

            // enemies.Add(ogre);
            // Console.WriteLine($"{ogre.AttackValue} --- {ogre.DefenseValue}");
            // enemies.Add(giant);
            // Console.WriteLine($"{giant.AttackValue} --- {giant.DefenseValue}");
            // Encounter prueba = new Encounter(heroes, enemies);
            // prueba.DoEncounter();

            // Console.WriteLine($"\n{gimli.Name} tiene {gimli.Health} de vida y {gimli.VpObtained} vp obtenidos");
            // Console.WriteLine($"{gandalf.Name} tiene {gandalf.Health} de vida y {gandalf.VpObtained} vp obtenidos");
            // Console.WriteLine("Por otro lado, los enemy:");
            // Console.WriteLine($"{ogre.Name} tiene {ogre.Health} de vida y {ogre.VpObtained} vp obtenidos");
            // Console.WriteLine($"{giant.Name} tiene {giant.Health} de vida y {giant.VpObtained} vp obtenidos");
            Giant giant = new Giant("Pepe");
            //Console.WriteLine($"{giant.Name}: {giant.AttackValue} --- {giant.DefenseValue}");
            Giant doc = new Giant("doc");
            //Console.WriteLine($"{doc.Name}: {doc.AttackValue} --- {doc.DefenseValue}");
            Knight rex = new Knight ("Rex");
            //Console.WriteLine($"{rex.Name}: {rex.AttackValue} --- {rex.DefenseValue} ----> {rex.VpObtained}");
            Knight pedro1 = new Knight("Pedro");
            //Console.WriteLine($"{pedro1.Name}: {pedro1.AttackValue} --- {pedro1.DefenseValue}");
            

            Sword strom = new Sword();
            rex.AddItem(strom);

            List<Hero> heroes = new List<Hero>();
            heroes.Add(rex);
            heroes.Add(pedro1);

            List<Enemy> enemies = new List<Enemy>();
            enemies.Add(giant);
            enemies.Add(doc);

            Encounter prueba = new Encounter(heroes, enemies);
            prueba.DoEncounter();

            Console.WriteLine($"rex vp: {rex.VpObtained} ---- rex health: {rex.Health}");
        }
    }
}
