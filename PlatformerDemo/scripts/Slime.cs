using Godot;
using System;

public partial class Slime : Node2D
{
	private RayCast2D rayCastLeft, rayCastRight;
	const float speed = 60f;
	private int direction = 1;


	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		rayCastLeft = GetNode<RayCast2D>("RayCastLeft");
		rayCastRight = GetNode<RayCast2D>("RayCastRight");
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		if(rayCastLeft.IsColliding()){
			// GD.Print("left collising");
			direction = 1;
		}
		if(rayCastRight.IsColliding()){
			// GD.Print("right collising");
			direction = -1;
		}
		Position += new Vector2(Convert.ToSingle(speed * direction * delta), 0);
	}
}
