using Godot;
using System;

public class PlayerWeapon : Node2D
{
    public PackedScene heldWeapon;
    private KinematicBody2D player;
    [Export] public PackedScene BulletType;
    private Position2D GunPoint;
    private Position2D GunDirection;
    private Timer cooldown;
    public Node weapon;

    [Signal] delegate void WeaponFired(PistolBullet bullet, Vector2 position, Vector2 direction);
    //private PackedScene[] AvaliableBulletTypes;


    public override void _Ready()
    {
        base._Ready();
        GunPoint = GetNode<Position2D>("PlayerGunBarrel");
        GunDirection = GetNode<Position2D>("GunDirection");
        cooldown = GetNode<Timer>("TiggerDiscipline");
        weapon = this;
        //initaliseWeapons();
    }

    private void initaliseWeapons()
    {

    }

    public void Shoot()
    {
        if (cooldown.IsStopped())
        {
            PistolBullet bulletInstance = (PistolBullet)BulletType.Instance();
            Vector2 directionToMouse = (GunDirection.GlobalPosition - GunPoint.GlobalPosition).Normalized();
            EmitSignal("WeaponFired", bulletInstance, GunPoint.GlobalPosition, directionToMouse);
            cooldown.Start();
            GD.Print("Cooldown Started");
            GD.Print(bulletInstance, GunPoint.GlobalPosition, directionToMouse);
        }
    }
}
