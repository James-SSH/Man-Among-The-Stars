using Godot;
using System;

public class Level3NextLevel : Area2D
{
    public void NextLevel(Node body)
    {
        if (body.IsInGroup("player"))
        {
            GetTree().ChangeScene("res://Scenes/FinalLevel.tscn");
        }
    }
}
