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
            if (heroes.Count > 0 && enemies.Count > 0)
            {
                this.heroes = heroes;
                this.enemies = enemies;
            }
        }
        public void DoEncounter()
        {   
            List<Character> heroesArray;
            List<Character> enemiesArray;
            int turn = 0;
            while (inCombat)
            {
                enemiesArray = EnemiesToArray();
                heroesArray = HeroToArray();

                if (turn % 2 == 0)
                {
                    Attack(enemiesArray, heroesArray);
                }
                else
                {
                    Attack(heroesArray, enemiesArray);
                }
                turn += 1;
                CheckCombatStatus();
            }
        }
        
        private List<Character> HeroToArray()
        {
            List<Character> heroesArray = new List<Character>(this.heroes.Cast<Character>()).ToList();
            return heroesArray;
        }

        private List<Character> EnemiesToArray()
        {
            List<Character> enemiesArray = new List<Character>(this.enemies.Cast<Character>()).ToList();
            return enemiesArray;
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
                while (!targets[0].IsDead() || index >= attackers.Count)
                {
                    currentAttacker = attackers[index];
                    currentAttacker.AttackCharacter(targets[0]);
                    index += 1;
                }
                if (targets[0].Health <= 0)
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
                    if (targets[index].Health <= 0)
                    {
                        targets.Remove(targets[index]);
                    }
                }

            }
            else if (targets.Count >= attackers.Count)
            {
                int index = 0;
                foreach (Character attacker in attackers)
                {
                    attacker.AttackCharacter(targets[index]);
                    index += 1;
                    if (targets[index].Health <= 0)
                    {
                        targets.Remove(targets[index]);
                    }
                }
            }
        }
    }
}