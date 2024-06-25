using Godot;
using System;
using System.Collections.Generic;

public partial class SFXManager : Node
{   
    [Export] AudioStream[] audios;
    Dictionary<string, AudioStream> audioDict;

    public override void _Ready()
    {
        // coin = GetNode<AudioStreamPlayer>("Coin");
        // jump = GetNode<AudioStreamPlayer>("Jump");
        // hurt = GetNode<AudioStreamPlayer>("Hurt");

        audioDict = new Dictionary<string, AudioStream>(){
            {"Coin", audios[0]},
            {"Jump", audios[1]},
            {"Hurt", audios[2]},
        };

    }

    public void PlaySFX(string name){
        if(audioDict.ContainsKey(name)){

            var sfxPlayer = new AudioStreamPlayer();
            AddChild(sfxPlayer);
            
            sfxPlayer.Stream = audioDict[name];
            sfxPlayer.Play();
        }
    }
}
