using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChasingArcher : MonoBehaviour
{
    ArcherEnemyHerecy archerChasing = new ArcherEnemyHerecy();
    public Transform playerTransform;
    public Animator anim;
    public List<GameObject> monedas = new List<GameObject>();
    public GameObject prefabMoneda;
    private float vel = 0;
    private float acceleration = 5f;
    private float deceleration = 5f;
    private float speedMov = 0.2f;
    private float distPlayer;

    void Start()
    {
        archerChasing.name = "Archer";
        archerChasing.health = 10;
        archerChasing.speedRot = 3f;

        monedas.Add(prefabMoneda);
        monedas.Add(prefabMoneda);
        monedas.Add(prefabMoneda);
        monedas.Add(prefabMoneda);
    }

    void Update()
    {
        if(archerChasing.health <= 0)
        {
            CoinsDropped();
            this.gameObject.GetComponent<ChasingArcher>().enabled = false;
        }
        LookPlayer();
        archerChasing.distPlayer = Vector3.Distance(playerTransform.position , transform.position);
        anim.SetFloat("Velocity", vel);
        if(archerChasing.distPlayer > 10f)
        {
            if(vel < 1)
            {
                vel += Time.deltaTime * acceleration;
            }
            MovChasing();
        }else if(archerChasing.distPlayer <= 10f && vel > 0)
        {
            vel -= Time.deltaTime * deceleration;
        }
    }

    public void LookPlayer()
    {
        Quaternion rotLookPlayer = Quaternion.LookRotation(playerTransform.position-transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotLookPlayer,  archerChasing.speedRot*Time.deltaTime);
    }

    public void MovChasing()
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
            archerChasing.health -= 5;
        }
    }
}
