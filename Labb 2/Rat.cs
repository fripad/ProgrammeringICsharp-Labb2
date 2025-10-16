namespace Labb_2;

public class Rat : Enemy
{
    private readonly Random _random = new Random();
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
    public override void Update()
    {
        // TODO: Update()
    }

    public void MoveRat()
    {
        Console.SetCursorPosition(X, Y);
        Console.Write(" ");


        Direction[] directions = (Direction[])Enum.GetValues(typeof(Direction));

        Direction randomDirection = directions[_random.Next(directions.Length)];



        MoveIn(randomDirection);
    }
}
