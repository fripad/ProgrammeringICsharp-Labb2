namespace Labb_2
{
    public class Character : LevelElement
    {
        public string Name { get; set; }

        public int HP { get; set; }

        public Dice AttackDice { get; set; }

        public Dice DefenceDice { get; set; }

        public int TargetX { get; set; }
        public int TargetY { get; set; }

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

        //move to()
        //X = TargetX
        public void MoveTo(int newX, int newY)
        {
            EraseVisually();
            X = newX;
            Y = newY;
        }

        public void Attack(Character opponent)
        {

            int attackPoints = this.AttackDice.Throw();
            int defencePoints = opponent.DefenceDice.Throw();
            int resultOfAttack = attackPoints - defencePoints;
            

            if (resultOfAttack > 0)
            {
                opponent.HP -= resultOfAttack;
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
                
            }
        }

    }
}
