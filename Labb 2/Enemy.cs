using System;

namespace Labb_2;

public abstract class Enemy : Character
{
    public abstract void Update(LevelData level, Player player);

    public bool ToDraw { get; set; }

    public string EnemyAttacks(Player player)
    {
        int attackPoints = this.AttackDice.Throw();
        int defencePoints = player.DefenceDice.Throw();
        int resultOfAttack = attackPoints - defencePoints;

        if (resultOfAttack <= 0)
        {
            return $"{this.Name} attacks ({this.AttackDice.ToString()} => {attackPoints}), you defend ({player.DefenceDice.ToString()} => {defencePoints})! You take no damage! Your health is {player.HP}";
        }

        player.HP -= resultOfAttack;

        
           return $"{this.Name} attacks ({this.AttackDice.ToString()} => {attackPoints}), you defend ({player.DefenceDice.ToString()} => {defencePoints})! You take {resultOfAttack} damage! Your health is {player.HP}";
    }
   
}
