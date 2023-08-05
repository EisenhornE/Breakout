using UnityEngine.Audio;
using System;
using UnityEngine;

// As what I have wrote in SoundScript, I didn't really put enough time learning how to use this script. 
// I just followed a tutorial on YouTube. I can understand how they work but I need more scenarios on how to use it as this
// is my first time (second if you count the Unity Tutorial) in my own project.

public class AudioManager : MonoBehaviour
{

    public SoundScript[] sounds;

    // If I remember correctly, the codes inside the Awake() function is to create an array of AudioSources. Using s as a 
    // variable. Since the Soundscript is public, I can just drag the Audio clip inside the Unity Editor.

    void Awake()
    {
        foreach (SoundScript s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
        }
    }

    public void Play(string name)
    {
        SoundScript s = Array.Find(sounds, SoundScript => SoundScript.name == name);
        s.source.Play();
    }
}
