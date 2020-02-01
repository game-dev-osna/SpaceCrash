using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidBig : MonoBehaviour
{
    [SerializeField]
    private float secondsFromStartToImpact;

    private float timer;
    
    [SerializeField]
    private float maxRotationSpeed;
    [SerializeField]
    private Transform rotationTransform;
    [SerializeField]
    private GameObject asteroidParent;
    [SerializeField]
    private GameObject trailsParent;
    [SerializeField]
    private GameObject endText;
    [SerializeField]
    private GameObject ownSphere;

    private Vector3 initialPosition;

    private float rotationSpeedUp;
    private float rotationSpeedForward;
    private float rotationSpeedRight;

    private AudioSource audioSource; 

    void Start()
    {
        endText.SetActive(false);
        audioSource = GetComponent<AudioSource>();

        initialPosition = transform.position;

        rotationSpeedUp = maxRotationSpeed * Random.Range(0.1f, 1f);
        rotationSpeedForward = maxRotationSpeed * Random.Range(0.1f, 1f);
        rotationSpeedRight = maxRotationSpeed * Random.Range(0.1f, 1f);


    }

    void Update()
    {
        rotationTransform.Rotate(Vector3.up * (rotationSpeedUp * Time.deltaTime));
        rotationTransform.Rotate(Vector3.forward * (rotationSpeedForward * Time.deltaTime));
        rotationTransform.Rotate(Vector3.right * (rotationSpeedRight * Time.deltaTime));

        timer += Time.deltaTime / secondsFromStartToImpact;
        transform.position = Vector3.Lerp(initialPosition, Vector3.zero, timer);

        if(Vector3.Distance(transform.position, Vector3.zero) <= 5f)
        {
            Debug.Log("End.");
            foreach (var child in asteroidParent.transform.GetComponentsInChildren<Asteroid>())
            {
                child.Pause(true);
            }
            foreach (var child in trailsParent.transform.GetComponentsInChildren<Trails>())
            {
                child.Pause(true);
            }

            ownSphere.SetActive(false);
            endText.SetActive(true);

        }
    }
   

   
}
