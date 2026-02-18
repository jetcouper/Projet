using System;
using Godot;

public partial class EnnemiAreaDetection : Area2D
{
    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        AreaEntered += OnAreaEnteredEnnemi;
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(double delta) { }

    public void OnAreaEnteredEnnemi(Area2D InArea)
    {
        GD.Print("Je t'ai mangé");
    }
}
