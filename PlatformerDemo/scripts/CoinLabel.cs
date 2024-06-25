using Godot;
using System;

public partial class CoinLabel : Label
{   
    private GameManager gameManager;

    public override void _Ready()
    {
		gameManager = GetNode<GameManager>("/root/GameManager");
    }

    public override void _Process(double delta)
    {
        Text = string.Format("You got {0:D2}/{1:D2} coins!", gameManager.score, GameManager.MAX_COINS);
    }
}
