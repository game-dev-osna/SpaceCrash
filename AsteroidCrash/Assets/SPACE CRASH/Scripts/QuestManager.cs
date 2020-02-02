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
    private AudioClip HyperdriveFirstItemDone;
    [SerializeField]
    private AudioClip HyperdriveSecondItemDone;
    [SerializeField]
    private AudioClip HyperdriveTaskFinished;


    [SerializeField]
    private AudioClip HyperdriveDontTouch;

    [SerializeField]
    private AudioSource narrator_01;

    [SerializeField]
    private GameObject HyperdriveReplacementPartsDoor;

    [SerializeField]
    private GameObject HyperdriveTrails;
    [SerializeField]
    private GameObject NormalTrails;

    [SerializeField]
    private GameObject BigAsteroid;
    [SerializeField]
    private GameObject AsteroidField;
    [SerializeField]
    private GameObject GameWonText;

    private int HypderdrivePartsFixed = 0;

    private bool SensorikIntroPlayed;
    private bool SensorikSolvedClipPlayed;
    private bool HyperdriveTaskIntroPlayed;
    private bool HyperdriveFixed;
    public bool GameWon;


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
            if(!SensorikSolvedClipPlayed && !SensorikIntroPlayed)
            {
                narrator_01.clip = SensorikTaskIntro;
                narrator_01.PlayDelayed(1);
                SensorikIntroPlayed = true;
            }

            if (SensorikSolvedClipPlayed && !HyperdriveTaskIntroPlayed)
            {
                narrator_01.clip = HyperdriveTaskIntro;
                narrator_01.PlayDelayed(1);
                HyperdriveTaskIntroPlayed = true;
            }
            if(HyperdriveFixed)
            {
                GameWon = true;
            }
        }

        if (HyperdriveFixed && !BigAsteroid.GetComponent<AsteroidBig>().GameOver)
        {
            //Game won
            HyperdriveTrails.SetActive(true);
            GameWonText.SetActive(true);
            NormalTrails.SetActive(false);
            BigAsteroid.SetActive(false);
            AsteroidField.SetActive(false);
        }
    }

    public void SensorikSolved()
    {
        if (BigAsteroid.GetComponent<AsteroidBig>().GameOver)
            return;

        StopAndPlay(SensorikTaskSuccess);
        HyperdriveReplacementPartsDoor.SetActive(false);
        SensorikSolvedClipPlayed = true;
    }

    public void ProgressHyperdrive()
    {
        if (BigAsteroid.GetComponent<AsteroidBig>().GameOver)
            return;

        HypderdrivePartsFixed++;

        if (HypderdrivePartsFixed == 1)
        {
            StopAndPlay(HyperdriveFirstItemDone);
        }
        else if (HypderdrivePartsFixed == 2)
        {
            StopAndPlay(HyperdriveSecondItemDone);
        }
        else
        {
            StopAndPlay(HyperdriveTaskFinished);
            HyperdriveFixed = true;
        }
    }

    public void DontTouchHyperdriveFrame()
    {        
        StopAndPlay(HyperdriveDontTouch);
    }

    private void StopAndPlay(AudioClip clip)
    {
        narrator_01.Stop();
        narrator_01.clip = clip;
        narrator_01.Play();
    }
}
