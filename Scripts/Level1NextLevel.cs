using Godot;
using System;

public class Level1NextLevel : CollisionShape2D
{
	public void NextLevel(Node body)
	{
		if (body.IsInGroup("player"))
		{
			GetTree().ChangeScene("res://Scenes/Level2.tscn");
		}
	}
}
