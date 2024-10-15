using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class W5_PlayerControl : MonoBehaviour
{
    public List<Transform> asteroidTransforms;
    public Transform enemyTransform;
    public GameObject bombPrefab;
    public Transform bombsTransform;

    //Basic character movement: velocity
    public float maxSpeed;
    private Vector3 currentVelocity;

    //Acceleration
    public float accelerationTime;
    private float acceleration;

    //Deceleration
    public float decelerationTime;
    private float deceleration;

    void Start()
    {
        acceleration = maxSpeed / accelerationTime;
        deceleration = maxSpeed / decelerationTime;
    }

    void Update()
    {
        Vector2 currentInput = Vector2.zero;
        if(Input.GetKey(KeyCode.LeftArrow))
        {
            currentInput += Vector2.left;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            currentInput += Vector2.right;
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            currentInput += Vector2.up;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            currentInput += Vector2.down;
        }

        if(currentInput.sqrMagnitude > 0)
        {
            //Our character is accelerating
            currentVelocity += acceleration * Time.deltaTime * (Vector3)currentInput.normalized;

            if(currentVelocity.magnitude > maxSpeed)
            {
                currentVelocity = currentVelocity.normalized * maxSpeed;
            }
        }
        else
        {
            //our character is decelerating
            Vector3 velocityDelta = (Vector3)currentVelocity.normalized * deceleration * Time.deltaTime;
            if(velocityDelta.sqrMagnitude > currentVelocity.magnitude)
            {
                currentVelocity = Vector3.zero;
            }
            else
            {
                currentVelocity -= velocityDelta;
            }
        }
        transform.position += currentVelocity * Time.deltaTime;
    }
}
