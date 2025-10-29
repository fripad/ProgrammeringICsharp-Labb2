using System.Numerics;

namespace Labb_2;

public class Player : Character 
{
    public int ViewRange { get; set; }
   
    public Player(int x, int y)
    {
        Name = "Player";
        CharacterColor = ConsoleColor.White;
        Character = '@';
        HP = 100;
        X = x;
        Y = y;
        AttackDice = new Dice(2, 6, 2);
        DefenceDice = new Dice(2, 6, 0);
        ViewRange = 5;
        
    }

    public string PlayerAttacks(Enemy enemy)
    {

        int attackPoints = this.AttackDice.Throw();
        int defencePoints = enemy.DefenceDice.Throw();
        int resultOfAttack = attackPoints - defencePoints;
        
        if (resultOfAttack <= 0)
        {
            return $"You attack {enemy.Name}! Your attack is blocked! Player HP: {HP} {enemy.Name} HP: {enemy.HP}";
        }
        
        enemy.HP -= resultOfAttack;
        
        return $"You attack with {attackPoints} {enemy.Name} defends with {defencePoints} and takes {resultOfAttack} damage! Player HP: {HP} {enemy.Name} HP: {enemy.HP}";
    }

    public bool IsNear(LevelElement anyElement, int range)
    {
        int xDistance = anyElement.X - this.X;
        int yDistance = anyElement.Y - this.Y;

        int xDistanceSquared = xDistance * xDistance;
        int yDistanceSquared = yDistance * yDistance;

        int distanceSquared = xDistanceSquared + yDistanceSquared;

        int rangeSquared = range * range;

        return distanceSquared <= rangeSquared; 

    }

}
