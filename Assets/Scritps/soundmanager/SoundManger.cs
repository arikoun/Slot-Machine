using System;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip[] sounds; 

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
    }

    public void playsound(int index)
    {
        audioSource.PlayOneShot(sounds[index]);
    }

}
