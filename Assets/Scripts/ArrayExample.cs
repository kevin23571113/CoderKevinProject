using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrayExample : MonoBehaviour
{
    int cantidad = 10;
    public GameObject objetoAInstanciar;
    public GameObject[] arrayObjetos;

    void Start()
    {
        arrayObjetos = new GameObject[cantidad];
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.L))
        {
            for(int i = 0; i < arrayObjetos.Length; i++)
            {
                GameObject go =Instantiate(objetoAInstanciar, new Vector3(i, 0, 0), Quaternion.identity);
                arrayObjetos[i] = go;
            }
        }else if(Input.GetKeyDown(KeyCode.R))
        {
            for(int i = 0; i < arrayObjetos.Length; i++)
            {
                GameObject go =Instantiate(objetoAInstanciar, new Vector3(-i, 0, 0), Quaternion.identity);
                arrayObjetos[i] = go;
            }
        }
    }
}
