namespace OBP200_RolePlayingGame;

class ShopRoom : Room
{
    public ShopRoom(string label) : base(label)
    {
    }

    public override bool Enter()
    {
        return Program.DoShop();
    }
}