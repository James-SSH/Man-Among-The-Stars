using Godot;
using System;

public class HE_Metadata : Node
{
    private int health = 500;
    public void HandleHit()
    {
        if (health >= 0)
        {

        }
        else
        {
            GetTree().ChangeScene("res://Scene/EndScreen.tscn");
        }
    }
}
