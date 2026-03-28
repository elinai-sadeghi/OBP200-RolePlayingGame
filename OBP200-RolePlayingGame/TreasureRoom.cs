namespace OBP200_RolePlayingGame;

class TreasureRoom : Room
{
    public TreasureRoom(string label) : base(label)
    {
    }

    public override bool Enter()
    {
        return Program.DoTreasure();
    }
}