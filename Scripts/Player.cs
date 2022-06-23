using Godot;
using System;

public class Player : KinematicBody2D {

    [Export] public int speed = 200;

    public Vector2 velocity = new Vector2();

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

   
}
