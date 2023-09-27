using System;
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

            Console.WriteLine($"Gimli has ❤️ {gimli.Health}");
            Console.WriteLine($"Gandalf attacks Gimli with ⚔️ {gandalf.AttackValue}");

            gimli.ReceiveAttack(gandalf.AttackValue);

            Console.WriteLine($"Gimli has ❤️ {gimli.Health}");

            gimli.Cure();

            Console.WriteLine($"Someone cured Gimli. Gimli now has ❤️ {gimli.Health}");

            Giant giant = new Giant("Rodolfo the Giant");
            Console.WriteLine($"{giant.Name} has ❤️ {giant.Health}");
            giant.ReceiveAttack(gimli.AttackValue);
            Console.WriteLine($"{giant.Name} was attacked and now has ❤️ {giant.Health}");

            Ogre ogre = new Ogre ("Shrek");
            Console.WriteLine($"{ogre.Name} has ❤️ {ogre.Health}");
            gandalf.ReceiveAttack(ogre.AttackValue);
            Console.WriteLine($"{gandalf.Name} was attacked by {ogre.Name} and now has ❤️ {gandalf.Health}");

            Gargoyle pedro = new Gargoyle("Pedro");
            gandalf.AttackCharacter(pedro);
            Console.WriteLine($"{pedro.Name} has been attacked by {gandalf.Name}, now he has {pedro.Health} and {gandalf.Name} has {gandalf.Vp} victory points.");



        }
    }
}
