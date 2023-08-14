using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioButton : MonoBehaviour
{
    private static string soundEffectsPrefs = "SFX";
    private static string musicPrefs = "Music";
    private int soundValueIdx;
    public Sprite spriteOn;
    public Sprite spriteOff;

    void Start()
    {
        SetSoundPrefs();
        if (soundValueIdx == 0)
            GetComponent<Image>().sprite = spriteOff;
        else
            GetComponent<Image>().sprite = spriteOn;
    }

    public void UpdateVolume()
    {
        soundValueIdx++;
        soundValueIdx %= 2;

        if (soundValueIdx == 0)
            GetComponent<Image>().sprite = spriteOff;
        else
            GetComponent<Image>().sprite = spriteOn;

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
