using Godot;
using System;

public class BulletManager : Node2D
{

    public void HandleBulletSpawned(PistolBullet bullet, Vector2 position, Vector2 direction)
    {
        AddChild(bullet);
        this.GlobalPosition = position;
        bullet.setDirection(direction);
    }
}
