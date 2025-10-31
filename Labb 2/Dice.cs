namespace Labb_2;
public class Dice
{
    private int _numberOfDice;
    private int _sidesPerDice;
    private int _modifier;
    private readonly Random _random = new Random();

    public Dice(int numberOfDice, int sidesPerDice, int modifier)
    {
        _numberOfDice = numberOfDice;
        _sidesPerDice = sidesPerDice;
        _modifier = modifier;
    }

    public int Throw()
    {
        int sumOfThrow = 0;

        for (int i = 0; i < _numberOfDice; i++)
        {
            sumOfThrow += _random.Next(1, _sidesPerDice + 1);
        }

        return sumOfThrow + _modifier;
    }

    public override string ToString()
    {
        return $"{_numberOfDice}d{_sidesPerDice}+{_modifier}";
    }
}
