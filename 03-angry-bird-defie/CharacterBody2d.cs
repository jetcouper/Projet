using System;
using Godot;

public partial class CharacterBody2d : CharacterBody2D
{
    private float speed = 200f;
    public float JumpVelocity = -400.0f;
    public float gravity = ProjectSettings.GetSetting("physics/2d/default_gravity").AsSingle();

    private bool etaitSurSol = false;
    private bool peutSauter = false;
    private Timer jumpTimer = new Timer();

    public override void _Ready()
    {
        base._Ready();
        GetTree().DebugCollisionsHint = true;
        AddChild(jumpTimer);
        jumpTimer.OneShot = true;
    }

    public override void _PhysicsProcess(double delta)
    {
        Vector2 velocity = Velocity;

        bool EstSurSol = IsOnFloor();

        if (!etaitSurSol && EstSurSol)
        {
            peutSauter = false;
            jumpTimer.Stop();
        }

        bool isPressingJumping = Input.IsActionJustPressed("ui_accept");

        // Apply gravity if not on the floor
        if (isPressingJumping && (EstSurSol || (peutSauter && !jumpTimer.IsStopped())))
        {
            velocity.Y = JumpVelocity;
            peutSauter = false;
            jumpTimer.Stop();
        }

        if (!EstSurSol)
            velocity.Y += gravity * (float)delta;

        //Saut de coyote
        if (etaitSurSol && !EstSurSol && velocity.Y >= 0)
        {
            jumpTimer.WaitTime = 0.5f;
            jumpTimer.Start();
            peutSauter = true;
        }
        // Handle horizontal movement
        float direction = Input.GetAxis("ui_left", "ui_right");
        velocity.X = direction * speed;

        // Apply movement and handle collisions
        Velocity = velocity;
        MoveAndSlide();

        etaitSurSol = EstSurSol;
    }
}
