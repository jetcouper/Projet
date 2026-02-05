using System;
using Godot;

public partial class Node2d : Node2D
{
    private Vector2 posBiscuit = new Vector2(0 + 50, 0 + 50);
    private bool boucheDoitOuvrir = true;
    private float bouche = Mathf.Pi / 4f;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready() { }

    public override void _Draw()
    {
        //Font
        Vector2 screenSize = GetViewportRect().Size;
        DrawRect(
            new Rect2(new Vector2(0 - screenSize.X / 2, 0 - screenSize.Y / 2), screenSize),
            Colors.Red,
            true,
            -1,
            false
        );

        //Biscuit

        DrawCircle(posBiscuit, 100.0f, Colors.Chocolate, true, -1, false);
        DrawRect(
            new Rect2(new Vector2(posBiscuit.X + 20, 0 + 20), new Vector2(0 + 20, 0 + 20)),
            Colors.Brown,
            true,
            -1,
            false
        );
        DrawRect(
            new Rect2(new Vector2(posBiscuit.X + 70, 0 + 70), new Vector2(0 + 20, 0 + 20)),
            Colors.Brown,
            true,
            -1,
            false
        );
        DrawRect(
            new Rect2(new Vector2(posBiscuit.X + 20, 0 + 65), new Vector2(0 + 20, 0 + 20)),
            Colors.Brown,
            true,
            -1,
            false
        );

        //Biscuit version prof
        // Vector2 posBiscuitB = new(150, 150);
        // Vector2 posPepitteA = new Vector2(160, 100);
        // Vector2 posPepitteB = new Vector2(160, 120);
        // Vector2 posPepitteC = new Vector2(140, 120);
        // DrawCircle(posBiscuitB, 100, Colors.Brown, true);
        // DrawCircle(posPepitteA, 10, Colors.Black, true);
        // DrawCircle(posPepitteB, 10, Colors.Black, true);
        // DrawCircle(posPepitteC, 10, Colors.Black, true);

        //Pacman
        Vector2 posPac = new(400, 100);

        if (boucheDoitOuvrir)
        {
            bouche += 0.05f;
            if (bouche >= Mathf.Pi / 2f)
            {
                boucheDoitOuvrir = false;
            }
        }
        else
        {
            bouche -= 0.05f;
            if (bouche <= 0f)
            {
                boucheDoitOuvrir = true;
            }
        }
        float debutAngle = bouche / 2f;
        float finAngle = 2 * Mathf.Pi - debutAngle;

        DrawArc(posPac, 50, debutAngle, finAngle, 60, Colors.Yellow, 100.0f);
        DrawCircle(posPac + new Vector2(15, -30), 5, Colors.Black);
    }

    public override void _Process(double delta)
    {
        base._Process(delta);
        //Rapel draw
        QueueRedraw();
    }

    public override void _PhysicsProcess(double delta)
    {
        base._PhysicsProcess(delta);
        posBiscuit.X += 1;
    }
}
