using System.Buffers.Text;
using RoleplayGame;

public class Giant : Enemy
{
    //private const int GIANT_VP = 50;
    public Giant(string name)
    :base(name)
    {
        this.AddItem(new Axe());
        this.AddItem(new Axe());
    }
}