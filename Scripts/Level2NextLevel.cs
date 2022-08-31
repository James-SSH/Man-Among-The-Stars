using Godot;
using System;

public class Level2NextLevel : Area2D
{
    public void NextLevel(Node body)
    {
        if (body.IsInGroup("player"))
        {
            GetTree().ChangeScene("res://Scenes/Level2.tscn");
        }
    }
}
