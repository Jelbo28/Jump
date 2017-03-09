using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AudioManager : MonoBehaviour
{
    float waitBeforeClip;
    [SerializeField]
    public bool play = false;

    public List<AudioClip> audioClips;

    AudioSource AS;
    private float initialValue;

    // Use this for initialization
    void Awake()
    {
        initialValue = waitBeforeClip;
        AS = GetComponent<AudioSource>();
    }

    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    PlaySound();
        //}
        waitBeforeClip -= Time.deltaTime;
        if (waitBeforeClip <= 0f && play)
        {
            PlaySound();
            waitBeforeClip = AS.clip.length;
        }
    }

    public void PlaySound()
    {
        int clipNumber = Mathf.RoundToInt(Random.Range(0f, audioClips.Count));
        AS.Stop();
        AS.clip = audioClips[clipNumber];
        AS.Play();
        play = false;
    }

}

