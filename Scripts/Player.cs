using Godot;
using System;

public class Player : KinematicBody2D
{

    [Export] public int speed = 120;

    public Vector2 velocity = new Vector2();
    [Signal]
    delegate void PlayerFiredBullet(PistolBullet bullet, Vector2 position, Vector2 direction);


    private Node playerWeapon;

    public override void _Ready()
    {
        base._Ready();
        playerWeapon = GetNode<Node>("Weapon");
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
            playerWeapon.Call("Shoot");
        }
    }

    public void HandleBulletSpawned(PistolBullet bulletInstance, Vector2 GunPoint, Vector2 directionToMouse)
    {
        EmitSignal("HandleBulletSpawned", bulletInstance, GunPoint, directionToMouse);
    }

}
