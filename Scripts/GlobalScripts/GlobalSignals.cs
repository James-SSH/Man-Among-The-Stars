using Godot;
using System;

public class GlobalSignals : Node
{
    [Signal]
    delegate void WeaponFired(Bullet bullet, Vector2 position, Vector2 direction, int bulletID);
}
