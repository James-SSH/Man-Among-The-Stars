using Godot;
using System;

public class LE_AI : Node
{
    enum State
    {
        SLEEPING,
        KOd,
        SURRENDERED,
        IDLE,
        SEARCHING,
        ENGAGED
    }

    private Area2D PDZ;
    private State state = State.IDLE;

    public override void _Ready()
    {
        base._Ready();
    }
}
