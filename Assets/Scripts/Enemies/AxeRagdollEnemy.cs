using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxeRagdollEnemy : MonoBehaviour
{
    public Transform playerTransform;
    public Animator anim;
    public List<GameObject> monedas = new List<GameObject>();
    public GameObject prefabMoneda;
    public GameObject axeCollider;
    private float vel = 0;
    private float acceleration = 4f;
    private float deceleration = 6f;
    private float speedRot = 3f;
    private float distPlayer;
    private float speedMov = 0.3f;
    private int health = 15;
    private int attackType;
    private float attackTimer = 0.2f;
    private bool attack2 = false;
    private float hitTimer = 0;

    void Start()
    {
        monedas.Add(prefabMoneda);
        monedas.Add(prefabMoneda);
        monedas.Add(prefabMoneda);
        monedas.Add(prefabMoneda);
    }

    void Update()
    {
        distPlayer = Vector3.Distance(playerTransform.position , transform.position);
        anim.SetFloat("Velocity", vel);
        if(health <= 0)
        {
            CoinsDropped();
            ManagerGame.EnemigosSala_1 -= 1;
            this.gameObject.GetComponent<AxeRagdollEnemy>().enabled = false;
        }
        if(hitTimer <= 0)
        {
            anim.SetBool("Hit", false);
        }else if(hitTimer > 0)
        {
            hitTimer -= Time.deltaTime;
        }
        if(attackTimer <= 4f && hitTimer <= 0)
        {
            if(attack2 == true)
            {
                attack2 = false;
            }
            axeCollider.SetActive(false);
            LookPlayer();
            if(distPlayer > 1.8f)
            {
                if(vel < 1)
                {
                    vel += Time.deltaTime * acceleration;
                }
                EnemyMovChasing();
            }   
        }else if(attackTimer >= 4.1f)
        {
            axeCollider.SetActive(true);
            if(attack2 == true)
            {
                transform.position += transform.forward * 0.55f * Time.deltaTime;
            }
        }
        if(distPlayer <= 1.8f && hitTimer <= 0)
        {
            if(vel > 0)
            {
                vel -= Time.deltaTime * deceleration;
            }
            AttackPlayer();
        }
        if(attackTimer > 0)
        {
            attackTimer -= Time.deltaTime;
            if(attackTimer <= 4f)
            {
                anim.SetBool("Attack1", false);
                anim.SetBool("Attack2", false);
                anim.SetBool("Attack3", false);
            }
        }
    }

    public void LookPlayer()
    {
        Quaternion rotLookPlayer = Quaternion.LookRotation(playerTransform.position-transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotLookPlayer, speedRot*Time.deltaTime);
    }

    public void EnemyMovChasing()
    {
        transform.position = Vector3.Lerp(transform.position, playerTransform.position, speedMov*Time.deltaTime);
    }

    public void CoinsDropped()
    {
        for(int i = 0; i < monedas.Count; i++)
            {

                int randomx = Random.Range(-10, 10);
                int randomz = Random.Range(-10, 10);
                Instantiate(monedas[i], new Vector3(transform.position.x + randomx/16f, 0.8f, transform.position.z + randomz/16f), Quaternion.Euler(90f, 0, 0));
            }
    }

    public void AttackPlayer()
    {
        if(attackTimer <= 0)
        {
            attackType = Random.Range(0,120);
            if(attackType >= 0 && attackType < 46)
            {
                anim.SetBool("Attack1", true);
                attackTimer = 7.2f;
            }else if(attackType >= 46 && attackType < 66)
            {
                anim.SetBool("Attack2", true);
                attack2 = true;
                attackTimer = 8.8f;
            }else if(attackType >= 66)
            {
                anim.SetBool("Attack3", true);
                attackTimer = 7.2f;
            }
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "BulletPlayer")
        {
            health -= 5;
            if(health > 0 && attackTimer <= 3f)
            {
                anim.SetBool("Hit", true);
                hitTimer = 1f;
            }
        }
    }
}
