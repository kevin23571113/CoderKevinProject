using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnlyRagdollBehaviour : MonoBehaviour
{
    public Animator anim;
    public CapsuleCollider myCollider;
    public GameObject hips;
    public Collider[] ragdollColliders;
    public Rigidbody[] mainRigidbodies;
    private int health = 20;

    void Start()
    {
        GetRagdollBits();
        RagdollOff();
    }

    void Update()
    {
        if(health <= 0)
        {
            RagdollOn();
            Destroy(this.gameObject, 25f);
        }
    }

    public void GetRagdollBits()
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
