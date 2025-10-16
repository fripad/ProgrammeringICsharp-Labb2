﻿namespace Labb_2;



public abstract class Enemy : LevelElement
{
    public string Name { get; set; }

    public int HP { get; set; }

    public Dice AttackDice { get; set; }

    public Dice DefenceDice { get; set; }

    public abstract void Update();
}
