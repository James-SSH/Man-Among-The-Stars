using Godot;
using System;

public class NewGame : TextureButton
{

    private void _on_New_Game_pressed()
    {
        GetTree().ChangeScene("res://Scenes/Level1.tscn");
    }
}
