using System;
using Godot;
using Utils;

public partial class Bird : Node2D
{
    [Export]
    private RigidBody2D rigidBody;
    private float coefficient = 10f;
    private bool isShot = false;

    public override void _Ready()
    {
        base._Ready();
        if (!rigidBody.IsValid())
        {
            return;
        }
    }

    public override void _UnhandledInput(InputEvent @event)
    {
        Vector2 positionSouris = GetGlobalMousePosition();
        if (@event is InputEventMouseButton mb && mb.ButtonIndex == MouseButton.Right && mb.Pressed)
        {
            isShot = true;
            Vector2 vecteur = rigidBody.GlobalPosition - positionSouris;

            rigidBody.ApplyImpulse(vecteur * coefficient);
        }
    }

    public override void _Process(double delta)
    {
        if (isShot)
        {
            Vector2 positionSouris = GetGlobalMousePosition();
            MADebugDraw2D.Instance.DrawCircleWorld(positionSouris, 48, Colors.Red, 5.0);
            MADebugDraw2D.Instance.DrawLineWorld(
                rigidBody.GlobalPosition,
                positionSouris,
                Colors.Red,
                5.0
            );
            isShot = false;
        }
    }
}
