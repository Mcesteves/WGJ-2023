using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SoundType
{
    sfx,
    music
}

[System.Serializable]
public class Sound
{
    public string soundName;

    public AudioClip clip;

    public SoundType type;

    [Range(0f, 1f)]
    public float volume = .75f;
    [Range(0f, 1f)]
    public float volumeVariance = .1f;

    [Range(.1f, 3f)]
    public float pitch = 1f;
    [Range(0f, 1f)]
    public float pitchVariance = .1f;

    public bool loop = false;

    [HideInInspector]
    public AudioSource source;
}
