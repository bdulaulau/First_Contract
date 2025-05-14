using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
public class SettingsMenu : MonoBehaviour
{
    public AudioMixer audiomixer;

    public void SetVolume(float volume)
    {
        audiomixer.SetFloat("volume", volume); //on renvoit la valeur volume à l'audiomixer 
    }

    public void SetFullScreen(bool isFullScreen)
    { 
        Screen.fullScreen = isFullScreen; 
    }
}
