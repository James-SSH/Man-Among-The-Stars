using Godot;
using System;

public class HE_AI : Node2D
{
    public enum State
    {
        SLEEPING,
        KOd,
        SURRENDERED,
        IDLE,
        SEARCHING,
        ENGAGED
    }

    private Area2D PDZ;
    private State currentstate = State.IDLE;
    [Signal] delegate void StateChanged(State state);
    public AnimatedSprite anim;
    public Node2D weapon;
    private KinematicBody2D player = null;
    public Sprite gun;
    public KinematicBody2D enemy;

    public override void _Ready()
    {
        base._Ready();
        anim = GetParent().GetNode<AnimatedSprite>("HE_Sprite");
        weapon = GetParent().GetNode<Node2D>("Weapon");
        gun = weapon.GetNode<Sprite>("Gun");
        enemy = GetParent<KinematicBody2D>();
        player = GetTree().Root.GetNode<Node2D>("LevelRoot").GetNode<KinematicBody2D>("Player");
    }

    public override void _Process(float delta)
    {
        base._Process(delta);
        switch (currentstate)
        {
            case State.SLEEPING:
                break;
            case State.KOd:
                break;
            case State.SURRENDERED:
                break;
            case State.IDLE:
                break;
            case State.SEARCHING:
                break;
            case State.ENGAGED:
                weapon.Call("Shoot");
                gun.Show();
                enemy.Rotation = enemy.GlobalPosition.DirectionTo(player.GlobalPosition).Angle();
                break;
        }
    }

    public void setState(State Invokedstate)
    {
        if (Invokedstate == currentstate)
        {

        }
        else
        {
            currentstate = Invokedstate;
            EmitSignal("StateChanged", currentstate);
        }
    }

    public void PlayerDetected(Node body)
    {
        if (body.IsInGroup("player"))
        {
            setState(State.ENGAGED);
        }
    }

    public void ISurrender(Node body)
    {
        if (body.IsInGroup("player"))
        {
            setState(State.SURRENDERED);
        }
    }
}
