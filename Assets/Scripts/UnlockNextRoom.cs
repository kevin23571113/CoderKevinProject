using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockNextRoom : MonoBehaviour
{
    public Animator anim;
    
    void Start()
    {

    }

    void Update()
    {

        if(ManagerGame.EnemigosSala_1 == 0)
        {
            anim.SetBool("NextRoom", true);
        }
    }
}
