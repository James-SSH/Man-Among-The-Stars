using Godot;
using System;

public class PistolBullet : Area2D
{
    [Export] public int speed = 10;
    public Vector2 direction = Vector2.Zero;
    public Timer killtimer;

    public override void _Ready()
    {
        killtimer = GetNode<Timer>("KillTimeout");
        killtimer.Start();
        base._Ready();
    }

    public override void _PhysicsProcess(float delta)
    {
        base._PhysicsProcess(delta);
        if (direction != Vector2.Zero)
        {
            Vector2 velocity = direction * speed;
            GlobalPosition += velocity;
        }
    }

    public void setDirection(Vector2 direction)
    {
        this.direction = direction;
        this.Rotation = direction.Angle();
    }

    public void _on_KillTimeout()
    {
        QueueFree();
        GD.Print("Killed bullet");
    }
}
