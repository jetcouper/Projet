using System;
using Godot;

public partial class Ennemie : Sprite2D
{
    private float vitesseMouvement = 100.0f;

    [Export]
    private Sprite2D chat;

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
        if (chat == null)
            return;

        Vector2 ennemiVersChat = chat.GlobalPosition - GlobalPosition;

        Vector2 ennemiVersChatNormalise = ennemiVersChat.Normalized(); //Pytagore
        Vector2 ligneVersChat = ennemiVersChatNormalise * vitesseMouvement * (float)delta; //Fait 1 * 100

        Position += ligneVersChat;
    }
}
