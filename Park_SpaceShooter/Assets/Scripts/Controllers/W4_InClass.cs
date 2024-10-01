using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class W4_InClass : MonoBehaviour
{
    //public List<float> angles = new List<float>();

    public List<float> angles = new List<float>() { 0f, 45f, 90f, 135f, 270f, 360f }; //other example to make the list
    private int currentAngleIndex = 0;

    public float radius;
    Vector3 offset4radius;

    private float timeSinceLastUpdate = 0f;
    public float updateFrequency;

    // Start is called before the first frame update
    void Start()
    {
        //angles.Add(Mathf.Deg2Rad * 15);
        //angles.Add(Mathf.Deg2Rad * 30);
        //angles.Add(Mathf.Deg2Rad * 45);
        //angles.Add(Mathf.Deg2Rad * 60);
        //angles.Add(Mathf.Deg2Rad * 75);
        //angles.Add(Mathf.Deg2Rad * 90);
        //angles.Add(Mathf.Deg2Rad * 105);
        //angles.Add(Mathf.Deg2Rad * 130);
        //angles.Add(Mathf.Deg2Rad * 145);
        //angles.Add(Mathf.Deg2Rad * 160);
    }

    // Update is called once per frame
    void Update()
    {
        float currentAngle = angles[currentAngleIndex];
        Vector3 startingPoint = Vector3.zero + offset4radius; //literally starting point. did this several times
                                                              // ! ! ! Important ! ! ! if I don't start the starting point with offset, it'll not give me circle.


        float endPointX = Mathf.Cos(currentAngle * Mathf.Deg2Rad); // ! ! ! Important ! ! ! 
        float endPointY = Mathf.Sin(currentAngle * Mathf.Deg2Rad); // cos for x and sin for y + we're changing degree to radience
        //Vector3 endingPoint = new Vector3(endPointY, endPointX);
        Vector3 endingPoint = (new Vector3(endPointY, endPointX)) * radius + offset4radius;
        Debug.DrawLine(startingPoint, endingPoint, Color.red);
        //Vector3 endingPointWithRadius = new Vector3(endPointY, endPointX) * radius; // my dumb radius

        //TIme.DeltaTime

        timeSinceLastUpdate += Time.deltaTime; //

        if (timeSinceLastUpdate > updateFrequency)
        {
            timeSinceLastUpdate = 0f; //reset, wait for update frequency and reset again

            currentAngleIndex++; // ! ! ! important ! ! ! we're getting next thing in the list. Remember array index?
            //currentAngleIndex = currentAngleIndex % angles.Count; //  this allows us to divide currentAngleIndex by the number of angles and store the remainder
            // https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/operators/arithmetic-operators

            if (currentAngleIndex >= angles.Count)
            {
                currentAngleIndex = 0; // doing this so I don't get an error after scrolling through all the array
            }
        }

        //note: tangent: tan at 90 degrees goes forever = won't give any values
        // !!! importante !!! check out arccosine (arc series) in the slides + look up tutorials in korean for reminder
    }
}
