using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiatorShootingEnemy : MonoBehaviour
{
    public Transform playerTransform;
    public GameObject instantiatorBullet;
    public Animator anim;
    private float distInstantPlayer;
    private float bulletTimer = 1f;
    private float animTimer = 3f;
    private bool animShooting = false;
    private float rangeRay = 11f;

    void Start()
    {
        
    }

    void Update()
    {
        distInstantPlayer = Vector3.Distance(playerTransform.position , transform.position);
        if(animShooting == true && bulletTimer > 0)
        {
           bulletTimer -= Time.deltaTime;
        }
        RaycastHit hit;
        if(Physics.Raycast(transform.position, transform.forward, out hit, rangeRay))
        {
            if(hit.transform.tag != "Enemy" && animShooting == true && bulletTimer <= 0)
            {
                anim.SetBool("Shooting", false);
                animShooting = false;
                Instantiate(instantiatorBullet, transform.position, transform.rotation);
            }
        }
        if(animTimer > 0)
        {
            animTimer -= Time.deltaTime;
        }else
        {
            animTimer = 0;
            ShootPlayer();
        }
    }

    public void ShootPlayer()
    {
        if(distInstantPlayer <= 9.3f && animTimer == 0)
        {
            bulletTimer = 2f;
            anim.SetBool("Shooting", true);
            animShooting = true;
            animTimer= 10f;
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "BulletPlayer")
        {
            bulletTimer = 2f;
            animTimer = 3f;
            animShooting = false;
        }        
    }
}