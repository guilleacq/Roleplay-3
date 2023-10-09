using System.Collections.Generic;
namespace RoleplayGame
{
    public abstract class Enemy : Character
    {
        // public int Vp { get; private set; }

        //public Enemy(string name, int vp)
        //: base(name, vp);
        protected Enemy(string name) : base(name, 1)
        {
        }
    }
}
