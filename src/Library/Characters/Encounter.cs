using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Net.NetworkInformation;

namespace RoleplayGame
{
    public class Encounter
    {
        private List<Hero> heroes;
        private List<Enemy> enemies;
        private bool inCombat = true;
        private List<Character> charactersToRemove;

        public Encounter(List<Hero> heroes, List<Enemy> enemies)
        {
            // Acá deberíamos hacer manejo de excepciones.
            if (heroes.Count > 0 && enemies.Count > 0)
            {
                this.heroes = heroes;
                this.enemies = enemies;
            }
        }

        public void DoEncounter()
        {
            List<Character> heroesList;
            List<Character> enemiesList;
            int turn = 0;
            while (inCombat)
            {
                enemiesList = EnemiesToList();
                heroesList = HeroToList();

                // Con esto determino quién ataca.
                if (turn % 2 == 0)
                {
                    Attack(enemiesList, heroesList);
                }
                else
                {
                    Attack(heroesList, enemiesList);
                }
                turn += 1;

                this.CheckCombatStatus(enemiesList, heroesList);
            }
            return;
        }

        private List<Character> HeroToList()
        {
            return new List<Character>(this.heroes.Cast<Character>()).ToList();
        }

        private List<Character> EnemiesToList()
        {
            return new List<Character>(this.enemies.Cast<Character>()).ToList();
        }

        private void CheckCombatStatus(List<Character> currentEnemies, List<Character> currentHeroes)
        {
            if ((currentHeroes.Count <= 0) || (currentEnemies.Count <= 0))
            {
                inCombat = false;
                // Entonces cuando se termina el encuentro devuelvo la vida a los héroes que posean +150 vp.
                if (heroes.Count > 0)
                {
                    foreach (Hero hero in this.heroes)
                    {
                        if (hero.Vp >= 150)
                            hero.Cure();
                    }
                }
            }
        }

        private void Attack(List<Character> attackers, List<Character> targets)
        {
            Character currentAttacker;
            Character currentTarget;

            if (targets.Count == 1)
            {
                // Si hay un único atacado, los atacantes actúan hasta que se muera o hasta que no hayan más atacantes.
                int index = 0;
                currentTarget = targets[0];
                while (!currentTarget.IsDead() || index <= attackers.Count)
                {
                    currentAttacker = attackers[index];
                    currentAttacker.AttackCharacter(targets[0]);
                    index += 1;
                }
                if (currentTarget.IsDead())
                {
                    targets.Remove(targets[0]);
                }
            }

            else if (attackers.Count > targets.Count)
            {
                // Si hay más atacados que atacantes, siendo estos un número mayor a 1.
                // Inicializo la variable turn que se utilizará para calcular el índice del atacado.
                int turn = 0;
                // El índice del atacado se calcula con módulo, de esta forma podemos hacer cumplir la lógica del juego de cuando hay más atacantes que atacados.
                int index;
                foreach (Character attacker in attackers)
                {
                    if (targets.Count > 0)
                    {
                        index = turn % targets.Count;
                        currentTarget = targets[index];
                        attacker.AttackCharacter(currentTarget);

                        if (currentTarget.IsDead())
                        {
                            targets.Remove(currentTarget);
                        }
                        else
                        {
                            turn += 1;
                        }
                    }
                }
            }

            else if (targets.Count >= attackers.Count)
            {
                // En el caso de que hayan menos o igual cantidad de atacantes que atacados, se cumple que por cada atacante hay un atacado.

                // Para no modificar la cantidad de elementos de la lista de atacados, y de esta forma evitar posibles erorres de indices, no modificamos directamente  
                // esta lista, sino que cada vez que muere un atacado se agrega a otra lista que posteriormente será recorrida para eliminarlos de la lista de atacados.
                charactersToRemove = new List<Character>();
                for (int index = 0; index < attackers.Count; index++)
                {
                    currentTarget = targets[index];
                    currentAttacker = attackers[index];
                    currentAttacker.AttackCharacter(currentTarget);

                    if (currentTarget.IsDead())
                    {
                        charactersToRemove.Add(currentTarget);
                    }
                }

                if (charactersToRemove.Count > 0)
                {
                    foreach (Character target in charactersToRemove)
                    {
                        targets.Remove(target);
                    }
                }
            }
        }
    }
}