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

    public void GeneratResult()
    {
        result1 = UnityEngine.Random.Range(0, 4);

        result2 = (UnityEngine.Random.value < matchChance)
            ? result1
            : UnityEngine.Random.Range(0, 4);

        result3 = (UnityEngine.Random.value < matchChance)
            ? result1
            : UnityEngine.Random.Range(0, 4);

        if (matchChance == 1)
        {
            matchChance = this_chance;
        }
    }

    public void spin()
    {
        SoundManager.Instance.playsound(0);

        if (isspinning) return;

        SoundManager.Instance.playsound(1);

            GeneratResult();

            Lever_anim.SetTrigger("Pull");

            foreach (Animator anim in Reel_anim)
            {
                anim.enabled = true;
            }

            StartCoroutine(stopreel());

            isspinning = true;
    }

    IEnumerator stopreel()
    {
        yield return new WaitForSeconds(1.5f);

        float duration = 1f;
        float elapsed = 0f;

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
            anim.speed = stopspeed;
        }
        
        yield return new WaitForSeconds(2f);

        StartCoroutine(replace());
    }

    IEnumerator replace()
    {
        Reel_anim[0].gameObject.SetActive(false);
        Reels[0].sprite = Elements[result1]; 

        yield return new WaitForSeconds(1.5f);

        Reel_anim[2].gameObject.SetActive(false);
        Reels[1].sprite = Elements[result3];

        yield return new WaitForSeconds(1f);

        Reel_anim[1].gameObject.SetActive(false);
        Reels[2].sprite = Elements[result2];
         
        isspinning = false;

        score_Manager.setscore(result1, result2, result3);

        playagain.SetActive(true);
    }

    public void Reset()
    {
        SoundManager.Instance.playsound(2);
        foreach (var anim in Reel_anim)
        {
            anim.gameObject.SetActive(true);
            anim.enabled = false;
        }
       foreach (var renderer in Reels)
       {
            renderer.sprite = null;
       }
        playagain.SetActive(false);
    }
}
