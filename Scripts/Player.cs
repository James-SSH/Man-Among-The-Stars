using Godot;
using System;

public class Player : KinematicBody2D
{

    [Export] public int speed = 120;

    public Vector2 velocity = new Vector2();
    [Signal]
    delegate void PlayerFiredBullet(PistolBullet bullet, Vector2 position, Vector2 direction);


    public Node2D playerWeapon;

    public override void _Ready()
    {
        base._Ready();
        playerWeapon = GetNode<Node2D>("Weapon");
        playerWeapon.Connect("WeaponFired", this, "shoot");
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

    public void shoot(PistolBullet bulletinstance, Vector2 pos, Vector2 direction){
        EmitSignal("PlayerFiredBullet", bulletinstance, pos, direction);
    }

}
