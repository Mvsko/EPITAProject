using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class settingsMenu : MonoBehaviour
{
    public AudioMixer audioMixer;
    public void SetVolume(float volume){
        Debug.Log(volume);
        audioMixer.SetFloat("mainVol", volume);
    }

    public void SetFullScreen(bool fullScreen){
        Screen.fullScreen = fullScreen;
        Debug.Log($"Full screen is :{Screen.fullScreen}");
    }

}
