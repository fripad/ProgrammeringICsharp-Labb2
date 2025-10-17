using Labb_2;

public abstract class LevelElement
{
    public int X { get; set; }
    public int Y { get; set; }
    public char Character { get; set; }
    public ConsoleColor CharacterColor { get; set; }

    public void Draw()
    {
        Console.SetCursorPosition(X, Y);
        Console.ForegroundColor = CharacterColor;
        Console.Write(Character);
        Console.ResetColor();
    }

    public void MoveTo(int newX, int newY)
    {
        Console.SetCursorPosition(X, Y);
        Console.Write(" ");
        X = newX;
        Y = newY;
        Draw();
    }


 


}
