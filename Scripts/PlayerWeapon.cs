using Godot;
using System;

public class Weapon : Node
{
    public PackedScene heldWeapon;
    private KinematicBody2D player;
    private Godot.Collections.Dictionary<String, Vector2> WeaponPos;
    private Godot.Collections.Dictionary<String, int> Refire;
    private Godot.Collections.Dictionary<String, PackedScene> GunModels;
    [Export] public PackedScene BulletType;
    private Position2D GunPoint;
    private Position2D GunDirection;
    private Timer cooldown;

    [Signal] delegate void PlayerFiredBullet(PistolBullet bullet, Vector2 position, Vector2 direction);
    //private PackedScene[] AvaliableBulletTypes;


    public override void _Ready()
    {
        base._Ready();
        player = GetNode<KinematicBody2D>("Player");
        GunPoint = GetNode<Position2D>("PlayerGunBarrel");
        GunDirection = GetNode<Position2D>("GunDirection");
        cooldown = GetNode<Timer>("TiggerDiscipline");
        initaliseWeapons();
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
            EmitSignal("PlayerFiredBullet", bulletInstance, GunPoint.GlobalPosition, directionToMouse);
            cooldown.Start();
            GD.Print("Cooldown Started");
            GD.Print(cooldown);
        }
    }
}
