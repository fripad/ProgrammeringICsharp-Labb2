using System;
using System.Xml.Linq;

namespace Labb_2;



public abstract class Enemy : LevelElement
{
    public string Name { get; set; }

    public int HP { get; set; }

    public Dice AttackDice { get; set; }

    public Dice DefenceDice { get; set; }

    public abstract void Update(LevelData level);

    public void EraseFromDungeon()
    {
        Console.SetCursorPosition(X, Y);
        Console.Write(" ");
        
    }

    public void EnemyAttacks(Player player)
    {
        int attackPoints = this.AttackDice.Throw();
        int defencePoints = player.DefenceDice.Throw();
        int resultOfAttack = attackPoints - defencePoints;
        if (resultOfAttack > 0)
        {
            player.HP -= resultOfAttack;
            if (player.HP <= 0)
            {
                // TODO: Game over
            }
        }
    }
}
