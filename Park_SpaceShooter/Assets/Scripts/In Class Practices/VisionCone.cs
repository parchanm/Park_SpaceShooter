using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class VisionCone : MonoBehaviour
{
    public float detectionRadius;
    public float detectionAngle;
    public Transform targetTransform;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 lookingDirection = transform.up;
        //Switching from vector to angle in terms of the looking direction
        float lookingAngle = Mathf.Atan2(lookingDirection.y, lookingDirection.x);

        //Tilting the angle to the left and right to get the limits of the field of view for the vision cone
        float leftAngle = lookingAngle + detectionAngle / 2;
        float rightAngle = lookingAngle - detectionAngle / 2;

        //switching from angle to vector in terms of the limits of the field of the view for the vision cone
        Vector3 leftVector = new Vector3(Mathf.Cos(leftAngle * Mathf.Deg2Rad), Mathf.Sin(leftAngle * Mathf.Deg2Rad));
        Vector3 rightVector = new Vector3(Mathf.Cos(rightAngle * Mathf.Deg2Rad), Mathf.Sin(rightAngle * Mathf.Deg2Rad));


        //Is the object too far to be visible
        bool targetIsCloseEnough = Vector3.Distance(transform.position, targetTransform.position) < detectionRadius;

        //Is the object in the field of view?
        bool targetIsInFOV = lookingAngle < leftAngle && lookingAngle > rightAngle;

        Color lineColor;
        if(targetIsCloseEnough && targetIsInFOV)
        {
            lineColor = Color.green;

        }
        else
        {
            lineColor = Color.red;
        }

        Debug.DrawLine(transform.position, leftVector + transform.position, lineColor);
        Debug.DrawLine(transform.position, rightVector + transform.position, lineColor);
    }
}
