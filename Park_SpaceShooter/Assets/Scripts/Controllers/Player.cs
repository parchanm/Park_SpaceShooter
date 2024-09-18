using System.Collections;
using System.Collections.Generic;
using Codice.CM.WorkspaceServer;
using UnityEngine;

public class Player : MonoBehaviour
{
    public List<Transform> asteroidTransforms;
    public Transform enemyTransform;
    public GameObject bombPrefab;
    public Transform bombsTransform;

    //private Vector3 velocity = Vector3.right * 0.001f;
    public float myVelocity = 0.01f;

    //in class exercise
    private Vector3 velocity = Vector3.zero;
    public float acceleration = 1;
    //The amount of time it will take to reach the target speed
    private float timeToReachSpeed = 3f;
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
    }
    void Update()
    {
        //Class exercise
        /*
        transform.position = new Vector3(transform.position.x + 0.01f, transform.position.y);
        transform.position += Vector3.right * 0.01f; // prof.Keely's example (different method)

        transform.position += velocity;
        */

        //velocity += acceleration * transform.up * Time.deltaTime;
        //transform.position += velocity * Time.deltaTime;

        //velocity += acceleration * Time.deltaTime;


        if (Input.GetKey(KeyCode.W) && maxSpeed > acceleration)
        {
            //transform.position = new Vector3(transform.position.x, transform.position.y + myVelocity);
            //transform.position += Vector3.up * myVelocity * acceleration * Time.deltaTime;

            velocity += acceleration * Vector3.up * Time.deltaTime;
            transform.position += velocity * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.A) && maxSpeed > acceleration)
        {
            //transform.position = new Vector3(transform.position.x - myVelocity, transform.position.y);
            transform.position += Vector3.left * myVelocity * acceleration * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.S) && maxSpeed > acceleration)
        {
            //transform.position = new Vector3(transform.position.x, transform.position.y - myVelocity);
            transform.position += Vector3.down * myVelocity * acceleration * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D) && maxSpeed > acceleration)
        {
            //transform.position = new Vector3(transform.position.x + myVelocity, transform.position.y);
            transform.position += Vector3.right * myVelocity * acceleration * Time.deltaTime;
        }
        //deceleration
        if (Input.GetKeyUp(KeyCode.W))
        {

        }
    }

    //public void playerMovement()
    //{

    //}
}
