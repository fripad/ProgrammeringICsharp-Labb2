namespace Labb_2;

public class LevelData
{

    private List<LevelElement> _elements;

    public List<LevelElement> Elements
    {
        get { return _elements; }
    }

    public void Load(string filename)
    {
        _elements = new List<LevelElement>();


        using (StreamReader reader = new StreamReader(filename))
        {
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
                    Elements.Add(new Player(x, y));
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


            }
        }

    }

    // TODO: gör om till switch?



}
