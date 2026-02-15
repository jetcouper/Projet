using Godot;
using System;
using System.Collections.Generic;

public partial class DCM_PlayerSwitch : Node2D
{
	
	private List<SimplePlayer> players = new();
	private int currentPlayerIndex = 0;

	private Tween _tween;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		
		foreach (Node child in GetChildren())
			{				
				if (child is SimplePlayer player)
				{					
					players.Add(player);
				}
        	}
		SetActivePlayer(0);
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		base._Process(delta);
		
		if (Input.IsActionJustPressed("ui_accept"))
        {
			currentPlayerIndex++;
			if(currentPlayerIndex >= players.Count)
			{
				currentPlayerIndex = 0;
			}
			SetActivePlayer(currentPlayerIndex);
		}
	}
	private void SetActivePlayer(int index)
    {
        for (int i = 0; i < players.Count; i++)
        {
            players[i].PeutBouger = (i == index);
        }
    }
}
