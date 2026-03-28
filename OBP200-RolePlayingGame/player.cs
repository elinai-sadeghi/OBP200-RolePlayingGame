namespace OBP200_RolePlayingGame;
using System;

class Player : Character
{
    public string Class { get; set; }

    public int MaxHp { get; set; }

    public int Gold { get; set; }
    public int Xp { get; set; }
    public int Level { get; set; }

    public int Potions { get; set; }

    public List<string> Inventory { get; private set; } = new();

    public void UsePotion()
    {
        if (Potions <= 0)
        {
            Console.WriteLine("Du har inga drycker kvar.");
            return;
        }

        int oldHp = Hp;
        int heal = 12;
        Hp = Math.Min(MaxHp, Hp + heal);
        Potions--;

        Console.WriteLine($"Du dricker en dryck och återfår {Hp - oldHp} HP.");
    }
    public bool IsDead()
    {
        return Hp <= 0;
    }
    public void AddXp(int amount)
    {
        Xp += Math.Max(0, amount);
        MaybeLevelUp();
    }
    private void MaybeLevelUp()
    {
        int nextThreshold = Level == 1 ? 10 : (Level == 2 ? 25 : (Level == 3 ? 45 : Level * 20));

        if (Xp >= nextThreshold)
        {
            Level++;

            switch (Class)
            {
                case "Warrior":
                    MaxHp += 6;
                    Attack += 2;
                    Defense += 2;
                    break;
                case "Mage":
                    MaxHp += 4;
                    Attack += 4;
                    Defense += 1;
                    break;
                case "Rogue":
                    MaxHp += 5;
                    Attack += 3;
                    Defense += 1;
                    break;
            }

            Hp = MaxHp;
            Console.WriteLine($"Du når nivå {Level}! Värden ökade och HP återställd.");
        }
    }
    public void AddGold(int amount)
    {
        Gold += Math.Max(0, amount);
    }
}
