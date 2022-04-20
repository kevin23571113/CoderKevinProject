using UnityEngine;
using System;

public class BulletShootingEnemyBehaviour : MonoBehaviour
{
    public ScriptableBullet newBullet;
    private float destroyTimer = 10f;
    private bool moving = true;

    void Start()
    {
        Destroy(this.gameObject,destroyTimer);
    }

    void Update()
    {
        if(moving == true)
        {
            transform.position += transform.forward* newBullet.speedMov* Time.deltaTime;
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        switch(other.gameObject.tag)
        {
            case "Player":
            ManagerScore.playerHealth -= newBullet.damage;
            Debug.Log("Tienes " + ManagerScore.playerHealth + "pts de vida.");
            Destroy(this.gameObject);
            break;
            case "ShieldPlayer":
            //partculas de flecha rebotando
            Destroy(this.gameObject);//esto es set active false
            break;
            case "Environment":
            moving = false;
            this.gameObject.GetComponent<BoxCollider>().enabled = false;
            break;
        }
    }
}
