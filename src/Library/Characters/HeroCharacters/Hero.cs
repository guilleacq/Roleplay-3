namespace RoleplayGame
{
    public class Hero : Character
    {
        public int Vp { get ; private set; } = 0;
        public Hero(string name) : base(name) {}

        public void AddVp(int vp)
        {
            this.Vp += vp;
        }
    }
}