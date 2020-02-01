using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trails : MonoBehaviour
{
    [SerializeField]
    private float minSpeed = 0.9f;

    [SerializeField]
    private float maxSpeed = 1.4f;

    [SerializeField]
    private float maxDistance = 0.4f;

    private float speed;

    private Vector3 startPosition;

 
    // Start is called before the first frame update
    void Start()
    {
        this.startPosition = this.transform.position;

        speed = Random.Range(minSpeed, maxSpeed);
    }

    // Update is called once per frame
    void Update()
    {
        //because we only travel forward
        float distanceTravelled = startPosition.z - transform.position.z;
        if(distanceTravelled > maxDistance)
        {
            distanceTravelled = 0;
            this.transform.position = startPosition;
        }

        transform.Translate(Vector3.forward * Time.deltaTime * speed);
    }
}
