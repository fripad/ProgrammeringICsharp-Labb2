namespace Labb_2;

public class Snake : Enemy
{
    public Snake(int x, int y) 
    {
        X = x;
        Y = y;
        Name = "Snake";
        Character = 's';
        CharacterColor = ConsoleColor.Green;
        HP = 25;
        AttackDice = new Dice(3, 4, 2);
        DefenceDice = new Dice(1, 8, 5);
        
    }
    public override void Update()
    {
        // TODO: Update()
    }
}
