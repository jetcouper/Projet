using System;
using Godot;

/// <summary>
/// Auteur: Antoine Dextraze
/// Date : 2026-02-10
/// Description : Les dessins.
/// </summary>
public partial class Node2d : Node2D
{
    private Vector2 posBiscuit = new Vector2(50, 50);

    [ExportGroup("PacMan")]
    [Export]
    private Vector2 posPac = new(400, 100);
    private Vector2 currentInputVector = new(0, 0);
    private float vitesseMouvement = 200.0f;
    private float frequenceFermeture = 2.0f;

    [ExportGroup("Debug")]
    [Export]
    private bool nezAff = false;

    [ExportGroup("Biscuit")]
    private float vitesseMouvementBiscuit = 100.0f;

    private float angleRadPacManAmplitude = Mathf.Pi * 0.1f;
    private float angleRadPacManAmplitudeDecalage = Mathf.Pi * 0.1f;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        GD.Print("Salut tata!");
    }

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
            new Rect2(
                new Vector2(posBiscuit.X + 80, posBiscuit.Y - 10),
                new Vector2(0 + 20, 0 + 20)
            ),
            Colors.Brown,
            true,
            -1,
            false
        );
        DrawRect(
            new Rect2(
                new Vector2(posBiscuit.X + 50, posBiscuit.Y - 5),
                new Vector2(0 + 20, 0 + 20)
            ),
            Colors.Brown,
            true,
            -1,
            false
        );
        DrawRect(
            new Rect2(
                new Vector2(posBiscuit.X - 50, posBiscuit.Y - 80),
                new Vector2(0 + 20, 0 + 20)
            ),
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
        //Vector2 posPac = new(400, 100);

        float tempsTotalMl = Time.GetTicksMsec();
        float tempsTotalSec = tempsTotalMl / 1000.0f;

        //Truc: diviser l'angle du sinus par 2 PI multiplier par une fréquence pour
        // pouvoir décider combien de cycles par secondes
        float valeurSinPacManAnimation = Mathf.Sin(
            frequenceFermeture * tempsTotalSec * (2.0f * Mathf.Pi)
        );
        float angleOuvertureAnimation =
            angleRadPacManAmplitudeDecalage + angleRadPacManAmplitude * valeurSinPacManAnimation;

        DrawArc(
            posPac,
            50,
            angleOuvertureAnimation,
            2.0f * Mathf.Pi - angleOuvertureAnimation,
            60,
            Colors.Yellow,
            100.0f
        );
        DrawCircle(posPac + new Vector2(-5, -30), 10, Colors.Black);

        float ligneDepasse = 5.0f;
        float longueurLigne = 25.0f;
        if (nezAff)
        {
            DrawLine(
                new Vector2(-ligneDepasse, 0.0f),
                new Vector2(longueurLigne, 0.0f),
                Colors.Red,
                1.0f
            );
            DrawLine(
                new Vector2(0.0f, -ligneDepasse),
                new Vector2(0.0f, longueurLigne),
                Colors.Green,
                1.0f
            );
        }
        //Vector2 longueur = posPac + posBiscuit;
        //DrawDashedLine(posPac, posBiscuit, Colors.Blue, 3.0f);

        Vector2 pacManVersBiscuit = posBiscuit - posPac;

        Vector2 pacManVersBiscuitNormalise = pacManVersBiscuit.Normalized(); //Pytagore
        Vector2 ligneVersBiscuit = pacManVersBiscuitNormalise * 100.0f; //Fait 1 * 100
        DrawDashedLine(posPac, posPac + ligneVersBiscuit, Colors.Blue, 5.0f);
    }

    public override void _Process(double delta)
    {
        base._Process(delta);
        //Rapel draw
        QueueRedraw();
        //Lecture des touches dans process (correspond à quand l'écran s'affiche)
        currentInputVector = Input.GetVector("ui_left", "ui_right", "ui_up", "ui_down");

        if (Input.IsActionJustPressed("ui_accept"))
        {
            nezAff = !nezAff;
        }
    }

    public override void _PhysicsProcess(double delta)
    {
        base._PhysicsProcess(delta);
        //On multiplie toujours les vitesses par delta qui est la durée depuis la
        // dernier appel de fonction
        posBiscuit += currentInputVector * vitesseMouvement * (float)delta;

        //Chasse sur le biscuit
        Vector2 pacManVersBiscuit = posBiscuit - posPac;
        Vector2 pacManVersBiscuitNormalise = pacManVersBiscuit.Normalized(); //Pytagore
        Vector2 ligneVersBiscuit =
            pacManVersBiscuitNormalise * vitesseMouvementBiscuit * (float)delta; //Fait 1 * 100

        posPac += ligneVersBiscuit;
    }
}
