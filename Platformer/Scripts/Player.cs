using Godot;
using System;

public partial class Player : CharacterBody2D
{
	[ExportGroup("Variables")]
	[Export]
	public float Speed = 300.0f;
	[Export]
	public float JumpVelocity = 400.0f;
	[Export]
	public AnimatedSprite2D AnimatedSprite;
	// Get the gravity from the project settings to be synced with RigidBody nodes.
	public float gravity = ProjectSettings.GetSetting("physics/2d/default_gravity").AsSingle();

	public override void _PhysicsProcess(double delta)
	{
		Vector2 velocity = Velocity;

		// Add the gravity.
		if (!IsOnFloor()){
			velocity.Y += gravity * (float)delta;
			AnimatedSprite.Play("jump");
		}
		// Handle Jump.
		if (Input.IsActionJustPressed("Jump") && IsOnFloor()){
			velocity.Y -= JumpVelocity;			
		}
		// Get the input direction and handle the movement/deceleration.
		// As good practice, you should replace UI actions with custom gameplay actions.
		Vector2 direction = Input.GetVector("Left", "Right", "ui_up", "ui_down");
		if (direction != Vector2.Zero)
		{
			velocity.X = direction.X * Speed;
			AnimatedSprite.Play("run");
			//We use ternary operator to check where the player should be turned towards
			AnimatedSprite.FlipH = direction.X<=0?true:false;
		}
		else
		{
			AnimatedSprite.Play("idle");
			velocity.X = Mathf.MoveToward(Velocity.X, 0, Speed);
		}

		Velocity = velocity;
		MoveAndSlide();
	}
}
