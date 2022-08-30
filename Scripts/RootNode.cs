using Godot;
using System;

public class RootNode : Node2D
{
    public Node2D bulletmanager;
    public Node2D player;
    public Node globalSignals;

    public override void _Ready()
    {
        bulletmanager = GetNode<Node2D>("BulletManager");
        player = GetNode<Node2D>("Player");
        globalSignals = GetTree().Root.GetNode<Node>("GlobalSignals");

        globalSignals.Connect("WeaponFired", bulletmanager, "HandleBulletSpawned");

        base._Ready();
    }
}

