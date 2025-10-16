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

        Rat rat = null;

        foreach (var element in newGame.Elements)
        {
            element.Draw();

            if (element is Player p)
            {
                player = p;
            }
            if (element is Rat r)
            {
                rat = r;
            }

        }



        LevelElement? Collision(int newX, int newY)
        {
            foreach (var element in newGame.Elements)
            {
                if (element.X == newX && element.Y == newY)
                {
                    return element;
                }
            }

            return null;

        }

        //void CollideWithEnemy()
        //{
        //    if (collisionElement is Enemy enemy)
        //        {
        //        int attackPoints = player.AttackDice.Throw();
        //        int defencePoints = enemy.DefenceDice.Throw();
        //        int resultOfAttack = attackPoints - defencePoints;
        //        if (resultOfAttack > 0)
        //        {
        //            enemy.HP -= resultOfAttack;
        //            if (enemy.HP <= 0)
        //            {
        //                // TODO: //enemy.Erase(); erase måste ta bort position och plats i list elements
        //            }


        //        }

        //    }
        //}





        while (player.HP > 0)
        {

            ConsoleKeyInfo playerInput = Console.ReadKey(true);
            int newX;
            int newY;

            if (playerInput.Key == ConsoleKey.UpArrow)
            {
                newX = player.X;
                newY = player.Y - 1;

                LevelElement? collisionElement = Collision(newX, newY);
                if (collisionElement == null)
                {
                    player.MoveIn(Direction.Up);
                }
                else if (collisionElement is Enemy enemy)
                {
                    int attackPoints = player.AttackDice.Throw();
                    int defencePoints = enemy.DefenceDice.Throw();
                    int resultOfAttack = attackPoints - defencePoints;
                    if (resultOfAttack > 0)
                    {
                        enemy.HP -= resultOfAttack;
                        if (enemy.HP <= 0)
                        {
                            // TODO: //enemy.Erase(); erase måste ta bort position och plats i list elements
                        }


                    }

                }
            }
            else if (playerInput.Key == ConsoleKey.DownArrow)
            {
                newX = player.X;
                newY = player.Y + 1;

                LevelElement? collisionElement = Collision(newX, newY);
                if (collisionElement == null)
                {
                    player.MoveIn(Direction.Down);
                }

            }
            else if (playerInput.Key == ConsoleKey.LeftArrow)
            {
                newX = player.X - 1;
                newY = player.Y;

                LevelElement? collisionElement = Collision(newX, newY);
                if (collisionElement == null)
                {
                    player.MoveIn(Direction.Left);
                }
            }
            else if (playerInput.Key == ConsoleKey.RightArrow)
            {
                newX = player.X + 1;
                newY = player.Y;

                LevelElement? collisionElement = Collision(newX, newY);
                if (collisionElement == null)
                {
                    player.MoveIn(Direction.Right);
                }
            }

            //rats turn?? 

        }
    }

    //static? private? void GameLoop()
    //{

    //}






    //is collision between , gör boolean istället
    //kolla i update istället?

}




// TODO: 
/*Game Loop
En game loop är en loop som körs om och om igen medan spelet är igång
och i vårat fall kommer ett varv i loopen motsvaras av en omgång i spelet. 
För varje varv i loopen inväntar vi att användaren trycker in en knapp; 
sedan utför vi spelarens drag, följt av datorns drag (uppdatera alla fiender), innan vi loopar igen. 
Möjligtvis kan man ha en knapp (Esc) för att avsluta loopen/spelet.
 
När spelaren/fiender flyttar på sig behöver vi beräkna deras nya position 
och leta igenom alla vår LevelElements för att se om det finns något annat objekt på den platsen man försöker flytta till.
Om det finns en vägg eller annat objekt (fiende/spelaren) på platsen 
måste förflyttningen avbrytas och den tidigare positionen gälla. 
Notera dock att om spelaren flyttar sig till en plats där det står en fiende 
så attackerar han denna (mer om detta längre ner). Detsamma gäller om en fiende flyttar sig till platsen där spelaren står. 
Fiender kan dock inte attackera varandra i spelet.
Se övning @ i exercises - loopar */

// TODO: Vision range: 

// TODO: Attack & försvar:

// TODO: Förflyttningsmönster, se Update()




