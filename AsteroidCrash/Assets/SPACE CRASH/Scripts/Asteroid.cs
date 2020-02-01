using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    [SerializeField]
    private float maxTravelSpeed;
    [SerializeField]
    private float maxRotationSpeed;
    [SerializeField]
    private Transform rotationTransform;    
    private Vector3 initialPosition;

    private float rotationSpeedUp;
    private float rotationSpeedForward;
    private float rotationSpeedRight;
    private float travelSpeed;

    private AudioSource audioSource;
    private float speed;
    private bool played;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();       
        initialPosition = transform.position;       
        Setup();
    }

    void Setup()
    {        
        rotationSpeedUp = maxRotationSpeed * Random.Range(0.1f, 1f);
        rotationSpeedForward = maxRotationSpeed * Random.Range(0.1f, 1f);
        rotationSpeedRight = maxRotationSpeed * Random.Range(0.1f, 1f);

        travelSpeed = maxTravelSpeed * Random.Range(0.1f, 1f);

        // audio
        audioSource.Stop();
        audioSource.pitch = travelSpeed / maxTravelSpeed;
        played = false;
    }

    void Update()
    {
        transform.Translate(Vector3.forward * (travelSpeed * Time.deltaTime));

        rotationTransform.Rotate(Vector3.up * (rotationSpeedUp * Time.deltaTime));
        rotationTransform.Rotate(Vector3.forward * (rotationSpeedForward * Time.deltaTime));
        rotationTransform.Rotate(Vector3.right * (rotationSpeedRight * Time.deltaTime));

        if(transform.position.z <= -40)
        {
            this.transform.position = initialPosition;
            Setup();
        }
        
        if(played == false && Vector3.Distance(transform.position, Vector3.zero) <= 16f)
        {
            played = true;
            audioSource.Play();           
        }
    }
      
}
