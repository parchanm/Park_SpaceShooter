using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class W6_InClass : MonoBehaviour
{
    public float redAngle, blueAngle;

    //Vector3 red = new Vector3()

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Convert red angle to red vector
        Vector3 redVector = new Vector3(Mathf.Cos(redAngle * Mathf.Deg2Rad), Mathf.Sin(redAngle * Mathf.Deg2Rad));
        //Convert blue angle to red vector
        Vector3 blueVector = new Vector3(Mathf.Cos(blueAngle * Mathf.Deg2Rad), Mathf.Sin(blueAngle * Mathf.Deg2Rad));

        Debug.DrawLine(Vector3.zero, redVector, Color.red);
        Debug.DrawLine(Vector3.zero, blueVector, Color.blue);

        float dotRB = redVector.x * blueVector.x + redVector.y * blueVector.y;
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log(dotRB.ToString());
        }
    }
}
