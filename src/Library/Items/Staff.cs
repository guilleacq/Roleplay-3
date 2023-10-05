namespace RoleplayGame
{
    public class Staff: IAttackItem, IDefenseItem
    {
        public int AttackValue 
        {
            get
            {
                return 80;
            } 
        }

        public int DefenseValue
        {
            get
            {
                return 25;
            }
        }
    }
}