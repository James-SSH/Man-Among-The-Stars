using Godot;
using System;

public class BulletManager : Node2D
{

    public void HandleBulletSpawned(PistolBullet bullet, Vector2 position, Vector2 direction)
    {
        AddChild(bullet);
        GD.Print("bulletSpawned");
        GD.Print(bullet, position, direction);
        this.GlobalPosition = position;
        bullet.setDirection(direction);
    }
}
