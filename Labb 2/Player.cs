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

    public void PlayerAttacks(Enemy enemy)
    {

        int attackPoints = this.AttackDice.Throw();
        Console.WriteLine();
        int defencePoints = enemy.DefenceDice.Throw();
        int resultOfAttack = attackPoints - defencePoints;
        if (resultOfAttack > 0)
        {
            enemy.HP -= resultOfAttack;
            if (enemy.HP <= 0)
            {
                enemy.EraseVisually();
                // TODO: inte göra detta här? ta bort ur newGame.Elements ej åtkomst här
            }
        }
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
