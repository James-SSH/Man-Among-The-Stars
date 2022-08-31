using Godot;
using System;

public class LE_Enemy : KinematicBody2D
{
    public Node2D AI;
    public Node2D Weapon;
    public Node Metadata;

    private short Health = 50;
    private KinematicBody2D EnemyLight;

    public override void _Ready()
    {
        base._Ready();
        EnemyLight = this;
        Metadata = GetNode<Node>("Metadata");
        Metadata.Call("SetParent", EnemyLight);
    }

    public void handlePistolHit()
    {
        Metadata.Call("HandleHit", 0);
    }

    public void handleSMGHit()
    {
        Metadata.Call("HandleHit", 1);
    }

    public void handleARHit()
    {
        Metadata.Call("HandleHit", 2);
    }

    public void handleHyperRayHit()
    {
        Metadata.Call("HandleHit", 3);
    }

    public void DropLE()
    {

    }
}
