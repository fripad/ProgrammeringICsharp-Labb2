namespace Labb_2;
internal class Program
{
    private static void Main(string[] args)
    {
        Console.CursorVisible = false;
        Console.WriteLine(
        """
                        
        
                           Welcome to The Dungeon!

        Move your character using the Up, Down, Left and Right arrow keys

        If you encounter enemies, attack them by colliding with them

        When a message appears, press Enter to continue game

        Start the game by pressing Enter 
        """);

        ConsoleKeyInfo pressedKey = Console.ReadKey(true);

        if (pressedKey.Key == ConsoleKey.Enter)
        {

        }
        else if (pressedKey.Key == ConsoleKey.Escape)
        {
            return;
        }

        Console.Clear();

        LevelData level = new LevelData();

        level.Load("Level1.txt");

        Player player = new Player(level.PlayerStartX, level.PlayerStartY);

        player.Draw();
        level.UpdateVisibility(player);

        while (player.IsAlive)
        {
            ConsoleKeyInfo playerInput = Console.ReadKey(true);
            player.TargetX = player.X;
            player.TargetY = player.Y;

            if (playerInput.Key == ConsoleKey.UpArrow) player.TargetY--;
            else if (playerInput.Key == ConsoleKey.DownArrow) player.TargetY++;
            else if (playerInput.Key == ConsoleKey.LeftArrow) player.TargetX--;
            else if (playerInput.Key == ConsoleKey.RightArrow) player.TargetX++;

            LevelElement? playerCollision = level.GetLevelElementAtPosition(player.TargetX, player.TargetY);
            if (playerCollision == null)
            {
                player.Move();
                player.Draw();
                level.UpdateVisibility(player);
            }
            else if (playerCollision is Enemy enemy)
            {
                string playerAttackMessage = player.PlayerAttacks(enemy);
                level.PrintMessage(playerAttackMessage);

                if (enemy.IsAlive)
                {
                    string enemyAttackMessage = enemy.EnemyAttacks(player);
                    level.PrintMessage(enemyAttackMessage);
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
                            enemy.Move();
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
            player.Draw();
        }
        Console.WriteLine("""

                               GAME OVER!
                 
                           
            """);
    }
}




