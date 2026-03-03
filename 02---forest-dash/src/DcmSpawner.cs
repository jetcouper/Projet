using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Godot;
using Godot.Collections;
using Utils;

public partial class DcmSpawner : Node2D
{
    [ExportGroup("External")]
    [Export]
    private PackedScene SpawneeScene;

    [Export]
    private Vector2 IntervalRange = new(1.0f, 2.0f);

    [Export]
    private MedCible MediateurCible;

    [Export]
    MedCible.EAlgoSelectionCible AlgoSelectionCible;

    [ExportGroup("Internal")]
    [Export]
    private Timer timer;

    public override void _Ready()
    {
        base._Ready();
        timer.EnsureValid().Timeout += Spawn;
    }

    public void Spawn()
    {
        SpawneeScene.EnsureValid();
        Node2D newInstance = SpawneeScene.Instantiate<Node2D>(); //Clone ta scène et fait une instance
        newInstance.EnsureValid();
        AddChild(newInstance);
        //On doit donner la cible à la souris/chien ici - à faire vendredi
        MediateurCible.EnsureValid().ChoisirCible(AlgoSelectionCible, GlobalPosition);
        timer.EnsureValid().WaitTime = GD.RandRange(IntervalRange.X, IntervalRange.Y);
    }

    public IEnumerable<Node2D> GatherChildren()
    {
        SceneState state = SpawneeScene.GetState();
        //index = 0 = noeud racine de la scène.
        StringName nodeType = state.GetNodeType(0);
        Array<Node> ret = FindChildren("*", nodeType, false, false);
        return ret.OfType<Node2D>();
    }
}
