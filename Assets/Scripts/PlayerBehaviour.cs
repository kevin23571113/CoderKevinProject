using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    public float movementSpeed = 3f;
    public GameObject camUno;
    public GameObject camDos;

    void Start()
    {
        
    }

    void Update()
    {
        Move();
        if(Input.GetKeyDown(KeyCode.P))
        {
            ChangeCamera();
        }
        RotatePlayer();
    }

    public void ChangeCamera()
    {
        if(camUno.activeInHierarchy)
        {
            camUno.SetActive(false);
            camDos.SetActive(true);
        }else
        {
            camUno.SetActive(true);
            camDos.SetActive(false);
        }
    }

    public void Move()
    {
        float hor = Input.GetAxis("Horizontal");
        float ver = Input.GetAxis("Vertical");
        transform.Translate(new Vector3(hor,0,ver) * movementSpeed * Time.deltaTime);
    }

    public void RotatePlayer()
    {
        if(Input.GetKey(KeyCode.N))
        {
            transform.Rotate(0,-1f,0);
        }
        if(Input.GetKey(KeyCode.M))
        {
            transform.Rotate(0,1f,0);
        }
    }
}
