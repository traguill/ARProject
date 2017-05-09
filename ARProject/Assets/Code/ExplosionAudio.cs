using UnityEngine;
using System.Collections;

public class ExplosionAudio : MonoBehaviour {

    AudioSource audio_src;
    public AudioClip[] explosion;

    private void Start()
    {
        audio_src = GetComponent<AudioSource>();
    }

    public void Play()
    {
        audio_src.clip = explosion[Random.Range(0, explosion.Length)];
        audio_src.Play();
    }
}
