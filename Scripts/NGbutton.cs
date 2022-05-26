using Godot;
using System;
using SceneTree
using InputEvent

public class NGbutton : TextureButton
{
   

	// Called when the node enters the scene tree for the first time.
	public override void _Ready(){
		Texture buttonTexture = ImageTexture.new();
		Image importedImage = Image.new();
		importedImage.load("res://Textures/devOrange.png");
		buttonTexture.create_from_image(importedImage);
	}
	
	public override void onClick(InputEvent ie){
		if (InputEvent is InputEventMouseButton mouseEvent && mouseEvent.Pressed){
			if ((ButtonList)mouseEvent.ButtonIndex is Buttonlist.Left){
				GetTree().ChangeScene("res://Scenes/level1.tscn")
			}
		}
	}

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }
}
