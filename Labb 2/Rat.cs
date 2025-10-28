namespace Labb_2;

public class Rat : Enemy
{
    private readonly Random random = new Random();
    public Rat(int x, int y)
    {
        X = x;
        Y = y;
        Name = "Rat";
        Character = 'r';
        CharacterColor = ConsoleColor.Red;
        HP = 10;
        AttackDice = new Dice(1, 6, 3);
        DefenceDice = new Dice(1, 6, 1);
    }
    public override void Update(LevelData level, Player player)
    {
        int newX = this.X;
        int newY = this.Y;

        Direction randomDirection = (Direction)random.Next(4);
        if (randomDirection == Direction.Up) newY--;
        else if (randomDirection == Direction.Down) newY++;
        else if (randomDirection == Direction.Left) newX--;
        else if (randomDirection == Direction.Right) newX++;

        LevelElement? collisionElement = level.GetLevelElementAtPosition(newX, newY);
        if (collisionElement == null)
        {
            this.MoveTo(newX, newY);
        }

    }


}
