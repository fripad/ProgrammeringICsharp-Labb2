namespace Labb_2
{
    public class Character : LevelElement
    {
        public string Name { get; set; }

        public int HP { get; set; }

        public Dice AttackDice { get; set; }

        public Dice DefenceDice { get; set; }

        public bool IsAlive
        {
            get { return HP > 0; }
        }

        public void EraseVisually()
        {
            Console.SetCursorPosition(X, Y);
            Console.Write(" ");
            IsDrawn = false;
        }

        public void MoveTo(int newX, int newY)
        {
            EraseVisually();
            X = newX;
            Y = newY;
            Draw();
        }

        public void Attack(Character opponent)
        {

            int attackPoints = this.AttackDice.Throw();
            int defencePoints = opponent.DefenceDice.Throw();
            int resultOfAttack = attackPoints - defencePoints;
            //Console.WriteLine($"{this.Name} attacks with {attackPoints}, {opponent.Name} defends with {defencePoints}!");

            if (resultOfAttack > 0)
            {
                opponent.HP -= resultOfAttack;
            //Console.WriteLine($"{opponent.Name} takes {resultOfAttack} damage! HP: {opponent.HP}");
                //if (!opponent.IsAlive)
                //{
                //    opponent.EraseVisually();
                //    // TODO: inte göra detta här? ta bort ur newGame.Elements ej åtkomst här
                //}
            }
        }

        public void EnemyAttacks(Player player)
        {
            int attackPoints = this.AttackDice.Throw();
            int defencePoints = player.DefenceDice.Throw();
            int resultOfAttack = attackPoints - defencePoints;
            if (resultOfAttack > 0)
            {
                player.HP -= resultOfAttack;
                if (player.HP <= 0)
                {
                    // TODO: Game over
                }
            }
        }

    }
}
