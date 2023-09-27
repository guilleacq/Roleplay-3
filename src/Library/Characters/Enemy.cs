using System.Collections.Generic;
namespace RoleplayGame
{
    public class Enemy : Hero
    {
        public int Vp { get; private set; }


        public Enemy(string name, int vp)
        : base(name)
        {
            this.Vp = vp;
        }



    }
}
