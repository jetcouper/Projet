using System;
using Godot;
using Utils;

public partial class Chien : Sprite2D
{
    [ExportGroup("External")]
    [Export]
    public Node2D cible
    {
        get => poursuite.EnsureValid().cible;
        set { poursuite.EnsureValid().cible = value; }
    }

    [ExportGroup("Internal")]
    [Export]
    Poursuivant poursuite;
}
