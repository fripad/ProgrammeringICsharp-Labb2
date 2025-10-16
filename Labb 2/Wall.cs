namespace Labb_2;

public class Wall : LevelElement
{
    public Wall(int x, int y)
    {
        X = x;
        Y = y;
        Character = '#';
        CharacterColor = ConsoleColor.Gray;
    }
}
