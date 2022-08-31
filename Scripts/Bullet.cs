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
    private Sprite playerPistol;
    private Sprite playerSMG;
    private Sprite playerAR;
    private Sprite playerHyperRay;

    public override void _Ready()
    {
        killtimer = GetNode<Timer>("KillTimeout");
        killtimer.Start();
        base._Ready();
        playerPistol = GetTree().Root.GetNode<Node2D>("LevelRoot").GetNode<KinematicBody2D>("Player").GetNode<Node2D>("Weapon").GetNode<Sprite>("Pistol");
        playerSMG = GetTree().Root.GetNode<Node2D>("LevelRoot").GetNode<KinematicBody2D>("Player").GetNode<Node2D>("Weapon").GetNode<Sprite>("SMG");
        playerAR = GetTree().Root.GetNode<Node2D>("LevelRoot").GetNode<KinematicBody2D>("Player").GetNode<Node2D>("Weapon").GetNode<Sprite>("AR");
        playerHyperRay = GetTree().Root.GetNode<Node2D>("LevelRoot").GetNode<KinematicBody2D>("Player").GetNode<Node2D>("Weapon").GetNode<Sprite>("HyperRay");
        GD.Print(playerAR.Visible, playerHyperRay.Visible, playerPistol.Visible, playerSMG.Visible);
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

    public BulletIdentifier setBulletID()
    {
        if (playerPistol.Visible)
        {
            return BulletIdentifier.PISTOL;
        }
        else if (playerSMG.Visible)
        {
            return BulletIdentifier.SMG;
        }
        else if (playerAR.Visible)
        {
            return BulletIdentifier.AR;
        }
        else if (playerHyperRay.Visible)
        {
            return BulletIdentifier.HYPERRAY;
        }
        else
        {
            return BulletIdentifier.SMG;
        }
    }

    public void _on_KillTimeout()
    {
        QueueFree();
        GD.Print("Killed bullet");
    }

    public void Hit(Node body)
    {
        this.bulletID = setBulletID();
        GD.Print(bulletID);
        if (body.HasMethod("handlePistolHit") && bulletID.Equals(BulletIdentifier.PISTOL))
        {
            body.Call("handlePistolHit");
        }
        else if (body.HasMethod("handleSMGHit") && bulletID.Equals(BulletIdentifier.SMG))
        {
            body.Call("handleSMGHit");
        }
        else if (body.HasMethod("handleARHit") && bulletID.Equals(BulletIdentifier.AR))
        {
            body.Call("handleARHit");
        }
        else if (body.HasMethod("hit"))
        {
            body.Call("hit");
        }
        else
        {
            GD.Print("Invulnerable");
        }
        QueueFree();
    }
}
