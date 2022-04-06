using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletShootingEnemyBehaviour : MonoBehaviour
{
    public ScriptableBullet newBullet;
    private float destroyTimer = 6f;

    void Start()
    {
        Destroy(this.gameObject,destroyTimer);
    }

    void Update()
    {
        transform.position += transform.forward* newBullet.speedMov* Time.deltaTime;
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            ManagerScore.playerHealth -= newBullet.damage;
            Debug.Log("Tienes " + ManagerScore.playerHealth + "pts de vida.");
            Destroy(this.gameObject);
        }
    }
}
