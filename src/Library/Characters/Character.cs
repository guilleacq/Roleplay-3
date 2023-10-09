using System.Collections.Generic;

namespace RoleplayGame
{
    public class Character
    {
        protected int health = 100;
        protected List<IItem> items = new List<IItem>();
        private int vpObtained = 0;
        private int vp;
        public string Name { get; private set; }
        public int Vp { 
            get
            {
                return this.vp;
            } 
            private set
            {
                this.vp = this.IsDead() ? 0 : value;
            } 
        }

        public int VpObtained { 
            get
            {
                if (this.IsDead())
                {
                    return 0;
                }
                else
                {
                    return this.vpObtained;
                }
            }
            private set
            {
                this.vpObtained += value;
            } 
        }

        public Character(string name, int vp)
        {
            this.Name = name;
            this.vp = vp;
        }

        public int Health
        {
            get
            {
                return this.health;
            }
            private set
            {
                this.health = value < 0 ? 0 : value;
            }
        }

        

        public int AttackValue
        {
            get
            {
                int value = 0;
                foreach (IItem item in this.items)
                {
                    if (item is IAttackItem)
                    {
                        value += (item as IAttackItem).AttackValue;
                    }
                }
                return value;
            }
        }

        public int DefenseValue
        {
            get
            {
                int value = 0;
                foreach (IItem item in this.items)
                {
                    if (item is IDefenseItem)
                    {
                        value += (item as IDefenseItem).DefenseValue;
                    }
                }
                return value;
            }
        }

        public void AddItem(IItem item)
        {
            this.items.Add(item);
        }

        public void RemoveItem(IItem item)
        {
            this.items.Remove(item);
        }

        public void Cure()
        {
            this.Health = 100;
        }

        public void ReceiveAttack(int power)
        {
            if (this.DefenseValue < power)
            {
                this.Health -= power - this.DefenseValue;
            }
        }

        public void AttackCharacter(Character targetCharacter)
        {
            targetCharacter.ReceiveAttack(this.AttackValue);
            if (targetCharacter.IsDead())
            {
                this.AddVp(targetCharacter.Vp);
            }
        }

        public void AddVp(int vp)
        {
            if (!this.IsDead())
                this.VpObtained += vp;
        }

        public bool IsDead()
        {
            return this.Health <= 0;
        }
    }
}