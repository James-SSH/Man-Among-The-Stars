using Godot;
using System;

public class LE_Metadata : Node
{
	private short Health = 50;
	private KinematicBody2D EnemyLight;

	public override void _Ready()
	{
		base._Ready();
		EnemyLight = GetParent<KinematicBody2D>();
	}

	public void handlePistolHit() {
		Health -= 10;
		if (Health <= 0){
			DropLE();
			EnemyLight.QueueFree();
		}
	}

	public void handleSMGHit(){
		Health -= 5;
		if (Health <= 0){
			DropLE();
			EnemyLight.QueueFree();
		}
	}

	public void handleARHit(){
		Health -= 15;
		if (Health <= 0){
			DropLE();
			EnemyLight.QueueFree();
		}
	}

	public void handleHyperRayHit(){
		DropLE();
		EnemyLight.QueueFree();
	}

	public void DropLE(){

	}

}
