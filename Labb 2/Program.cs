using Labb_2;

internal class Program
{
    private static void Main(string[] args)
    {
        //Console.WriteLine(
        //"""
        //                Welcome to The Dungeon!

        //Move your character using the Up, Down, Left and Right arrow keys
        // Start the game by pressing Enter\r\n" +
        //""");

        // TODO: greet player, explain how to move, prompt for key input + Console.Clear();

        ConsoleKeyInfo pressedKey = Console.ReadKey(true);

        if (pressedKey.Key == ConsoleKey.Enter)
        {

        }
        else if (pressedKey.Key == ConsoleKey.Escape)
        {
            return;
        }

        Console.CursorVisible = true;

        LevelData newGame = new LevelData();

        newGame.Load("Level1.txt");

        Player? player = null;

        foreach (var element in newGame.Elements)
        {
            element.Draw();

            if (element is Player p)
            {
                player = p;
            }

        }

        while (player.HP > 0)
        {

            ConsoleKeyInfo playerInput = Console.ReadKey(true);
            int newX = player.X;
            int newY = player.Y;

            if (playerInput.Key == ConsoleKey.UpArrow) newY--;
            else if (playerInput.Key == ConsoleKey.DownArrow) newY++;
            else if (playerInput.Key == ConsoleKey.LeftArrow) newX--;
            else if (playerInput.Key == ConsoleKey.RightArrow) newX++;

            LevelElement? collisionElement = newGame.GetLevelElementAtPosition(newX, newY);
            if (collisionElement == null)
            {
                player.MoveTo(newX, newY);
            }
            else if (collisionElement is Enemy enemy)
            {
                player.PlayerAttacks(enemy);
                enemy.EnemyAttacks(player);
            }

            foreach (var element in newGame.Elements)
            {
                if (element is Enemy enemy)
                {
                    if (enemy.HP > 0)
                    {
                        enemy.Update(newGame);
                    } 
                    else
                    {
                        enemy.EraseFromDungeon();

                        int indexOfThisEnemy = newGame.Elements.FindIndex(newGame => enemy.HP >= 0);

                        if (indexOfThisEnemy != -1)
                        {
                            newGame.Elements.RemoveAt(indexOfThisEnemy); //exception: indexoutofbounds 
                        }

                    }
                }


            }
            // TODO: enemy.Turn() eller enemy.EnemyTurn()
            //loopa fiender & if enemy så enemy.update
            //
            //2.move (inkl. newXY, collision, MoveTo eller collision is player)
            //rats turn?? 
            //rat.MoveRat();

        }
    }

    //static? private? void GameLoop()
    //{

    //}

    //is collision between , gör boolean istället
    //kolla i update istället?

    // TODO: Game Loop

    // TODO: Vision range: 

    // TODO: Attack & försvar:

    // TODO: Förflyttningsmönster, se Update()

}




