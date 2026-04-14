using System;
using Godot;

public partial class AnimatableBody2d : AnimatableBody2D
{
    public override void _Ready()
    {
        Tween tween = CreateTween();
        tween.SetLoops();
        tween
            .TweenProperty(this, "rotation", Mathf.Tau, 1.0f)
            .SetTrans(Tween.TransitionType.Linear);
    }
}
