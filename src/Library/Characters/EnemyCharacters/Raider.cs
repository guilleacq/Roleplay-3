namespace RoleplayGame
{
    public class Raider : Enemy
{
    private const int RAIDER_VP = 40;
    public Raider(string name)
    :base(name, RAIDER_VP)
    {
        Bow bow = new Bow ();
        Helmet helmet = new Helmet();
        Armor armor = new Armor ();
    }
}
}