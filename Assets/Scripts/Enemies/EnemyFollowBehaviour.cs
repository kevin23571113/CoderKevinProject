using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollowBehaviour : MonoBehaviour
{
    public Transform playerTransform;
    public float speed = 1f;

    void Start()
    {
        
    }

    void Update()
    {
        float dist = Vector3.Distance(playerTransform.position , transform.position);
        if(dist>2f)
        {
            EnemyMovement();
        }
        
    }

    public void EnemyMovement()
    {
        transform.position = Vector3.Lerp(transform.position , playerTransform.position , speed * Time.deltaTime);
    }
}
