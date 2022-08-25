using Godot;
using System;

public class Player : KinematicBody2D
{

    [Export] public int speed = 120;
    [Export] public PackedScene BulletType;
    private Position2D GunPoint;
    private Position2D GunDirection;
    private Timer cooldown;

    [Signal] delegate void PlayerFiredBullet(PistolBullet bullet, Vector2 position, Vector2 direction);
    //private PackedScene[] AvaliableBulletTypes;

    public Vector2 velocity = new Vector2();

    public override void _Ready()
    {
        base._Ready();
        GunPoint = GetNode<Position2D>("PlayerGunBarrel");
        GunDirection = GetNode<Position2D>("GunDirection");
        cooldown = GetNode<Timer>("TiggerDiscipline");
    }

    public void GetInput()
    {
        LookAt(GetGlobalMousePosition());
        velocity = new Vector2();

        if (Input.IsActionPressed("MoveRight"))
            velocity.x += 1;

        if (Input.IsActionPressed("MoveLeft"))
            velocity.x -= 1;

        if (Input.IsActionPressed("MoveDown"))
            velocity.y += 1;

        if (Input.IsActionPressed("MoveUp"))
            velocity.y -= 1;

        velocity = velocity.Normalized() * speed;
    }

    public override void _PhysicsProcess(float delta)
    {
        GetInput();
        velocity = MoveAndSlide(velocity);
    }

    public override void _UnhandledInput(InputEvent @event)
    {
        if (@event.IsActionPressed("Shoot"))
        {
            Shoot();
        }
    }

    private void Shoot()
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
