using Godot;
using System;

public class muzzlePos : Sprite
{
    private Sprite muzzleFlash;
    private Position2D GunBarrel;
    private KinematicBody2D player;
    public override void _Ready()
    {
        muzzleFlash = GetNode<Sprite>("muzzleFlash");
        GunBarrel = GetNode<Position2D>("PlayerGunBarrel");
        player = GetNode<KinematicBody2D>("Player");

        muzzleFlash.GlobalPosition = GunBarrel.GlobalPosition;
        muzzleFlash.Rotation = player.Rotation;
    }

}
