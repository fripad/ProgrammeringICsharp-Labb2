namespace Labb_2
{
    public class Character : LevelElement
    {
        public string Name { get; set; }

        public int HP { get; set; }

        public Dice AttackDice { get; set; }

        public Dice DefenceDice { get; set; }

        public void EraseFromDungeon()
        {
            Console.SetCursorPosition(X, Y);
            Console.Write(" ");

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
}
