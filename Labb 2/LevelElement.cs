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

    public void MoveIn(Direction direction) //används först när man vet att pos är ledig 
    {
        //int oldX = X;
        //int oldY = Y;
        Console.SetCursorPosition(X - 1, Y);
        Console.Write(" "); //\b?

        switch (direction)
        {
            case Direction.Up:
                Y--;
                Draw();
                break;
            case Direction.Down:
                Y++;
                Draw();
                break;
            case Direction.Left:
                X--;
                Draw();
                break;
            case Direction.Right:
                X++;
                Draw();
                break;
        }
        // TODO: switch
        
      
    }


}
