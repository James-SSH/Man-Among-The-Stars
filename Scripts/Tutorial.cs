using Godot;
using System;

public class Tutorial : Node2D {

  private Node2D bulletManager;
  private Node2D player;

  public override void _Ready() {
    base._Ready();

    bulletManager = GetNode<Node2D>("BulletManager");
    player = GetNode<Node2D>("BulletManager");
  }
}
