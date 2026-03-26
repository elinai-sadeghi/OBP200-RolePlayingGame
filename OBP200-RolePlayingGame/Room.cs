namespace OBP200_RolePlayingGame;

abstract class Room
{
    public string Label { get; }

    protected Room(string label)
    {
        Label = label;
    }

    public abstract bool Enter();
}