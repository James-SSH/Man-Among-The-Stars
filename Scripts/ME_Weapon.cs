using Godot;
using System;

public class ME_Weapon : Node2D
{
    public Timer cooldown;
    [Export]
    public PackedScene Bullet;
    public AnimationPlayer animplayer;
    public Node globalSignals;
    public KinematicBody2D player;
    public Position2D GunPoint;
    public Position2D Gunbarrel;
    public KinematicBody2D Enemy;

    public override void _Ready()
    {
        base._Ready();
        cooldown = GetNode<Timer>("cooldown");
        animplayer = GetNode<AnimationPlayer>("AnimationPlayer");
        globalSignals = GetTree().Root.GetNode<Node2D>("LevelRoot").GetNode<KinematicBody2D>("Player");
        GunPoint = GetNode<Position2D>("GunBarrel");
        Gunbarrel = GetNode<Position2D>("GunDirection");
        Enemy = GetParent<KinematicBody2D>();
        cooldown.WaitTime = 0.125f;
    }

    public void Shoot()
    {
        if (cooldown.IsStopped())
        {
            Bullet bullet = (Bullet)Bullet.Instance();
            animplayer.Play("Muzzle Flash");
            globalSignals.EmitSignal("WeaponFired", GunPoint.GlobalPosition, Enemy.Position.DirectionTo(player.GlobalPosition));
            cooldown.Start();
        }
    }
}
