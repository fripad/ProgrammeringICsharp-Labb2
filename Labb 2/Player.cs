namespace Labb_2;

public class Player : LevelElement
{
    public string Name { get; set; }

    public int HP { get; set; }

    public Dice AttackDice { get; set; }

    public Dice DefenceDice { get; set; }

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
    }


}
