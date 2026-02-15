using System;
using Godot;

public partial class SimplePlayer : Sprite2D
{
    private Vector2 posBiscuit = new Vector2(50, 50);
    private Vector2 currentInputVector = new(0, 0);
    private float vitesseMouvement = 100.0f;
    private bool nezAff = false;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready() { }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(double delta)
    {
        currentInputVector = Input.GetVector("ui_left", "ui_right", "ui_up", "ui_down");

        if (Input.IsActionJustPressed("ui_accept"))
        {
            nezAff = !nezAff;
        }
    }

    public override void _PhysicsProcess(double delta)
    {
        base._PhysicsProcess(delta);
        posBiscuit += currentInputVector * vitesseMouvement * (float)delta;
    }
}
