using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;
    public static AudioManager instance;
    void Awake()
    {

        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);

        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();

            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }

        if (PlayerPrefs.GetInt("FirstGame") == 0)
        {
            PlayerPrefs.SetInt("Music", 1);
            PlayerPrefs.SetInt("SFX", 1);
            PlayerPrefs.SetInt("FirstGame", 1);
        }
        UpdateSoundVolumes();
    }

    public void Play(string nome)
    {
        Sound s = Array.Find(sounds, sound => sound.soundName == nome);
        if (s == null)
        {
            return;
        }
        s.source.Play();
    }

    public void Stop(string nome)
    {
        Sound s = Array.Find(sounds, sound => sound.soundName == nome);
        if (s == null)
        {
            return;
        }
        s.source.Stop();
    }

    public void UpdateSoundVolumes()
    {
        foreach (Sound s in sounds)
        {
            if (s.type == SoundType.music)
                s.source.volume = PlayerPrefs.GetInt("Music")*0.7f;
            else
                s.source.volume = PlayerPrefs.GetInt("SFX");
        }
    }

}
