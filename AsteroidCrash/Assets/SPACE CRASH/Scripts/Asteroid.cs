using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    [SerializeField]
    private float travelSpeed;

    [SerializeField]
    private float rotationSpeed;
    [SerializeField]
    private Transform rotationTransform;

    private Vector3 initialPosition;

    private float rotationSpeedUp;
    private float rotationSpeedForward;
    private float rotationSpeedRight;

    void Start()
    {
        ReSpawn();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * (travelSpeed * Time.deltaTime));

        rotationTransform.Rotate(Vector3.up * (rotationSpeedUp * Time.deltaTime));
        rotationTransform.Rotate(Vector3.forward * (rotationSpeedForward * Time.deltaTime));
        rotationTransform.Rotate(Vector3.right * (rotationSpeedRight * Time.deltaTime));

        if(transform.position.z < -20f)
        {
            transform.position = initialPosition;
            ReSpawn();
        }
    }

    void ReSpawn()
    {
        rotationSpeedUp = rotationSpeed * Random.Range(0.01f, 1f);
        rotationSpeedForward = rotationSpeed * Random.Range(0.01f, 1f);
        rotationSpeedRight = rotationSpeed * Random.Range(0.01f, 1f);

        initialPosition = transform.position;
    }
}
