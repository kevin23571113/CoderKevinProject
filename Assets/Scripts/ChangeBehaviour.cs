using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeBehaviour : MonoBehaviour
{
    public enum EnemyBehaviour
    {
        looking,
        chasing,
    }

    public EnemyBehaviour behaviour;
    public Transform playerTransform;
    public float sightSpeed = 1f;
    public float speed = 1f;

    void Start()
    {
        
    }

    void Update()
    {
        switch(behaviour)
        {
            case EnemyBehaviour.looking:
            LookPlayer();
            break;
            case EnemyBehaviour.chasing:
            LookPlayer();
            float dist = Vector3.Distance(playerTransform.position , transform.position);
            if(dist>2f)
            {
                EnemyMovement();
            }
            break;
        }
    }

    public void LookPlayer()
    {
        Quaternion rot = Quaternion.LookRotation(playerTransform.position-transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation , rot , sightSpeed * Time.deltaTime);
    }

    public void EnemyMovement()
    {
        transform.position = Vector3.Lerp(transform.position , playerTransform.position , speed * Time.deltaTime);
    }
}
