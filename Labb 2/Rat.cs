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
        ToDraw = false;
    }

    public override void Update(LevelData level, Player player)
    {
        TargetX = X;
        TargetY = Y;

        Direction randomDirection = (Direction)random.Next(4);
        if (randomDirection == Direction.Up) TargetY--;
        else if (randomDirection == Direction.Down) TargetY++;
        else if (randomDirection == Direction.Left) TargetX--;
        else if (randomDirection == Direction.Right) TargetX++;
    }
}
