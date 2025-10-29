using System;
using System.Xml.Linq;

namespace Labb_2;
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

        // TODO: greet player, explain how to move, explain messages,  prompt for key input (+ Console.Clear(); ?)

        ConsoleKeyInfo pressedKey = Console.ReadKey(true);

        if (pressedKey.Key == ConsoleKey.Enter)
        {

        }
        else if (pressedKey.Key == ConsoleKey.Escape)
        {
            return;
        }

        Console.CursorVisible = true;

        LevelData level = new LevelData();

        level.Load("Level1.txt");
        // TODO: fråga om namn? 


        Player player = new Player(level.PlayerStartX, level.PlayerStartY);

        player.Draw();
        level.UpdateVisibility(player);

        while (player.IsAlive)
        {

            ConsoleKeyInfo playerInput = Console.ReadKey(true);
            int newX = player.X;
            int newY = player.Y;

            if (playerInput.Key == ConsoleKey.UpArrow) newY--;
            else if (playerInput.Key == ConsoleKey.DownArrow) newY++;
            else if (playerInput.Key == ConsoleKey.LeftArrow) newX--;
            else if (playerInput.Key == ConsoleKey.RightArrow) newX++;

            LevelElement? playerCollision = level.GetLevelElementAtPosition(newX, newY);
            if (playerCollision == null)
            {
                player.MoveTo(newX, newY);
                level.UpdateVisibility(player);
            }
            else if (playerCollision is Enemy enemy)
            {
                player.PlayerAttacks(enemy);
                level.PrintMessage(player.PlayerAttacks(enemy));


                if (enemy.IsAlive)
                {
                    enemy.EnemyAttacks(player);
                    level.PrintMessage(enemy.EnemyAttacks(player));

                }
            }

            if (!player.IsAlive)
            {
                break;
            }

            for (int i = level.Elements.Count - 1; i >= 0; i--)
            {
                LevelElement element = level.Elements[i];

                if (element is Enemy enemy)
                {
                    if (enemy.IsAlive)
                    {
                        enemy.Update(level, player);
              
                        LevelElement? enemyCollision = level.GetLevelElementAtPosition(enemy.TargetX, enemy.TargetY);

                        if (enemyCollision == null)
                        {
                            enemy.MoveTo(enemy.TargetX, enemy.TargetY);
                        }
                        else if (enemyCollision is Player collisionPlayer)
                        {
                            enemy.EnemyAttacks(player);
                            level.PrintMessage(enemy.EnemyAttacks(player));

                            if (player.IsAlive)
                            {
                                player.PlayerAttacks(enemy);
                                level.PrintMessage(player.PlayerAttacks(enemy));
                            }
                            else
                            {
                                break;
                            }

                        }

                    }
                    else if (!enemy.IsAlive)
                    {
                        enemy.EraseVisually();
                        level.Elements.RemoveAt(i);
                    }
                }
            }
            level.UpdateVisibility(player);

           
        }
        // TODO: game over message 

    

    }
                            
    
    //Console.WriteLine($"{this.Name} attacks with {attackPoints}, {opponent.Name} defends with {defencePoints}!");



    // TODO: Game Loop
    //ha i metod i annan klass

    // TODO: Attack & försvar:
    //metod Battle?
    //PrintMessage under och efter battle
    //snake battle
    //enemy battle

}




