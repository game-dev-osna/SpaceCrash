﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestTrigger : MonoBehaviour
{
    [SerializeField]
    private GameObject objectToActivate;

    [SerializeField]
    private GameObject objectToDeactivate;

    [SerializeField]
    private AudioSource effect;

    [SerializeField]
    private string QuestItemToReactTo;

    //public bool HasBeenSolved;

        [SerializeField]
    private QuestManager questManager;

    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<QuestItem>() != null
            && QuestItemToReactTo == other.GetComponent<QuestItem>().QuestItemName)
        {
            if(effect != null)
            {
                effect.Play();
            }
            objectToActivate.SetActive(true);
            objectToDeactivate.SetActive(false);

            if(QuestItemToReactTo == "SensorScreen")
            {
                questManager.SensorikSolved();
            }
            if(QuestItemToReactTo == "HyperdriveReplacementCylinder")
            {
                questManager.ProgressHyperdrive();
            }
            if (QuestItemToReactTo == "HyperdriveReplacementBox")
            {
                questManager.ProgressHyperdrive();
            }
            if (QuestItemToReactTo == "HyperdriveReplacementCapsule")
            {
                questManager.ProgressHyperdrive();
            }
        }
    }
}
