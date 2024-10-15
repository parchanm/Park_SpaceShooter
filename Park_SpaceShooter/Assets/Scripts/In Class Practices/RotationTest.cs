using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationTest : MonoBehaviour
{
    public float angularSpeed = 2.0f;
    public float targetAngle = 90f;
    public Transform targetTransform;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 startPosition = transform.position;
        Vector3 endPosition = transform.position + transform.up;
        Debug.DrawLine(startPosition, endPosition);

        Vector3 newTarget = targetTransform.position - transform.position; // **** target Vector ****
        float newTargetAngle = Mathf.Atan2(newTarget.y, newTarget.x) * Mathf.Rad2Deg - 90; // **** we want in forms of degree ****


        //eulerAngles are the rotation of the object in degrees
        //we get access to them using the transform
        //they are represented in the form of a Vector3 (same as position)

        if (transform.eulerAngles.z < newTargetAngle)
        {
            //We have not yet arrived at our target, so we still need to rotate more
            transform.Rotate(0, 0, angularSpeed * Time.deltaTime);
        }

        //If we have now overshot the angle
        if (transform.eulerAngles.z > newTargetAngle)
        {
            //We snap back to the correct target angle because it's too high
            transform.eulerAngles = new Vector3(transform.eulerAngles.x,
                                                transform.eulerAngles.y,
                                                newTargetAngle);
        }

        //Rotate(0, 0, AngularSpeed);
    }

    public void Rotate(float xAngle, float yAngle, float zAngle)
    {
        transform.Rotate(xAngle, yAngle, zAngle * Time.deltaTime);
    }

    public float StandardizeAngle(float inAngle)
    {
        inAngle = inAngle % 360; // 375%360 -> 15 735%360 -> 15 360으로 계속 나눠서 남는 값을 내놓기

        inAngle = (inAngle + 360) % 360;

        if (inAngle > 180)
        {
            inAngle -= 360;
        }

        return inAngle;
    }
}
