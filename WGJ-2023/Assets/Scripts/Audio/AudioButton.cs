using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioButton : MonoBehaviour
{
    private static string soundEffectsPrefs = "SFX";
    private static string musicPrefs = "Music";
    private int soundValueIdx;

    void Start()
    {
        SetSoundPrefs();
    }

    public void UpdateVolume()
    {
        soundValueIdx++;
        soundValueIdx %= 2;

        if (gameObject.tag == "Music")
            PlayerPrefs.SetInt(musicPrefs, soundValueIdx);
        else
            PlayerPrefs.SetInt(soundEffectsPrefs, soundValueIdx);

        AudioManager.instance.UpdateSoundVolumes();
    }

    private void SetSoundPrefs()
    {
        if (gameObject.tag == "Music")
            soundValueIdx = PlayerPrefs.GetInt(musicPrefs);
        else
            soundValueIdx = PlayerPrefs.GetInt(soundEffectsPrefs);
    }
}
