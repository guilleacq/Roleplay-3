namespace RoleplayGame
{
    public class Hero : Character
    {
        // public int VpObtained { get ; private set ; }
        // public int Vp { get ; } = 0;
        public Hero(string name) : base(name, 0) {}

        // public void AddVp(int vp)
        // {
        //     this.VpObtained += vp;
        // }

        // public void AttackCharacter(Enemy targetCharacter)
        // {
        //     targetCharacter.ReceiveAttack(this.AttackValue);
        //     if (targetCharacter.IsDead())
        //     {
        //         this.AddVp(targetCharacter.Vp);
        //     }
        // }
    }
}