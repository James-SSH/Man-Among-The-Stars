using Godot;
using System;

public class RootNode : Node2D
{
    public Node2D bulletmanager;
    public Node2D player;

    public override void _Ready()
    {
        bulletmanager = GetNode<Node2D>("BulletManager");
        player = GetNode<Node2D>("Player");
        
        player.Connect("PlayerFiredBullet", bulletmanager, "HandleBulletSpawned");

        base._Ready();
    }
}

