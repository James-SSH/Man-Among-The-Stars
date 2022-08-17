using Godot;
using System;

public class TutorialRoot : Node2D
{
    public Node2D bulletmanager;
    public Node2D player;

    public override void _Ready()
    {
        bulletmanager = GetNode<Node2D>("BulletManager");
        player = GetNode<Node2D>("BulletManager");

        base._Ready();
    }
}

