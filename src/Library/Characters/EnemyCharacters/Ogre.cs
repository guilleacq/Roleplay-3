namespace RoleplayGame
{
    public class Ogre : Enemy
    {
        private const int VP = 50;
        public Ogre(string name)
        : base(name)
        {
            this.AddItem(new Club()); //"Club" es un garrote
            this.AddItem(new Club());
            this.AddItem(new Armor());
        }
    }
}