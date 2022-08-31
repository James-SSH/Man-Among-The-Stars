using Godot;
using System;

public class BulletManager : Node2D
{

    public void HandleBulletSpawned(Bullet bullet, Vector2 position, Vector2 direction)
    {
        AddChild(bullet);
        GD.Print("bulletSpawned");
        this.GlobalPosition = position;
        bullet.setDirection(direction);
    }
}
