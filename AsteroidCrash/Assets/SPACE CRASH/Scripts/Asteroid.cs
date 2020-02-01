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
    
    private float rotationSpeedUp;
    private float rotationSpeedForward;
    private float rotationSpeedRight;
    private float travelSpeed;

    private float lastDistance;

    void Start()
    {
        rotationSpeedUp = maxRotationSpeed * Random.Range(0.1f, 1f);
        rotationSpeedForward = maxRotationSpeed * Random.Range(0.1f, 1f);
        rotationSpeedRight = maxRotationSpeed * Random.Range(0.1f, 1f);

        travelSpeed = maxTravelSpeed * Random.Range(0.1f, 1f);
        lastDistance = float.MaxValue;
    }

    void Update()
    {
        transform.Translate(Vector3.forward * (travelSpeed * Time.deltaTime));

        rotationTransform.Rotate(Vector3.up * (rotationSpeedUp * Time.deltaTime));
        rotationTransform.Rotate(Vector3.forward * (rotationSpeedForward * Time.deltaTime));
        rotationTransform.Rotate(Vector3.right * (rotationSpeedRight * Time.deltaTime));

        var currentDistance = Vector3.Distance(this.transform.position, Vector3.zero);      
        if (currentDistance > lastDistance)
        {
            Destroy(gameObject, 6f);
        }
        else
        {
            lastDistance = currentDistance;
        }
    }

  
}
