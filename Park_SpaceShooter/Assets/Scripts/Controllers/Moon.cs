using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Moon : MonoBehaviour
{
    public Transform planetTransform;
    float angle = 0f;
    float radius = 1;
    public float rotationSpeed = 1f;

    //Vector3 moon = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        OrbitalMotion(radius, rotationSpeed, planetTransform);
    }

    public void OrbitalMotion(float radius, float speed, Transform target) //owen's help
    {
        //float angle =+ 360/angle;
        angle += speed * Time.deltaTime; //without 1, it's gonna rotate really slowly
        //angle *= Time.deltaTime;

        //angle = angle * Mathf.Deg2Rad;
        transform.position = target.position + new Vector3(Mathf.Cos(angle), Mathf.Sin(angle)) * radius;
    }
}
