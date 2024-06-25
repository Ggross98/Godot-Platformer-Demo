using Godot;
using System;

public partial class GameManager : Node
{
    public int score = 0;
    public const int MAX_COINS = 30;

    public void Restart(){
        GD.Print("Restart");

        score = 0;
    }

    public override void _Process(double delta)
    {
        if(Input.IsActionJustPressed("escape")){
            GetTree().Quit();
        }
    }
}
