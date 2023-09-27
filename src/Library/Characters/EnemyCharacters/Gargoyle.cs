namespace RoleplayGame
{
    public class Gargoyle : Enemy
    {
        private const int VP = 90;
        public Gargoyle(string name) : base (name, VP)
        {
            this.AddItem(new Wings());
        }
    }
}