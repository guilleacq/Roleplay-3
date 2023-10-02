using System.Collections.Generic;
using System.Dynamic;

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
            while (inCombat)
            {





            }
        }

        private void CheckCombatStatus()
        {
            if (enemies.Count <= 0 || heroes.Count <= 0)
                inCombat = false;
        }
    }
}