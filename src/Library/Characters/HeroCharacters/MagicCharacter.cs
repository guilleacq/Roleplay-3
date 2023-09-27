using System.Collections.Generic;

namespace RoleplayGame
{
    public class MagicCharacter : Hero
    {
        protected List<IMagicalItem> magicalItems = new List<IMagicalItem>();

        public MagicCharacter(string name)
        : base(name) {}
        

        public void AddItem(IMagicalItem item)
        {
            this.magicalItems.Add(item);
        }

        public void RemoveItem(IMagicalItem item)
        {
            this.magicalItems.Remove(item);
        }
    }
}
