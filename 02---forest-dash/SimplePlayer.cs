using System;
using Godot;

public partial class SimplePlayer : Sprite2D
{
    [Export]
    private Node2D node;
    private Vector2 currentInputVector = new(0, 0);
    private float vitesseMouvement = 100.0f;
    [Export]
    private bool _peutBouger = false;

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
        if(!PeutBouger)
        {
            return;
        }
        currentInputVector = Input.GetVector("ui_left", "ui_right", "ui_up", "ui_down");
    }

    public override void _PhysicsProcess(double delta)
    {
        if(!PeutBouger)
        {
            return;
        }
        node.Position += currentInputVector * vitesseMouvement * (float)delta;
    }
    private void UpdateVisual()
    {
        SelfModulate = PeutBouger ? new Color(0.4f, 0.7f, 1f) : Colors.White;
    }
}
