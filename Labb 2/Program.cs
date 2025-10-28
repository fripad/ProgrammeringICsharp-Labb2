using Labb_2;
using System.ComponentModel;

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

        // TODO: greet player, explain how to move, prompt for key input (+ Console.Clear(); ?)

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
        // TODO: fråga om namn? 


        Player player = new Player(newGame.PlayerStartX, newGame.PlayerStartY);

        foreach (var element in newGame.Elements)
        {
            if (player.IsNear(element, player.ViewRange))
            {
                element.Draw();
                element.IsDrawn = true;
            }
            

        }

        player.Draw();

        while (player.IsAlive)
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
            if (!player.IsAlive)
            {
                break;
            }

            for (int i = newGame.Elements.Count - 1; i >= 0; i--)
            {
                var element = newGame.Elements[i];


                if (element is Enemy enemy)
                {
                    if (enemy.IsAlive)
                    {
                        enemy.Update(newGame, player);


                        if (collisionElement is Player collisionPlayer)
                        {
                            enemy.Attack(collisionPlayer);

                            //Console.WriteLine($"{this.Name} attacks with {attackPoints}, {opponent.Name} defends with {defencePoints}!");
                        }

                    }
                    else
                    {
                        enemy.EraseVisually();
                        newGame.Elements.RemoveAt(i);

                    }
                }
                



            }


        }
        // TODO: game over message 
            
    }

    // TODO: Game Loop
        //ha i metod i annan klass

    // TODO: Vision range: 
        //använd IsNear, gör metod för draw/erase? 

    // TODO: Attack & försvar:
        //metod Battle?
        //PrintMessage under och efter battle
        //snake battle
        //enemy battle

}




