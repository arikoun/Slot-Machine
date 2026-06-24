using System;
using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class UI_manager : MonoBehaviour
{
    [Header("Refrences")]
    [SerializeField] GameObject startpopup;
    [SerializeField] GameObject[] gamecomponents;
    [SerializeField] GameObject Pausescreen;

    [SerializeField] bool pause = false;

    void Start()
    {
        startpopup.SetActive(true);
    }

    public void Play()
    {
        SoundManager.Instance.playsound(2);
        startpopup.SetActive(false);

        foreach (GameObject gameObject in gamecomponents)
        {
            gameObject.SetActive(true);
        }
        
    }

    public void Exite()
    {
        SoundManager.Instance.playsound(2);
        Application.Quit();
    }

    public void Pause()
    {
        if (!pause)
        {
            SoundManager.Instance.playsound(2);
            Pausescreen.SetActive(true);
            Time.timeScale = 0;
            pause = true;
        }
    }

    public void Resume()
    {
        if (pause)
        {
            SoundManager.Instance.playsound(2);
            Pausescreen.SetActive(false);
            Time.timeScale = 1;
            pause = false;
        }
    }
}
