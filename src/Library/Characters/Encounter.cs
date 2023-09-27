using System.Collections.Generic;
using System.Dynamic;

namespace RoleplayGame
{
    public class Encounter
    {
        public List<Hero> Heroes { get ; private set ; }
        public List<Enemy> Enemies { get ; private set; }
        public Encounter( List<Hero> heroes, List<Enemy> enemies )
        {
            this.Heroes = heroes;      
            this.Enemies = enemies;       
        }
        public void DoEncounter()
        {
            
        }

        private void AttackEnemyToHero()
        {

        }

        private void AttackHeroToEnemy()
        {
            
        }
    }
}