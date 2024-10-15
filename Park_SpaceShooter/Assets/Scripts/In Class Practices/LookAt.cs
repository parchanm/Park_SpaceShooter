using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAt : MonoBehaviour
{
    public Transform targetTransform;
    public float angularSpeed;

    //
    public float destroyTimer = 5f;
    public float speed = 3f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (targetTransform == null) return; //help from Josh

        Vector3 currentFacingDirection = transform.up;
        float facingAngle = Mathf.Atan2(currentFacingDirection.y, currentFacingDirection.x) * Mathf.Rad2Deg;

        Vector3 targetDirection = targetTransform.position - transform.position;
        float targetAngle = Mathf.Atan2(targetDirection.y, targetDirection.x) * Mathf.Rad2Deg;

        float deltaAngle = Mathf.DeltaAngle(facingAngle, targetAngle);

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

        //Timer
        destroyTimer -= Time.deltaTime;
        if (destroyTimer <= 0)
        {
            Destroy(gameObject);
        }
    }
}
