using System;
using TMPro;
using UnityEngine;

// Mercy System:
// If the player repeatedly fails to get matching images, they may become frustrated.
// To improve the experience, I implemented a mercy system. After a certain number
// of consecutive failed attempts, the player is guaranteed to receive matching
// images on the next spin. This guarantee is applied only once, after which the
// system resets.

public class Score_manager : MonoBehaviour
{
    Reel reel;

    // after how many failed attempt should the player be given the guarantee to win
    [SerializeField] int mercy;
    // store failed attempts
    [SerializeField] int failed_attempts = 0;
    [SerializeField] int score;
    [SerializeField] TextMeshProUGUI scoretxt;

    [SerializeField] ParticleSystem[] celebrate_vfx;

    void Start()
    {
        reel = GetComponent<Reel>();
    }

    void Update()
    {
        // if the failed attempts exceeds the mercy value. then give a guarantee win chance
        if (failed_attempts > mercy)
        {
            // and reset it
            reel.matchChance = 1;
            failed_attempts = 0;
        }
    }
    // check the score
    public void setscore(int num1, int num2, int num3)
    {
        // if won, check the image on the front
        // give score accourdingly
        if (num1 == num2 && num2 == num3)
        {   
            SoundManager.Instance.playsound(4);
            SoundManager.Instance.playsound(5);

            switch(num1)
            {
                case 0 :// seven
                    
                    score += 1000;
                    scoretxt.text = score.ToString(); 

                break;

                case 1 ://cherry
                    
                    score += 100;
                    scoretxt.text = score.ToString(); 

                break;

                case 2 ://bell
                    
                    score += 200;
                    scoretxt.text = score.ToString(); 

                break;
                
                case 3 ://bar
                    
                    score += 500;
                    scoretxt.text = score.ToString(); 

                break;
            }

            // particle system
            Celebrate(num1);
        }
        else
        {
            // store failed attempts
            failed_attempts++;
            SoundManager.Instance.playsound(6);
        }

    }

    void Celebrate(int combination)
    {
        if (combination > 0)
        {
            //small particle for small wins
            celebrate_vfx[0].Play();
            celebrate_vfx[1].Play(); 
        }
        else
        {
            //large particles for jackpot
            foreach (var vfx in celebrate_vfx)
            {
                vfx.Play();
            }
        }
    }
}
