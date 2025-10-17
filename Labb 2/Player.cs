namespace Labb_2;

public class Player : Character 
{
    

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

    public void PlayerAttacks(Enemy enemy)
    {

        int attackPoints = this.AttackDice.Throw();
        int defencePoints = enemy.DefenceDice.Throw();
        int resultOfAttack = attackPoints - defencePoints;
        if (resultOfAttack > 0)
        {
            enemy.HP -= resultOfAttack;
            if (enemy.HP <= 0)
            {
                enemy.EraseFromDungeon();
                // TODO: //enemy.Erase(); erase måste ta bort position och plats i list elements
            }
        }
    }

   
}
