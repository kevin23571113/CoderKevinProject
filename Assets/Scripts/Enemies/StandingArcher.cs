using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandingArcher : MonoBehaviour
{
    ArcherEnemyHerecy archerChasing = new ArcherEnemyHerecy();
    public Transform playerTransform;
    public Animator anim;
    public List<GameObject> monedas = new List<GameObject>();
    public GameObject prefabMoneda;
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
            this.gameObject.GetComponent<StandingArcher>().enabled = false;
        }
        LookPlayer();
        archerChasing.distPlayer = Vector3.Distance(playerTransform.position , transform.position);
    }

    public void LookPlayer()
    {
        Quaternion rotLookPlayer = Quaternion.LookRotation(playerTransform.position-transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotLookPlayer,  archerChasing.speedRot*Time.deltaTime);
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
