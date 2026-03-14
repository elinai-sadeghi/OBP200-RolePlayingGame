namespace OBP200_RolePlayingGame;

class Player : Character
{
    public string Class { get; set; }
    
    public int MaxHp { get; set; }

    public int Gold { get; set; }
    public int Xp { get; set; }
    public int Level { get; set; }

    public int Potions { get; set; }

    public List<string> Inventory { get; set; } = new();
}