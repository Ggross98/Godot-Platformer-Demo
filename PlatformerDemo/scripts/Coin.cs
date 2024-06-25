using Godot;
using System;

public partial class Coin : Area2D
{

	private SFXManager sfxManager;
	private GameManager gameManager;

    public override void _Ready()
    {
        sfxManager = GetNode<SFXManager>("/root/Game/SFXManager");
		gameManager = GetNode<GameManager>("/root/GameManager");
    }

    public void OnBodyEntered(Node2D body){
		// GD.Print(body.GetType());
		// GD.Print(typeof(Player));
		if(body.GetType() == typeof(Player)){
			
			sfxManager.PlaySFX("Coin");
			gameManager.score += 1;

			QueueFree();
		}
	}
}
