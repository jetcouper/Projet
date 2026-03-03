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

    public override void _Ready()
    {
        base._Ready();
        Vector2 oldScale = Scale;
        Scale = Vector2.Zero;
        Tween tween = CreateTween();
        tween
            .TweenProperty(this, "scale", oldScale, 0.5f)
            .SetTrans(Tween.TransitionType.Back)
            .SetEase(Tween.EaseType.Out);
    }
}
