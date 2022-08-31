using Godot;
using System;

public class PlayerWeapon : Node2D
{

    public enum BulletIdentifier
    {
        PISTOL,
        SMG,
        AR,
        HYPERRAY
    }

    public PackedScene heldWeapon;
    private KinematicBody2D player;
    [Export] public PackedScene BulletType;
    private Position2D GunPoint;
    private Position2D GunDirection;
    private String[] gunNames = { "Pistol", "SMG", "AR", "HyperRay" };
    private Sprite[] guns;
    private Timer cooldown;
    public Node weapon;
    public Node globalSignals;
    public BulletIdentifier BulletID;


    public override void _Ready()
    {
        base._Ready();
        GunPoint = GetNode<Position2D>("PlayerGunBarrel");
        GunDirection = GetNode<Position2D>("GunDirection");
        cooldown = GetNode<Timer>("TiggerDiscipline");
        weapon = this;
        globalSignals = GetTree().Root.GetNode<Node>("GlobalSignals");
        // for (int i = 0; i < gunNames.GetLength(4); i++)
        // {
        //     guns[i] = GetNode<Sprite>(gunNames[i]);
        //     if (guns[i].Visible && guns[i] != null)
        //     {
        //         BulletID = (BulletIdentifier)i;
        //     }
        // }
    }

    private void initaliseWeapons()
    {

    }

    public void Shoot()
    {
        if (cooldown.IsStopped())
        {
            Bullet bulletInstance = (Bullet)BulletType.Instance();
            Vector2 directionToMouse = (GunDirection.GlobalPosition - GunPoint.GlobalPosition).Normalized();
            globalSignals.EmitSignal("WeaponFired", bulletInstance, GunPoint.GlobalPosition, directionToMouse);
            cooldown.Start();
            GD.Print("Cooldown Started");
        }
    }
}
