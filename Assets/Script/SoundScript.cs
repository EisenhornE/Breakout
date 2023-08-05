using UnityEngine.Audio;
using UnityEngine;

// I didn't really had placed enough time learning how to use this script. I just followed a tutorial on YouTube. However, I believe
// that I can use this script in the future. I just need to learn more about it. 
// This script is used so that the player can adjust volume and add a name to each sound. This is so that I can easily
// call the sound in the scripts.

[System.Serializable]
public class SoundScript
{
    public AudioClip clip;

    [Range(0f, 1f)]
    public float volume;
    [Range(.1f, 3f)]
    public float pitch;
    public string name;

    [HideInInspector]
    public AudioSource source;
}
