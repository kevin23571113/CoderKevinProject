using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockNextRoom : MonoBehaviour
{
    public Animator anim;
    public GameObject arrow;
    
    void Start()
    {

    }

    void Update()
    {

        if(ManagerGame.EnemigosSala_1 <= 6)
        {
            anim.SetBool("NextRoom", true);
            arrow.SetActive(true);
        }
    }
}
