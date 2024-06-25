using Godot;
using System;

public partial class Player : CharacterBody2D
{
	private AnimatedSprite2D sprite;

	public const float Speed = 180.0f;
	public const float JumpVelocity = -280.0f;

	// Get the gravity from the project settings to be synced with RigidBody nodes.
	public float gravity = ProjectSettings.GetSetting("physics/2d/default_gravity").AsSingle();
	private SFXManager sfxManager;
	private GameManager gameManager;

    public override void _Ready()
    {
        sprite = GetNode<AnimatedSprite2D>("AnimatedSprite2D");
		sprite.FlipH = false;

		sfxManager = GetNode<SFXManager>("/root/Game/SFXManager");

		gameManager = GetNode<GameManager>("/root/GameManager");
    }

    public override void _PhysicsProcess(double delta)
	{
		Vector2 velocity = Velocity;

		// Gravity
		if (!IsOnFloor())
			velocity.Y += gravity * (float)delta;

		// Jump
		if (Input.IsActionJustPressed("jump") && IsOnFloor()){
			velocity.Y = JumpVelocity;

			sfxManager.PlaySFX("Jump");
		}
			

		// Move
		float direction = Input.GetAxis("move_left", "move_right");
		if (direction != 0)
		{
			velocity.X = direction * Speed;

			if(direction < 0){
				sprite.FlipH = true;
			}
			else if(direction > 0){
				sprite.FlipH = false;
			}
		}
		else
		{
			velocity.X = Mathf.MoveToward(Velocity.X, 0, Speed);
		}

		Velocity = velocity;
		MoveAndSlide();

		// Animation
		if(!IsOnFloor()){
			sprite.Play("jump");
		}
		else{
			if(velocity.X == 0){
				sprite.Play("idle");
			}else{
				sprite.Play("run");
			}
		}
	}
}
