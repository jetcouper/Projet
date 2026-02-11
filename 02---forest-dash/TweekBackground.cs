using System;
using Godot;

public partial class TweekBackground : Node2D
{
    [Export]
    private Node2D node;

    [Export]
    private float amplitudeX = 200f;

    [Export]
    private float amplitudeY = 100f;

    [Export]
    private float duration = 4f;
    private Vector2 center;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        center = node.GlobalPosition;
        Tween tw = CreateTween();
        tw.SetLoops();

        tw.TweenMethod(Callable.From<float>(UpdatePosition), 0f, 2 * Mathf.Pi, duration);
    }

    private void UpdatePosition(float t)
    {
        float x = Mathf.Sin(t) * amplitudeX;
        float y = Mathf.Sin(t * 2.0f) * amplitudeY;

        node.GlobalPosition = center + new Vector2(x, y);
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(double delta) { }
}
