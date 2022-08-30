using Godot;
using System;

public class LE_Weapon : Node2D
{
    public Timer cooldown;
    [Export]
    public PackedScene pistolBullet;
    public AnimationPlayer animplayer;

    public override void _Ready()
    {
        base._Ready();
        cooldown = GetNode<Timer>("cooldown");
        animplayer = GetNode<AnimationPlayer>("AnimationPlayer");
    }

    public void Shoot(){
        if (cooldown.IsStopped()){
            PistolBullet bullet = (PistolBullet) pistolBullet.Instance();
            animplayer.Play("Muzzle Flash");
        }
    }
}
