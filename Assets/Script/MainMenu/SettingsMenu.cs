using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
public class SettingsMenu : MonoBehaviour
{
    public AudioMixer audiomixer;

    public void Start()
    {
        Screen.fullScreen = true;
    }

    public void SetVolume(float volume)
    {
        audiomixer.SetFloat("Music", volume); //on renvoit la valeur volume � l'audiomixer 
    }
    
    public void SetSoundVolume(float volume)
    {
        audiomixer.SetFloat("Sound", volume); //on renvoit la valeur volume � l'audiomixer 
    }

    public void SetFullScreen(bool isFullScreen)
    {
        Screen.fullScreen = isFullScreen;
    }
}
