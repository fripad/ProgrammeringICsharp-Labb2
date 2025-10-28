using System;
using System.Xml.Linq;

namespace Labb_2;



public abstract class Enemy : Character
{
    
    public abstract void Update(LevelData level, Player player);

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
