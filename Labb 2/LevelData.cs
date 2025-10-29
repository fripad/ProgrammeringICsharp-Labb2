namespace Labb_2;

public class LevelData
{

    private List<LevelElement> _elements;

    public List<LevelElement> Elements
    {
        get { return _elements; }
    }

    public int PlayerStartX { get; set; }

    public int PlayerStartY { get; set; }

    public int MessageStartY { get; set; }

    public void Load(string filename)
    {
        _elements = new List<LevelElement>();


        using StreamReader reader = new StreamReader(filename);

        int x = 0;
        int y = 0;
        while (!reader.EndOfStream)
        {
            char gameChar = (char)reader.Read();

            if (gameChar == '#')
            {
                Elements.Add(new Wall(x, y));
            }

            if (gameChar == 'r')
            {
                Elements.Add(new Rat(x, y));
            }

            if (gameChar == 's')
            {
                Elements.Add(new Snake(x, y));
            }

            if (gameChar == '@')
            {
                PlayerStartX = x;
                PlayerStartY = y;
            }

            if (gameChar == '\n')
            {
                y++;
                x = 0;
            }
            else
            {
                x++;
            }

            // TODO: gör om till switch?

        }
        y += 2;
        MessageStartY = y;


    }

    public LevelElement? GetLevelElementAtPosition(int x, int y)
    {
        foreach (var element in Elements)
        {
            if (element.X == x && element.Y == y)
            {
                return element;
            }
        }

        return null;

    }

    public void PrintMessage(string message)
    {
        const int allowedMessageLength = 100;

        Console.SetCursorPosition(0, MessageStartY);
        Console.Write(new string(' ', allowedMessageLength));
        Console.SetCursorPosition(0, MessageStartY);

        if (message.Length >= allowedMessageLength)
        {
            Console.WriteLine($"Message is {message.Length}, it is too long.");
            return;
        }
       
        Console.WriteLine(message);
        while (Console.ReadKey(true).Key != ConsoleKey.Enter);
    }

    public void UpdateVisibility(Player player)
    {
        foreach (var element in Elements)
        {
            bool isNear = player.IsNear(element, player.ViewRange);

            if (element is Wall wall && !wall.IsDrawn && isNear)
            {
                wall.Draw();

            }
            else if (element is Enemy enemy)
            {

                if (isNear && !enemy.IsDrawn)
                {
                    enemy.Draw();
                }
                else if (!isNear && enemy.IsDrawn)
                {
                    enemy.EraseVisually();
                }
            }
        }
    }







}
