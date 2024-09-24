using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour
{
    public Transform targetTransform;
    public float followSpeed = 1f;

    //Vector3 goHere = new Vector3(targetTransform.position.x - transform.position.x, targetTransform.position.y - transform.position.y);
    public void Start()
    {
        //Vector3 goHere = new Vector3(targetTransform.position.x - transform.position.x, targetTransform.position.y - transform.position.y);
    }
    private void Update()
    {
        EnemyFollows(targetTransform, followSpeed);
    }
    public void EnemyFollows(Transform target, float speed)
    {
        Vector3 goHere = new Vector3(targetTransform.position.x - transform.position.x, targetTransform.position.y - transform.position.y);
        transform.position += goHere * Time.deltaTime;
    }
}
