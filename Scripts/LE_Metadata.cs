using Godot;
using System;

public class LE_Metadata : Node
{
    public short Health = 50;
    public KinematicBody2D Enemy;

    public override void _Ready()
    {
        base._Ready();

    }

    public void SetParent(KinematicBody2D enemy)
    {
        Enemy = enemy;
    }

    public void HandleHit(int bulletID)
    {
        if (Health >= 0)
        {
            switch (bulletID)
            {
                case 0:
                    Health -= 10;
                    break;
                case 1:
                    Health -= 5;
                    break;
                case 2:
                    Health -= 15;
                    break;
                case 3:
                    Enemy.QueueFree();
                    break;
            }
        }
        else
        {
            Enemy.QueueFree();
        }
    }
}
