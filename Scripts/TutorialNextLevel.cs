using Godot;
using System;

public class TutorialNextLevel : CollisionShape2D
{
    public void NextLevel(Node body)
    {
        if (body.IsInGroup("player"))
        {
            GetTree().ChangeScene("res://Scene/Level1.tscn");
        }
    }
}
