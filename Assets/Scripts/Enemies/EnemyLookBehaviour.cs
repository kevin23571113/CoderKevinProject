using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLookBehaviour : MonoBehaviour
{
    public Transform playerTransform;
    public float sightSpeed = 3f;

    void Start()
    {
        
    }

    void Update()
    {
        LookPlayer();
    }

    public void LookPlayer()
    {
        Quaternion rot = Quaternion.LookRotation(playerTransform.position-transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation , rot , sightSpeed * Time.deltaTime);
    }
}
