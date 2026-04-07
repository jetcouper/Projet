using System;
using Godot;

public partial class Graviter : Area2D
{
    public override void _Ready()
    {
        // Connecte les signaux
        BodyEntered += OnBodyEntered;
        BodyExited += OnBodyExited;
    }

    private void OnBodyEntered(Node2D body)
    {
        if (body is RigidBody2D rigidBody)
        {
            rigidBody.ConstantForce = new(0, -1500); // Applique une force vers le haut
            GD.Print($"Applied force to {rigidBody.Name}");
        }
    }

    private void OnBodyExited(Node2D body)
    {
        if (body is RigidBody2D rigidBody)
        {
            rigidBody.ConstantForce = new(0, 0); // Applique une force vers le haut
            GD.Print($"Applied force to {rigidBody.Name}");
        }
    }

    public override void _Process(double delta) { }
}
