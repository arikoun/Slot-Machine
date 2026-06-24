using System;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip[] sounds; 

    // make a singlton
    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
    }
    // playsound from audioclips sound array
    public void playsound(int index)
    {
        audioSource.PlayOneShot(sounds[index]);
    }

    //pause the sound for pause state
    public void pausesound()
    {
        audioSource.Pause();
    }
    //play the sound from where its left
    public void Resumesound()
    {
        audioSource.Play();
    }
}
