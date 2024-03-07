using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SettingsMenu : MonoBehaviour
{

    public AudioMixer audioMixer1;
    

    public void SetVolume(float volume)
    {
        audioMixer1.SetFloat("volume", volume);
    }



    
}
