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

        public void AttackCharacter(Enemy targetCharacter)
        {
            targetCharacter.ReceiveAttack(this.AttackValue);
            if (targetCharacter.Health == 0)
            {
                this.AddVp(targetCharacter.Vp);
            }
        }
    }
}