using Godot;
using System;

public class PlayerMetadata : Node
{
    [Export]
    public short health = 100;
    public short armour = 50;
    public KinematicBody2D player;

    public override void _Ready()
    {
        base._Ready();
        player = GetParent<KinematicBody2D>();
    }

    public void HandleHit()
    {
        if (armour >= 0)
        {
            armour -= 5;
        }
        else if (health >= 0)
        {
            health -= 10;
        }
        else
        {
            QueueFree();
            //GameOver();
        }
    }

}
