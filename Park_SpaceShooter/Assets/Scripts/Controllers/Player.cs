﻿using System.Collections;
using System.Collections.Generic;
using Codice.CM.WorkspaceServer;
using JetBrains.Annotations;
using UnityEngine;

public class Player : MonoBehaviour
{
    public List<Transform> asteroidTransforms;

    //W4 task 1
    private List<float> angles = new List<float>(); // make list of angles
    private int currentAngleIndex = 0;
    public float radius;
    Vector3 offset4radius;
    //task 2
    private List<float> task2Angles = new List<float>();
    private int currentTask2Angles = 0;
    public float task2Radius;
    public int powerupNumber = 3;

    public GameObject powerUpHere;

    private float timeSinceLastUpdate = 0f;
    public float updateFrequency;
    public int cPoints = 8;

    public Transform enemyTransform;
    public GameObject bombPrefab;
    public Transform bombsTransform;

    //private Vector3 velocity = Vector3.right * 0.001f;
    public float myVelocity = 0.01f;

    //in class exercise
    private Vector3 velocity = Vector3.zero;
    private float acceleration = 1;
    //The amount of time it will take to reach the target speed
    public float timeToReachSpeed = 3f;
    //The speed that we want the character to reach after a certain amount of time
    public float maxSpeed = 2f;
    //private float acceleration;


    private List<string> words = new List<string>();

    private void Start()
    {
        acceleration = maxSpeed / timeToReachSpeed;

        //Cat[0], Dog[1], Box[2], Car[3]
        words.Add("Cat");
        words.Add("Dog");
        words.Add("Box");
        words.Add("Car");

        words.Insert(2, "Log");
        Debug.Log("Box is currently at the index: " + words.IndexOf("Box"));
        for (int i = 0; i < words.Count; i++)
        {

        }
        //Cat[0], Log[1], Box[2], Car[3]
        foreach (string word in words)
        {
            Debug.Log(word);
        }

        offset4radius = transform.position;
    }
    void Update()
    {
        //Class exercise
        /*
        transform.position = new Vector3(transform.position.x + 0.01f, transform.position.y);
        transform.position += Vector3.right * 0.01f; // prof.Keely's example (different method)

        transform.position += velocity;
        */

        //note from tutor. vector can't go negative anyways because it's direction

        transform.position += velocity * Time.deltaTime;

        if (Input.GetKey(KeyCode.None))
        {
            velocity -= acceleration * velocity.normalized * Time.deltaTime; //picture: normalized vs not normalized
        }


        if (Input.GetKey(KeyCode.UpArrow) && maxSpeed > acceleration)
        {
            velocity += acceleration * Vector3.up * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.LeftArrow) && maxSpeed > acceleration)
        {
            velocity += acceleration * Vector3.left * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.DownArrow) && maxSpeed > acceleration)
        {
            velocity += acceleration * Vector3.down * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.RightArrow) && maxSpeed > acceleration)
        {
            velocity += acceleration * Vector3.right * Time.deltaTime;
        }

        EnemyRadar(radius, cPoints);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            SpawnPowerups(radius, powerupNumber);
        }
    }
    //public void EnemyRadar(float radius, int circlePoints)
    //{
    //    //try the loop (from tutor)
    //    float currentAngle = angles[currentAngleIndex];

    //    float nextAngle = angles[currentAngleIndex + 1];

    //    //Vector3 startingPoint = Vector3.zero + offset4radius;
    //    float startPointX = Mathf.Cos(currentAngle * Mathf.Deg2Rad);
    //    float startPointY = Mathf.Sin(currentAngle * Mathf.Deg2Rad);
    //    Vector3 startPoint = (new Vector3(startPointX, startPointY)) * radius + offset4radius;


    //    float endPointX = Mathf.Cos(nextAngle * Mathf.Deg2Rad); // ! ! ! Important ! ! ! 
    //    float endPointY = Mathf.Sin(nextAngle * Mathf.Deg2Rad); // cos for x and sin for y + we're changing degree to radience
    //    //Vector3 endingPoint = new Vector3(endPointY, endPointX);
    //    Vector3 endingPoint = (new Vector3(endPointY, endPointX)) * radius + offset4radius;

    //    //for(int i = 0; i < circlePoints; i++)
    //    //{
    //    //    // how do I increment angles until it's 360 and make it stop? + draw all the lines in the loop
    //    //    angles.Add(Mathf.Deg2Rad * 45);
    //    //    currentAngleIndex++;

    //    //    if (currentAngleIndex >= angles.Count)
    //    //    {
    //    //        currentAngleIndex = 0; // doing this so I don't get an error after scrolling through all the array
    //    //    }
    //    //}
    //    Debug.DrawLine(startPoint, endingPoint, Color.green);

    //    timeSinceLastUpdate += Time.deltaTime; //

    //    if (timeSinceLastUpdate > updateFrequency)
    //    {
    //        timeSinceLastUpdate = 0f; //reset, wait for update frequency and reset again

    //        currentAngleIndex++; // ! ! ! important ! ! ! we're getting next thing in the list. Remember array index?
    //        //currentAngleIndex = currentAngleIndex % angles.Count; //  this allows us to divide currentAngleIndex by the number of angles and store the remainder
    //        // https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/operators/arithmetic-operators

    //        if (currentAngleIndex >= angles.Count)
    //        {
    //            currentAngleIndex = 0; // doing this so I don't get an error after scrolling through all the array
    //        }
    //    }

    //}
    public void EnemyRadar(float radius, int circlePoints)
    {
        angles = new List<float>();// everytime this method is called, reset the list
        for (int i = 0; i < circlePoints; i++)
        {


            angles.Add(360f / circlePoints * i); //leslie's guidance
        }
        Vector3 startingPoint = transform.position;

        for (int i = 0; i < angles.Count; i++)
        {
            float currentPointX = Mathf.Cos(angles[i] * Mathf.Deg2Rad);
            float currentPointY = Mathf.Sin(angles[i] * Mathf.Deg2Rad);
            Vector3 currentPoint = new Vector3(currentPointX, currentPointY) * radius + transform.position;

            float nextPointX = 0;
            float nextPointY = 0;

            //float lastPointX = 0;
            //float lastPointY = 0;
            //Vector3 lastPoint = new Vector3()

            if (i < angles.Count -1)
            {
                nextPointX = Mathf.Cos(angles[i + 1] * Mathf.Deg2Rad);
                nextPointY = Mathf.Sin(angles[i + 1] * Mathf.Deg2Rad);

            }
            else
            {
                nextPointX = Mathf.Cos(angles[0] * Mathf.Deg2Rad);
                nextPointY = Mathf.Sin(angles[0] * Mathf.Deg2Rad);
                //return;
            }
            //float nextPointX = Mathf.Cos(angles[i + 1] * Mathf.Deg2Rad);
            //float nextPointY = Mathf.Cos(angles[i + 1] * Mathf.Deg2Rad);


            Vector3 nextPoint = new Vector3(nextPointX, nextPointY) * radius + transform.position;
            //Debug.DrawLine(currentPoint, nextPoint, Color.green);
            float distanceCalculation = Vector3.Distance(enemyTransform.position, transform.position);

            if(radius >= distanceCalculation)
            {
                Debug.DrawLine(currentPoint, nextPoint, Color.red);
            }
            else
            {
                Debug.DrawLine(currentPoint, nextPoint, Color.green);
            }
        }

    }

    public void SpawnPowerups(float radius, int numberOfPowerups)
    {
        //task2Angles = new List<float>();// everytime this method is called, reset the list
        //for (int i = 0; i < numberOfPowerups; i++)
        //{
        //    angles.Add((360f / numberOfPowerups) * i); //leslie's guidance
        //}
        ////////////////////
        //for (int i = 0; i < numberOfPowerups; i++)// owen
        //{

        //    float currentPointX = Mathf.Cos(angles[i] * Mathf.Deg2Rad);
        //    float currentPointY = Mathf.Sin(angles[i] * Mathf.Deg2Rad);
        //    Vector3 currentPoint = new Vector3(currentPointX, currentPointY) * task2Radius;

        //    Instantiate(powerUpHere, currentPoint, Quaternion.identity);
        float angle = 360/numberOfPowerups;
        angle = angle * Mathf.Deg2Rad;

        for (int i = 0; i < numberOfPowerups; i++) {
            Instantiate(powerUpHere, transform.position + new Vector3(Mathf.Cos(angle * i), Mathf.Sin(angle * i)), Quaternion.identity);
        }
    }
}
