using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedBox : MonoBehaviour
{
    public Rigidbody2D redBoxRIgidbody;
    public float acceleration;
    public LayerMask detectionLayerMask;

    private void Start()
    {
        
    }

    private void Update()
    {
        //Collider2D colliderInRange = Physics2D.OverlapCircle(transform.position, 3f);
        //if (colliderInRange != null)
        //{
        //    Debug.Log("something detected");
        //}
    }
    private void FixedUpdate()
    {
        redBoxRIgidbody.velocity += (Vector2)(acceleration * transform.up * Time.fixedDeltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("entered!");
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        Debug.Log("currently IN the space");
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        Debug.Log("now exiting");
    }
}
