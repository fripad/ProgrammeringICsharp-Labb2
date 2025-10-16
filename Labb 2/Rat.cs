namespace Labb_2;

public class Rat : Enemy
{
    public Rat(int x, int y)
    {
        X = x;
        Y = y;
        Name = "Rat";
        Character = 'r';
        CharacterColor = ConsoleColor.Red;
        HP = 10;
        AttackDice = new Dice(1, 6, 3);
        DefenceDice = new Dice(1, 6, 1);
    }
    public override void Update()
    {
        // TODO: Update()
        //Förflyttningsmönster
        //-Spelaren förflyttar sig 1 steg upp, ner, höger eller vänster varje omgång, alternativt står still,
        //beroende på vilken knapp användaren tryckt på.
        //-Rat förflyttar sig 1 steg i slumpmässig vald riktning(upp, ner, höger eller vänster) varje omgång.
        //-Snake står still om spelaren är mer än 2 rutor bort, annars förflyttar den sig bort från spelaren.
        //-Varken spelare, rats eller snakes kan gå igenom väggar eller varandra.

    }
}
