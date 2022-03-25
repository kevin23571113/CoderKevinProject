using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RagdollEnemyExample : MonoBehaviour
{
    public Transform playerTransform;
    public Animator anim;
    public CapsuleCollider myCollider;
    public GameObject hips;
    public Collider[] ragdollColliders;
    public Rigidbody[] mainRigidbodies;
    public List<GameObject> monedas = new List<GameObject>();
    public GameObject prefabMoneda;
    private float vel = 0;
    private float acceleration = 2f;
    private float deceleration = 5f;
    private float sightSpeed = 3f;
    private float distPlayer;
    private float speedMovShootingEnemy = 0.2f;
    private int health = 10;

    void Start()
    {
        GetRagdollBits();
        RagdollOff();
        monedas.Add(prefabMoneda);
        monedas.Add(prefabMoneda);
        monedas.Add(prefabMoneda);
        monedas.Add(prefabMoneda);
    }

    void Update()
    {
        if(health <= 0)
        {
            RagdollOn();
            //CoinsDropped();
            //lo inhabilite ya que como el objeto no se destruye se instancia monedas cada frame y no queremos eso
        }
        LookPlayer();
        distPlayer = Vector3.Distance(playerTransform.position , transform.position);
        anim.SetFloat("Velocity", vel);
        if(distPlayer > 10f)
        {
            if(vel < 1)
            {
                vel += Time.deltaTime * acceleration;
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

    public void CoinsDropped()
    {
        for(int i = 0; i < monedas.Count; i++)
            {

                int randomx = Random.Range(-10, 10);
                int randomz = Random.Range(-10, 10);
                Instantiate(monedas[i], new Vector3(transform.position.x + randomx/16f, 0.8f, transform.position.z + randomz/16f), Quaternion.Euler(90f, 0, 0));
            }
    }

    void GetRagdollBits()
    {
        ragdollColliders = hips.GetComponentsInChildren<Collider>();
        mainRigidbodies = hips.GetComponentsInChildren<Rigidbody>();
    }

    public void RagdollOn()
    {
        anim.enabled = false;
        myCollider.enabled = false;
        foreach(Collider col in ragdollColliders)
        {
            col.enabled = true;
        }
        foreach(Rigidbody rigid in mainRigidbodies)
        {
            rigid.isKinematic = false;
        }
    }

    public void RagdollOff()
    {
        anim.enabled = true;
        myCollider.enabled = true;
        foreach(Collider col in ragdollColliders)
        {
            col.enabled = false;
        }
        foreach(Rigidbody rigid in mainRigidbodies)
        {
            rigid.isKinematic = true;
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "BulletPlayer")
        {
            health -= 5;
        }
    }
}
