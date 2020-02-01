using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    [SerializeField]
    private AudioClip Prologue;

    [SerializeField]
    private AudioClip SensorikTaskSuccess;


    [SerializeField]
    private AudioClip HitByAsteroidTaskIntro;

    //[SerializeField]
    //private AudioClip SensorikTaskDescription;

    [SerializeField]
    private AudioClip SensorikTaskIntro;

    [SerializeField]
    private AudioClip HitByAsteroidTaskSuccess;

    [SerializeField]
    private AudioSource narrator_01;

    // Start is called before the first frame update
    void Start()
    {
        narrator_01.clip = Prologue;
        narrator_01.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SensorikSolved()
    {
        narrator_01.Stop();
        narrator_01.clip = SensorikTaskSuccess;
        narrator_01.Play();
    }
}
