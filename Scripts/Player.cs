using Godot;
using System;

public class Player : KinematicBody2D {

    [Export]
    public int movespeed = 500;
    
    public Vector2 ScreenSize;

    public override void _Ready(){
        ScreenSize = GetViewportRect().Size;
    }

    public override void _Process(float delta){
        Vector2 velocity = Vector2.Zero;

        if (Input.IsActionPressed("MoveDown")){
            velocity.y += -1;
        } else if (Input.IsActionPressed("MoveLeft")){
            velocity.x += -1;
        } else if (Input.IsActionPressed("MoveRight")){
            velocity.x += 1;
        } else if (Input.IsActionPressed("MoveUp")){
            velocity.y += 1;
        }

        if (velocity.Length() > 0){
            velocity = velocity.Normalized() * movespeed;
            //play movement animation
        } // else stop movement
    }
   
}
