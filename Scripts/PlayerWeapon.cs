using Godot;
using System;

public class Weapon : Node
{
    public PackedScene heldWeapon;
    private KinematicBody2D player;
    private Godot.Collections.Dictionary<String, Vector2> WeaponPos;
    private Godot.Collections.Dictionary<String, int> Refire;
    private Godot.Collections.Dictionary<String, PackedScene> GunModels;


    public override void _Ready()
    {
        base._Ready();
        player = GetNode<KinematicBody2D>("Player");
        initaliseWeapons();
    }

    private void initaliseWeapons(){

    }
}
