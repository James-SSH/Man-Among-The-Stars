using Godot;
using System;

public class PistolBullet : Node2D {
  [Export] public int speed = 150;
  public Vector2 direction = Vector2.Zero;

  public override void _PhysicsProcess(float delta) {
    base._PhysicsProcess(delta);
    if (direction != Vector2.Zero) {
      Vector2 velocity = direction * speed;
      GlobalPosition += velocity;
    }
  }

  public void setDirection(Vector2 direction) {
    this.direction = direction;
  }
}
