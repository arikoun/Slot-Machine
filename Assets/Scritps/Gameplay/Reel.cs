using System.Collections;
using UnityEngine;
using Unity.Mathematics;

public class Reel : MonoBehaviour
{
    
    Score_manager score_Manager;

    [SerializeField] bool isspinning = false;

    [Header("Refrences")]
    [SerializeField] SpriteRenderer[] Reels;

    [Header("Animators")]
    [SerializeField] Animator Lever_anim;
    [SerializeField] Animator[] Reel_anim = new Animator[3];
    [SerializeField] float stopspeed = 2f;

    [SerializeField] Sprite[] Elements;

    [Header("Result")]
    float this_chance ;

    // matchchance = 0.3f means 30% chance of same image
    [SerializeField,Range(0,1)] public float matchChance = 0.3f;

    [SerializeField] int result1;
    [SerializeField] int result2;
    [SerializeField] int result3;

    [SerializeField] GameObject playagain;

    void Start()
    {
        score_Manager = GetComponent<Score_manager>();
        this_chance = matchChance;
    }

    // generated the result from random number generation
    public void GenerateResult()
    {
        // if player is not getting any matching images. then increase the chance for that happeing
        //generate Random number for each Reel

        result1 = UnityEngine.Random.Range(0, 4);

        result2 = (UnityEngine.Random.value < matchChance)
            ? result1
            : UnityEngine.Random.Range(0, 4);

        result3 = (UnityEngine.Random.value < matchChance)
            ? result1
            : UnityEngine.Random.Range(0, 4);

        if (matchChance == 1)
        {
            //reset the matchchance to original, after one use
            matchChance = this_chance;
        }
    }

    // spin the reels after pressing on the lever
    public void spin()
    {
        SoundManager.Instance.playsound(0);
        // ensure that it only spin once when pressed, and has to waite for it to stop, to spin again
        if (isspinning) return;

        SoundManager.Instance.playsound(1);

            GenerateResult();

            // pull animation for the lever
            Lever_anim.SetTrigger("Pull");

            // turn on the animators on the reels , after pulling lever
            foreach (Animator anim in Reel_anim)
            {
                anim.enabled = true;
            }
            
            // trigger coroutine to stop the reels
            StartCoroutine(stopreel());


            isspinning = true;
    }

    // coroutine to stop the reels
    IEnumerator stopreel()
    {
        // let the reels spin at high speed for some time
        yield return new WaitForSeconds(1.5f);

        // make them slowly lose speed with using lerp method
        float duration = 1f;
        float elapsed = 0f;

        // Lerp the speed of reel animation
        while (elapsed < duration)
        {
            float t = elapsed / duration;

            foreach (Animator anim in Reel_anim)
            {
                anim.speed = Mathf.Lerp(1f, stopspeed, t);
            }

            elapsed += Time.deltaTime;
            yield return null;
        }


        foreach (Animator anim in Reel_anim)
        {
            // set the speed of the reels to low 
            anim.speed = stopspeed;
        }
        
        yield return new WaitForSeconds(2f);

        // trigger coroutine to replace the image on the front of the reels
        StartCoroutine(replace());
    }

    // replace coroutine
    IEnumerator replace()
    {
        //set the reel gameobject to inactive
        Reel_anim[0].gameObject.SetActive(false);
        // change the sprite of the number generated reels to suitable ones
        Reels[0].sprite = Elements[result1]; 
        // play the sound
        SoundManager.Instance.playsound(3);

        // wait in between for some intense feeling
        yield return new WaitForSeconds(1.5f);

        Reel_anim[2].gameObject.SetActive(false);
        Reels[1].sprite = Elements[result3];
        SoundManager.Instance.playsound(3);

        yield return new WaitForSeconds(1f);

        Reel_anim[1].gameObject.SetActive(false);
        Reels[2].sprite = Elements[result2];
        SoundManager.Instance.playsound(3); 

        // call the setscore function on scenemanger script
        score_Manager.setscore(result1, result2, result3);

        // show the playagain window
        playagain.SetActive(true);
    }

    // function to reset the machine
    public void Reset()
    {
        // reset the flags
        isspinning = false;
        SoundManager.Instance.playsound(2);
        
        // make the reel animators active again 
        foreach (var anim in Reel_anim)
        {
            anim.gameObject.SetActive(true);
            anim.enabled = false;
        }
        // make the reel renderer null
        foreach (var renderer in Reels)
        {
                renderer.sprite = null;
        }

        //hide the window
        playagain.SetActive(false);
    }
}
