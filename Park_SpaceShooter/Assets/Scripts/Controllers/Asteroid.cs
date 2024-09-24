using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    public float moveSpeed;
    public float arrivalDistance;
    public float maxFloatDistance;

    Vector3 targetPosition;

    // Start is called before the first frame update
    void Start()
    {
        maxFloatDistance = 100;
        moveSpeed = 2;
    }

    // Update is called once per frame
    void Update()
    {
        //float rand = Random.Range(-maxFloatDistance, maxFloatDistance);
        //Vector3 randomVec = new Vector3(rand, rand);
        //transform.position += randomVec.normalized * moveSpeed * Time.deltaTime;

        //if(arrivalDistance == 1)
        //{

        //}
        //arrival distance,
        //
        //normalize not working -> normalize"d"

        //make a new function that randomzime the point everytime it reaches arrivaldistance
        if (Vector3.Distance(transform.position, targetPosition) <= arrivalDistance)
        {
            RandomTarget();
        }

        MoveToTarget();
    }
    void MoveToTarget()
    {
        Vector3 direction = (targetPosition - transform.position).normalized;
        transform.position += direction * moveSpeed * Time.deltaTime;
    }

    void RandomTarget()
    {
        float randX = Random.Range(-maxFloatDistance, maxFloatDistance);
        float randY = Random.Range(-maxFloatDistance, maxFloatDistance);
        Vector3 targetPosition = new Vector3(randX, randY, 0); // set random target when it's smaller than arrivalDistance
    }
}
