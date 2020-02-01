using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestTrigger : MonoBehaviour
{
    [SerializeField]
    private GameObject objectToActivate;

    [SerializeField]
    private GameObject objectToDeactivate;

    [SerializeField]
    private string tagToReactTo;

    [SerializeField]
    private AudioSource effect;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == tagToReactTo)
        {
            if(effect != null)
            {
                effect.Play();
            }
            objectToActivate.SetActive(true);
            objectToDeactivate.SetActive(false);
        }

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
