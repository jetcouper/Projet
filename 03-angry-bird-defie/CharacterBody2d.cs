using System;
using Godot;

public partial class CharacterBody2d : CharacterBody2D
{
    private float speed = 200f;
    public float JumpVelocity = -400.0f;
    public float gravity = ProjectSettings.GetSetting("physics/2d/default_gravity").AsSingle();

    public override void _Process(double delta)
    {
        Vector2 velocity = Velocity;

        // Apply gravity if not on the floor
        if (!IsOnFloor())
        {
            // delta ensures gravity is applied consistently regardless of frame rate
            velocity.Y += gravity * (float)delta;
        }
        if (Input.IsActionPressed("ui_accept") && IsOnFloor())
            velocity.Y = JumpVelocity;

        // Handle horizontal movement
        float direction = Input.GetAxis("ui_left", "ui_right");
        velocity.X = direction * speed;

        // Apply movement and handle collisions
        Velocity = velocity;
        MoveAndSlide();
    }
}
