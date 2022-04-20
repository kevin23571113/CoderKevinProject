using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    public Animator anim;
    private bool onDeath = false;

    void Start()
    {
        
    }

    void Update()
    {
        if(ManagerScore.playerHealth <= 0 && onDeath == false)
        {
            anim.SetBool("Attack1", false);
            anim.SetBool("Attack2", false);
            anim.SetBool("Attack3", false);
            anim.SetBool("Block", false);
            anim.SetBool("OnDeath", true);
            this.gameObject.GetComponent<PlayerPhysicMovement>().enabled = false;
            onDeath = true;
        }
        else if(ManagerScore.playerHealth > 0 && onDeath == true)
        {
            anim.SetBool("OnDeath", false);
            this.gameObject.GetComponent<PlayerPhysicMovement>().enabled = true;
            onDeath = false;
        }
    }
}
