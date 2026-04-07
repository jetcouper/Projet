using System;
using Godot;

public partial class Bird : RigidBody2D
{
    private float coefficient = 10f;
    private bool isShot = false;

    public override void _UnhandledInput(InputEvent @event)
    {
        Vector2 positionSouris = GetGlobalMousePosition();
        if (@event is InputEventMouseButton mb && mb.ButtonIndex == MouseButton.Right && mb.Pressed)
        {
            isShot = true;
            Vector2 vecteur = GlobalPosition - positionSouris;

            ApplyImpulse(vecteur * coefficient);
        }
    }

    public override void _Process(double delta)
    {
        if (isShot)
        {
            Vector2 positionSouris = GetGlobalMousePosition();
            MADebugDraw2D.Instance.DrawCircleWorld(positionSouris, 48, Colors.Red, 5.0);
            MADebugDraw2D.Instance.DrawLineWorld(GlobalPosition, positionSouris, Colors.Red, 5.0);
            isShot = false;
        }
    }
}
