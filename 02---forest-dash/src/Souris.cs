using System;
using Godot;
using Utils;

public partial class Souris : Sprite2D
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
        //Scale = Vector2.Zero;
        Tween tween = CreateTween();
        tween
            .TweenProperty(this, "scale", oldScale, 0.5f)
            .SetTrans(Tween.TransitionType.Back)
            .SetEase(Tween.EaseType.Out);
    }

    private void OnTouch(Area2D InArea)
    {
        //1) Toujours tester
        //GD.Print("Toucher");

        //2) Éliminer
        //Le noeud devient invalide immédiatement

        Tween tween = CreateTween();
        tween
            .TweenProperty(this, "scale", Vector2.Zero, 0.8f)
            .SetTrans(Tween.TransitionType.Back)
            .SetEase(Tween.EaseType.Out);
        tween.SetParallel(true);
        tween
            .TweenProperty(this, "rotation", 2 * Mathf.Pi, 0.8f)
            .SetTrans(Tween.TransitionType.Back)
            .SetEase(Tween.EaseType.Out);
        tween.SetParallel(false);
        tween.Finished += QueueFree;
    }
}
