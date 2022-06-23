using Godot;
using System;

public class Save_1 : TextureButton {

    private void _on_Save_1_pressed(){
        GetTree().ChangeScene("res://Scenes/Tutorial.tscn");
    }
    
}
