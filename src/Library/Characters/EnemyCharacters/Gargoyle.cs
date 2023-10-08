using System;
namespace RoleplayGame
{
    public class Gargoyle : Enemy
    {
        private const int VictoryPoints = 40;
        public Gargoyle(string name) : base (name, VictoryPoints)
        {
            this.AddItem(new Wings());
        }

    }
}