namespace OBP200_RolePlayingGame;

class Enemy
{
    public string Type { get; set; }
    public string Name { get; set; }

    public int Hp { get; set; }
    public int Attack { get; set; }
    public int Defense { get; set; }

    public int XpReward { get; set; }
    public int GoldReward { get; set; }
}