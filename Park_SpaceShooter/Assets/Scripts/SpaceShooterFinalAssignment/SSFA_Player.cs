using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SSFA_Player : MonoBehaviour
{
    //Revamped player movment
    public float maxSpeed = 4f;
    private Vector3 currentVelocity;

    //Acceleration & Deceleration
    public float timeToReachMaxSpeed = 2.5f;
    public float acceleration = 2;

    public float timeToDecelerate = 2.5f;
    private float deceleration = 2;

    //SSFA Hyper Ring
    public float hyperRIngRadius = 1f;
    public float speedBoost = 200f;
    public Transform hyperRingHere;
    public float originalMaxSpeed = 4f;
    public float boostedMaxSpeed = 8f;
    public bool inTheRing = false;

    public float setTimer = 5;
    private float hyperRingTimer; //timer system after troubleshooting

    //shooting the ship
    public float boostedAcceleration = 20f;
    private float originalAcceleration;

    //flare
    public GameObject flareHere;
    public Transform playerPosition;

    //barrier
    public GameObject barrier;

    private void Start()
    {
        //acceleration = maxSpeed / timeToReachMaxSpeed;
        originalAcceleration = maxSpeed / timeToReachMaxSpeed;
        acceleration = originalAcceleration;
        //originalAcceleration = maxSpeed / timeToReachMaxSpeed;
        deceleration = maxSpeed / timeToDecelerate;

        hyperRingTimer = setTimer;


    }
    void Update()
    {
        HyperRing();
        Vector2 currentInput = Vector2.zero;

        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W) && maxSpeed > acceleration)
        {
            //velocity += acceleration * Vector3.up * Time.deltaTime;
            currentInput += Vector2.up;
        }
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A) && maxSpeed > acceleration)
        {
            //velocity += acceleration * Vector3.left * Time.deltaTime;
            currentInput += Vector2.left;
        }
        if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S) && maxSpeed > acceleration)
        {
            //velocity += acceleration * Vector3.down * Time.deltaTime;
            currentInput += Vector2.down;
        }
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D) && maxSpeed > acceleration)
        {
            //velocity += acceleration * Vector3.right * Time.deltaTime;
            currentInput += Vector2.right;
        }

        if (currentInput.sqrMagnitude > 0)
        {
            currentVelocity += acceleration * Time.deltaTime * (Vector3)currentInput.normalized;

            if (currentVelocity.magnitude > maxSpeed)
            {
                currentVelocity = currentVelocity.normalized * maxSpeed;
            }
        }
        else
        {
            Vector3 velocityDelta = (Vector3)currentVelocity.normalized * deceleration * Time.deltaTime;
            if (velocityDelta.sqrMagnitude > currentVelocity.magnitude)
            {
                currentVelocity = Vector3.zero;
            }
            else
            {
                currentVelocity -= velocityDelta;
            }
        }
        transform.position += currentVelocity * Time.deltaTime;

        //Debug.Log(hyperRingTimer);
        //HyperRing();

        if(Input.GetKeyUp(KeyCode.Space))
        {
            Instantiate(flareHere, playerPosition.position, Quaternion.identity);
        }
    }

    public void HyperRing()
    {
        float distanceTOHyperRing = Vector3.Distance(transform.position, hyperRingHere.position);

        if (distanceTOHyperRing <= hyperRIngRadius && hyperRingTimer >= setTimer) //ship is in the ring's range
        {
            if (!inTheRing) //boost the speed and switch the bool to true
            {
                maxSpeed = boostedMaxSpeed;
                acceleration = boostedAcceleration;
                inTheRing = true;
                //Debug.Log(inTheRing + " and maxSpeed: " + maxSpeed);
                hyperRingTimer = 0;

                Vector3 ringDirection = hyperRingHere.up;
                currentVelocity += ringDirection.normalized * speedBoost;
                //Debug.Log(currentVelocity);
            }
        }
        else //vise versa && out of radius check
        {
            if (hyperRingTimer <= setTimer) //implementing timer system
            {
                hyperRingTimer += Time.deltaTime; //timer
                //inTheRing = false;
                Debug.Log("boosting...");

                if (hyperRingTimer >= setTimer)
                {
                    maxSpeed = originalMaxSpeed;
                    acceleration = originalAcceleration;
                    inTheRing = false;
                }
            }
        }
    }
}
