using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RagdollEnemyExample : MonoBehaviour
{
    public Transform playerTransform;
    public Animator anim;
    public List<GameObject> monedas = new List<GameObject>();
    public GameObject prefabMoneda;
    private float vel = 0;
    private float acceleration = 2f;
    private float deceleration = 5f;
    private float speedRot = 5f;
    private float distPlayer;
    private float speedMov = 0.2f;
    private int health = 20;
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
        anim.SetFloat("Velocity", vel);
        distPlayer = Vector3.Distance(playerTransform.position , transform.position);
        if(health <= 0)
        {
            CoinsDropped();
            ManagerGame.EnemigosSala_1 -= 1;
            this.gameObject.GetComponent<RagdollEnemyExample>().enabled = false;
        }
        if(hitTimer <= 0)
        {
            anim.SetBool("Hit", false);
            LookPlayer();
            if(distPlayer > 8.5f)
            {
                if(vel < 1)
                {
                    vel += Time.deltaTime * acceleration;
                }
                EnemyMovChasing();
            }
        }else if(hitTimer > 0)
        {
            hitTimer -= Time.deltaTime;
        }
        if(distPlayer <= 8.5f && vel > 0)
        {
            vel -= Time.deltaTime * deceleration;
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

    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "BulletPlayer")
        {
            health -= 5;
            anim.SetBool("Hit", true);
            hitTimer = 0.7f;
        }
    }
}
