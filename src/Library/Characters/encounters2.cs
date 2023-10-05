using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Net.NetworkInformation;

namespace RoleplayGame
{
    public class Encounter2
    {
        private List<Hero> heroes;
        private List<Enemy> enemies;
        private bool inCombat = true;
        private List<Character> charactersToRemove;

        public Encounter2(List<Hero> heroes, List<Enemy> enemies)
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
            if ((currentHeroes.Count <= 0 ) || (currentEnemies.Count <= 0)){
                inCombat = false;
                // Entonces cuando se termina el encuentro devuelvo la vida a los heroes que posean +150 vp.
                if (heroes.Count > 0)
                {
                    foreach( Hero hero in this.heroes)
                    {
                        if (hero.Vp >= 150)
                            hero.Cure();
                    }
                }
            }
        }

        private void Attack(List<Character> attackers, List<Character> targets)
        {
            charactersToRemove  = new List<Character>();
            
            Character currentAttacker;
            Character currentTarget;

            if (targets.Count == 1)
            {
                Character target = targets[0];
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
                int turn = 0;
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
                for(int index = 0; index < attackers.Count; index++)
                {
                    currentTarget = targets[index];
                    currentAttacker = attackers[index];
                    currentAttacker.AttackCharacter(currentTarget);
                    
                    if (currentTarget.IsDead())
                    {
                        targets.Remove(currentTarget);
                    }
                }
            }
        }
    }
}