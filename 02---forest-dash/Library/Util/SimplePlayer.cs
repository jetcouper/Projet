using System;
using Godot;

public partial class SimplePlayer : Sprite2D
{
    [Export]
    private Node2D node;
    private Vector2 currentInputVector = new(0, 0);
    private float vitesseMouvement = 200.0f;
    private bool _peutBouger = false;

    [Export]
    public bool PeutBouger
    {
        get => _peutBouger;
        set
        {
            _peutBouger = value;
            UpdateVisual();
        }
    }

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        UpdateVisual();
        // Tween tw = CreateTween();
        // tw.TweenProperty(node, "position:x", node.Position.X, 3.0);
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(double delta)
    {
        if (!PeutBouger)
        {
            return;
        }
        currentInputVector = Input.GetVector("ui_left", "ui_right", "ui_up", "ui_down");
        // if (currentInputVector.Length() < 1.0f)
        // {
        //     return;
        // }
        // currentInputVector = currentInputVector.Normalized();
    }

    public override void _PhysicsProcess(double delta)
    {
        base._PhysicsProcess(delta);
        if (!PeutBouger)
        {
            return;
        }
        node.Position += currentInputVector * vitesseMouvement * (float)delta;
    }

    private void UpdateVisual()
    {
        Modulate = PeutBouger ? Colors.SkyBlue : Colors.White;
    }
}
