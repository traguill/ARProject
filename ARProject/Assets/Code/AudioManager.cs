using UnityEngine;
using System.Collections;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour {

    public static AudioManager am;

    public AudioMixerSnapshot menu;
    public AudioMixerSnapshot game;
    

    void Awake()
    {
        am = this;
    }

    public void TransitionToGame()
    {
        game.TransitionTo(2.0f);
    }

    public void TransitionToMenu()
    {
        menu.TransitionTo(2.0f);
    }

	
}
