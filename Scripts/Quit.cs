using Godot;
using System;

public class Quit : TextureButton
{
    //TODO: Fix exit button
    private void on_Quit_pressed(){
        GetTree.Quit();
    }


}
