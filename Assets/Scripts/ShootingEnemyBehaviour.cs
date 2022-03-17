using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingEnemyBehaviour : MonoBehaviour
{
    public Transform playerTransform;
    public Animator anim;
    float vel = 0;
    private float sightSpeed = 3f;
    private float distPlayer;
    private float speedMovShootingEnemy = 0.2f;
    private float acceleration = 2f;
    private float deceleration = 5f;
    private int health = 10;

    void Start()
    {
        
    }

    void Update()
    {
        if(health <= 0)
        {
            Destroy(this.gameObject);
        }
        LookPlayer();
        distPlayer = Vector3.Distance(playerTransform.position , transform.position);
        anim.SetFloat("Velocity", vel);
        if(distPlayer > 10f)
        {
            if(vel < 1)
            {
                vel += Time.deltaTime*acceleration;
            }
            EnemyMovChasing();
        }else if(distPlayer <= 10f && vel > 0)
        {
            vel -= Time.deltaTime*deceleration;
        }
    }

    public void LookPlayer()
    {
        Quaternion rotLookPlayer = Quaternion.LookRotation(playerTransform.position-transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotLookPlayer, sightSpeed*Time.deltaTime);
    }

    public void EnemyMovChasing()
    {
        transform.position = Vector3.Lerp(transform.position, playerTransform.position, speedMovShootingEnemy*Time.deltaTime);
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "BulletPlayer")
        {
            health -= 5;
        }
    }
}
