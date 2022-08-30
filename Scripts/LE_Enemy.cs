using Godot;
using System;

public class LE_Enemy : KinematicBody2D
{
    public Node2D AI;
    public Node2D Weapon;
    public Node Metadata;

    public override void _Ready()
    {
        base._Ready();
        //AI = GetNode<Node2D>("AI");
        //Weapon = GetNode<Node2D>("Weapon");
        //Metadata = GetNode<Node>("Metadata");
    }
}
