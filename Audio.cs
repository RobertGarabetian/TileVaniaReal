using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Audio : MonoBehaviour
{
    [SerializeField] AudioSource backgroundMusic;
    GameObject audio = GameObject.Find("Background Audio");
    void Awake() 
    {
        backgroundMusic.Play();
        DontDestroyOnLoad(transform.gameObject);
    }

    public void KillMusic()
    {
        Destroy(audio);
    }

    
}
