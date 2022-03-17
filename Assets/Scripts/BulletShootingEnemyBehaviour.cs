using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletShootingEnemyBehaviour : MonoBehaviour
{
    private float destroyTimer = 6f;
    private float bulletMovSpeed = 15f;

    void Start()
    {
        Destroy(this.gameObject,destroyTimer);
    }

    void Update()
    {
        transform.position += transform.forward*bulletMovSpeed*Time.deltaTime;
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            Destroy(this.gameObject);
        }
    }
}
