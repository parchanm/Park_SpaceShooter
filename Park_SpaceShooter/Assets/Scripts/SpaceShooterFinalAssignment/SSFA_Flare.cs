using System.Collections;
using System.Collections.Generic;
using Codice.CM.Common;
using UnityEngine;

public class SSFA_Flare : MonoBehaviour
{
    public float destroyTimer = 3f;
    public float speed = 1f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        destroyTimer -= Time.deltaTime;
        if (destroyTimer <= 0)
        {
            Destroy(gameObject);
        }

        transform.position += transform.up * - speed * Time.deltaTime;
    }
}
