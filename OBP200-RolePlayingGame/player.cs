namespace OBP200_RolePlayingGame;
using System;

class Player : Character
{
    public string Class { get; private set; }
    public int MaxHp { get; private set; }

    public int Gold { get; private set; }
    public int Xp { get; private set; }
    public int Level { get; private set; }

    public int Potions { get; private set; }

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
    public void SpendGold(int amount)
    {
        if (amount > 0 && Gold >= amount)
        {
            Gold -= amount;
        }
    }
    public void Initialize(string name, string playerClass, int hp, int maxHp, int attack, int defense, int gold, int potions)
    {
        Name = name;
        Class = playerClass;

        Hp = hp;
        MaxHp = maxHp;

        Attack = attack;
        Defense = defense;

        Gold = gold;
        Xp = 0;
        Level = 1;

        Potions = potions;

        Inventory.Clear();
        Inventory.Add("Wooden Sword");
        Inventory.Add("Cloth Armor");
    }
    public void TakeDamage(int damage)
    {
        Hp -= Math.Max(0, damage);

        if (Hp < 0)
        {
            Hp = 0;
        }
    }
    public void RestoreToFullHealth()
    {
        Hp = MaxHp;
    }
    public void AddPotion(int amount)
    {
        if (amount > 0)
        {
            Potions += amount;
        }
    }

    public void IncreaseAttack(int amount)
    {
        if (amount > 0)
        {
            Attack += amount;
        }
    }

    public void IncreaseDefense(int amount)
    {
        if (amount > 0)
        {
            Defense += amount;
        }
    }
}
