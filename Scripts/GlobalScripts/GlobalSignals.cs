using Godot;
using System;

public class GlobalSignals : Node
{
    [Signal]
    delegate void WeaponFired(PistolBullet bullet, Vector2 position, Vector2 direction)
}
