namespace Labb_2;

public class Snake : Enemy
{
    private readonly Random random = new Random();

    public int ScareDistance { get; set; }
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
        ScareDistance = 2;
        ToDraw = false;

    }

    
    public override void Update(LevelData level, Player player)
    {

        if (!player.IsNear(this, ScareDistance))
        {
            return;
        }

        TargetX = X;
        TargetY = Y;

        // TODO: bör egentligen välja axis att fly där avståndet störst, inte automatiskt y som nedan

        if (player.Y < this.Y )
        {
            TargetY++;
        }
        else if (player.Y - this.Y > 0)
        {
            TargetY--;
        }
        else if (player.X - this.X < 0)
        {
            TargetX++;
        }
        else if (player.X - this.X > 0)
        {
            TargetX--;
        }

    }
}
