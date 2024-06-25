using Godot;
using System;

public partial class Killzone : Area2D
{

	private Timer respawnTimer;
	private SFXManager sfxManager;
	private GameManager gameManager;

    public override void _Ready()
    {
        respawnTimer = GetNode<Timer>("RespawnTimer");
		sfxManager = GetNode<SFXManager>("/root/Game/SFXManager");
		gameManager = GetNode<GameManager>("/root/GameManager");
    }

    public void OnBodyEntered(Node2D body){
		if(body.GetType() == typeof(Player)){


			GD.Print("You died!");
			sfxManager.PlaySFX("Hurt");
			body.GetNode<CollisionShape2D>("CollisionShape2D").QueueFree();

			// GD.Print(respawnTimer);
			gameManager.Restart();
			respawnTimer.Start();
			// OnRespawnTimeout();
		}
	}

	public void OnRespawnTimeout(){
		GD.Print("Reload scene");
		GetTree().ReloadCurrentScene();
	}
}
