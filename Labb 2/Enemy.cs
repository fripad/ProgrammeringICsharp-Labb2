using System;
using System.Xml.Linq;

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
            return $"{Name} attacks you! Attack is blocked! Player HP: {HP} {Name} HP: {HP}";
        }

        player.HP -= resultOfAttack;

        return $"{Name} attacks with {attackPoints}, you defend with {defencePoints} and take {resultOfAttack} damage! Player HP: {player.HP} {Name} HP: {HP}"; 
            
    }
}
            //$"{this.Name} attacks with {attackPoints}, {player.Name} defends with {defencePoints}!";

            //$"{this.Name} attacks with {attackPoints}, {player.Name} defends with {defencePoints}!" +
            //$"\r\n{player.Name} takes {resultOfAttack} damage! HP: {player.HP}"; 
            