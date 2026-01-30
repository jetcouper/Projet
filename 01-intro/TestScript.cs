using Godot;
using System;

public partial class TestScript : Node2D
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		GD.Print("Putin tu va ma rendre fou");
	}
    public override void _Draw()
    {
		float hauteuryeux = -50.0f;
		float largeuryeux = 30.0f;

		Vector2 eyePositionRight = new Vector2(largeuryeux,hauteuryeux);
		Vector2 eyePositionLeft = new Vector2(-largeuryeux,hauteuryeux);
        DrawCircle(eyePositionRight,20,Colors.Red);
        DrawCircle(eyePositionLeft,20,Colors.Red);
		
		//Nez
		float ligneDepasse = 5.0f;
		float longueurLigne = 25.0f;

		DrawLine(new Vector2(-ligneDepasse, 0.0f), new Vector2(longueurLigne, 0.0f), Colors.Red, 1.0f);
		DrawLine(new Vector2(0.0f,-ligneDepasse), new Vector2(0.0f,longueurLigne), Colors.Green, 1.0f);

		//Bouche
		DrawArc(new Vector2(0,0),100,Mathf.Pi*0.25f,Mathf.Pi*0.75f,10,Colors.Blue,10.0f);

    }


	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		
	}
}
