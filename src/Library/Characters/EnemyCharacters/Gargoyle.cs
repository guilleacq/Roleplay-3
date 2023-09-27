using System;
namespace RoleplayGame
{
    public class Gargoyle : Enemy
    {
        private const int VictoryPoints = 90;
        public Gargoyle(string name) : base (name, VictoryPoints)
        {
            this.AddItem(new Wings());
        }

    }
}