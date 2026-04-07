using System;
using Godot;

public partial class AnimatableBody2d : AnimatableBody2D
{
    public override void _Ready()
    {
        Vector2 positionDepart = GlobalPosition;
        Vector2 positionBas = positionDepart + new Vector2(0, 150);

        Tween tween = CreateTween();
        tween.SetLoops();
        tween
            .TweenProperty(this, "position", positionBas, 1.0f)
            .SetTrans(Tween.TransitionType.Sine)
            .SetEase(Tween.EaseType.InOut);
        tween
            .TweenProperty(this, "position", positionDepart, 1.0f)
            .SetTrans(Tween.TransitionType.Sine)
            .SetEase(Tween.EaseType.InOut);
    }
}
