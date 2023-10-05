using System;
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
        public Encounter(List<Hero> heroes, List<Enemy> enemies)
        {
            // Acá deberíamos hacer manejo de excepciones 
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

                // Con esto determino quién ataca
                if (turn % 2 == 0)
                {
                    Attack(enemiesList, heroesList);
                }
                else
                {
                    Attack(heroesList, enemiesList);
                }
                turn += 1;

                CheckCombatStatus();
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

        private void CheckCombatStatus()
        {
            if (enemies.Count <= 0 || heroes.Count <= 0)
                inCombat = false;
                
        }

        private void Attack(List<Character> attackers, List<Character> targets)
        {
            if (targets.Count == 1)
            {
                int index = 0;
                Character currentAttacker;
                while (!targets[0].IsDead() || index <= attackers.Count)
                {
                    currentAttacker = attackers[index];
                    currentAttacker.AttackCharacter(targets[0]);
                    index += 1;
                }
                if (targets[0].IsDead())
                {
                    targets.Remove(targets[0]);
                }
            }

            else if (attackers.Count > targets.Count)
            {
                int turn = 0;
                int index;
                foreach (Character attacker in attackers)
                {
                    index = turn % targets.Count;
                    attacker.AttackCharacter(targets[index]);
                    if (targets[index].IsDead())
                    {
                        targets.Remove(targets[index]);
                    }
                    else
                    {
                        turn += 1;
                    }
                }
            }

            else if (targets.Count >= attackers.Count)
            {
                int index = 0;
                foreach (Character attacker in attackers)
                {
                    attacker.AttackCharacter(targets[index]);
                    if (targets[index].IsDead())
                    {
                        targets.Remove(targets[index]);
                    }
                    else
                    {
                        index += 1;
                    }
                }
            }
        }

    }
}