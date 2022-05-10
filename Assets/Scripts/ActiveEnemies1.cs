using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveEnemies1 : MonoBehaviour
{
    public GameObject archer_1;
    public GameObject archer_2;
    public GameObject archer_3;
    public GameObject archer_4;
    public GameObject axeEnem_1;
    public GameObject axeEnem_2;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            archer_1.SetActive(true); 
            archer_2.SetActive(true);
            archer_3.SetActive(true);
            archer_4.SetActive(true);
            axeEnem_1.SetActive(true);
            axeEnem_2.SetActive(true);
        }
    }
}
