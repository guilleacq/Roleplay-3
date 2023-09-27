using System.Buffers.Text;
using RoleplayGame;

public class Giant : Enemy
{
    private const int GIANT_VP = 180;
    public Giant(string name)
    :base(name, GIANT_VP)
    {
    }
}