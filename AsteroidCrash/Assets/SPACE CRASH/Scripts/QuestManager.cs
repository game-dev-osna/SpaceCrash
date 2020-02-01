using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    [SerializeField]
    private AudioClip Prologue;

    [SerializeField]
    private AudioClip SensorikTaskIntro;

    [SerializeField]
    private AudioClip SensorikTaskSuccess;


    [SerializeField]
    private AudioClip HitByAsteroidTaskIntro;

    //[SerializeField]
    //private AudioClip SensorikTaskDescription;



    [SerializeField]
    private AudioClip HitByAsteroidTaskSuccess;

    [SerializeField]
    private AudioClip HyperdriveTaskIntro;

    [SerializeField]
    private AudioSource narrator_01;

    private bool SensorikSolvedClipPlayed;
    private bool HyperdriveTaskIntoPlayed;

    // Start is called before the first frame update
    void Start()
    {
        narrator_01.clip = Prologue;
        narrator_01.PlayDelayed(2);
    }

    // Update is called once per frame
    void Update()
    {
        if (!narrator_01.isPlaying)
        {
            if (SensorikSolvedClipPlayed && !HyperdriveTaskIntoPlayed)
            {
                narrator_01.clip = HyperdriveTaskIntro;
                narrator_01.PlayDelayed(2);
                HyperdriveTaskIntoPlayed = true;
            }
        }
    }

    public void SensorikSolved()
    {
        StopAndPlay(SensorikTaskSuccess);
        SensorikSolvedClipPlayed = true;
    }

    private void StopAndPlay(AudioClip clip)
    {
        narrator_01.Stop();
        narrator_01.clip = clip;
        narrator_01.Play();
    }
}
