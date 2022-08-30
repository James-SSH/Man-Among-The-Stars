using Godot;
using System;

public class Bullet : Area2D
{
    public enum BulletIdentifier
    {
        PISTOL,
        SMG,
        AR,
        HYPERRAY
    }

    [Export] public int speed = 10;
    public Vector2 direction = Vector2.Zero;
    public Timer killtimer;
    public BulletIdentifier bulletID;

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

    public void setBulletID(int BulletId)
    {
        this.bulletID = (BulletIdentifier)BulletId;
    }

    public void _on_KillTimeout()
    {
        QueueFree();
        GD.Print("Killed bullet");
    }

    public void Hit(Node body, BulletIdentifier BulletID)
    {
        if (body.HasMethod("handlePistolHit") && BulletID.Equals(BulletIdentifier.PISTOL))
        {
            body.Call("handlePistolHit");
        }
        else if (body.HasMethod("handleSMGHit") && BulletID.Equals(BulletIdentifier.SMG))
        {
            body.Call("handleSMGHit");
        }
        else if (body.HasMethod("handleARHit") && BulletID.Equals(BulletIdentifier.AR))
        {
            body.Call("handleARHit");
        }
        else if (body.HasMethod("hit"))
        {
            body.Call("hit");
        }
    }
}
