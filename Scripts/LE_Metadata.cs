using Godot;
using System;

public class LE_Metadata : Node
{
    [Export]
    private short Health;
    private KinematicBody2D EnemyLight;

    public override void _Ready()
    {
        base._Ready();
        EnemyLight = GetNode<KinematicBody2D>("EnemyLight");
    }
}
