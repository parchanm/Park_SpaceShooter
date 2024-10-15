using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyMissile : MonoBehaviour
{
    public float speed = 10;
    public float rotationSpeed = 20;
    public Transform target;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = (target.position - transform.position).normalized;

        Quaternion rotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.RotateTowards(transform.rotation,rotation, speed *Time.deltaTime);

        //add velocity
    }
}
