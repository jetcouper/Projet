using System;
using Godot;

public partial class Niveau : Node2D
{
    public override void _Ready()
    {
        MADebugDraw2D.Instance.DrawCircleWorld(new Vector2(100, 100), 48, Colors.Red, 10.0);
    }
}
