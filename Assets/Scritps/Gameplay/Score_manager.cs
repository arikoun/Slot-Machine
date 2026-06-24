using System;
using TMPro;
using UnityEngine;

public class Score_manager : MonoBehaviour
{
    Reel reel;

    [SerializeField] int mercy;
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
        if (failed_attempts > mercy)
        {
            reel.matchChance = 1;
            failed_attempts = 0;
        }
    }

    public void setscore(int num1, int num2, int num3)
    {
        if (num1 == num2 && num2 == num3)
        {   

            switch(num1)
            {
                case 0 :
                    
                    score += 1000;
                    scoretxt.text = score.ToString(); 

                break;

                case 1 :
                    
                    score += 100;
                    scoretxt.text = score.ToString(); 

                break;

                case 2 :
                    
                    score += 200;
                    scoretxt.text = score.ToString(); 

                break;
                
                case 3 :
                    
                    score += 500;
                    scoretxt.text = score.ToString(); 

                break;
            }

            Celebrate(num1);
        }
        else
        {
            failed_attempts++;
        }

    }

    void Celebrate(int combination)
    {
        if (combination > 0)
        {
            celebrate_vfx[0].Play();
            celebrate_vfx[1].Play(); 
        }
        else
        {
            foreach (var vfx in celebrate_vfx)
            {
                vfx.Play();
            }
        }
    }
}
