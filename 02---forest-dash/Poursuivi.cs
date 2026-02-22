using System;
using Godot;
using Utils;

public partial class Poursuivi : Node2D
{
    [Export]
    public Node2D cible;

    [Export]
    private Node2D poursuivant;

    //Peut aller de 0 à 100 à coup de 1
    [Export(PropertyHint.Range, "0,1000,1,suffix:pps")]
    private float vitesseMouvement = 100.0f;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready() { }

    public override void _Draw()
    {
        // Vector2 ennemiVersChat = chat.GlobalPosition - GlobalPosition;

        // Vector2 ennemiVersChatNormalise = ennemiVersChat.Normalized(); //Pytagore
        // Vector2 ligneVersChat = ennemiVersChatNormalise * 100.0f; //Fait 1 * 100
        // DrawDashedLine(Position, Position + ligneVersChat, Colors.Blue, 5.0f);
        //DrawDashedLine(Vector2.Zero, Position + ligneVersChat, Colors.Blue, 5.0f);
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(double delta)
    {
        QueueRedraw();
    }

    public override void _PhysicsProcess(double delta)
    {
        base._PhysicsProcess(delta);
        poursuivant.EnsureValid();
        cible.EnsureValid();

        //Manière longue de calculer la direction - IMPORTANT
        //
        Vector2 distance = cible.GlobalPosition - GlobalPosition;
        Vector2 direction = distance.Normalized(); //Pytagore

        //En pratique, utilise ceci
        Vector2 altDirection = poursuivant.GlobalPosition.DirectionTo(cible.GlobalPosition);
        poursuivant.GlobalPosition -= altDirection * vitesseMouvement * (float)delta;
    }
}
