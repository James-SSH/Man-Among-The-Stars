using Godot;
using System;

public class Quit : TextureButton
{
    
    private on_Quit_Pressed(){
        GetTree.Quit();
    }


}
