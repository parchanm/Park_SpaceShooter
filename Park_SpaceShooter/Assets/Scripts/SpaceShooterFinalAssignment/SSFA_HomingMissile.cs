using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SSFA_HomingMissile : MonoBehaviour
{
    //lookAt
    public Transform targetTransform;
    public float angularSpeed;

    //homing missile variable
    public float destroyTimer = 5f;
    public float speed = 3f;

    //Flare
    public string flareTag = "Flare";
    public string playerTag = "Player";

    void Start()
    {
        TargetingSystem();
    }

    // Update is called once per frame
    void Update()
    {
        destroyTimer -= Time.deltaTime;

        if (destroyTimer <= 0 || targetTransform == null)
        {
            Destroy(gameObject);
        }

        if (targetTransform != null) //Josh's help
        {
            TargetingSystem();
        }

        if (targetTransform != null)
        {
            //Convert this into an angle
            Vector3 currentFacingDirection = transform.up;
            float facingAngle = Mathf.Atan2(currentFacingDirection.y, currentFacingDirection.x) * Mathf.Rad2Deg;

            //Convert this into an angle
            Vector3 targetDirection = targetTransform.position - transform.position;
            float targetAngle = Mathf.Atan2(targetDirection.y, targetDirection.x) * Mathf.Rad2Deg;

            float deltaAngle = Mathf.DeltaAngle(facingAngle, targetAngle);

            //Debug.Log(deltaAngle);
            //Debug.DrawLine(transform.position, transform.position + transform.up, Color.red);
            //Debug.DrawLine(transform.position, targetDirection + transform.position, Color.blue);
            if (deltaAngle > 0)
            {
                transform.Rotate(0f, 0f, angularSpeed * Time.deltaTime);
            }
            else if (deltaAngle < 0)
            {
                transform.Rotate(0f, 0f, -angularSpeed * Time.deltaTime);
            }

            //Movement
            transform.position += transform.up * speed * Time.deltaTime;
        }
    }
    
    public void TargetingSystem() //written with Josh's help
    {
        GameObject flare = GameObject.FindWithTag(flareTag);
        if (flare != null) //if flare exsists in the scene, follow flare first
        {
            targetTransform = flare.transform;
        }
        else
        {
            GameObject player = GameObject.FindWithTag(playerTag);
            if (player != null) //if not, follow the player
            {
                targetTransform = player.transform;
            }
            else //if there's no target, missile will just move forward
            {
                targetTransform = null;
            }
        }
    }
}
