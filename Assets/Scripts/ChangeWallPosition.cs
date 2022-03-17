using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeWallPosition : MonoBehaviour
{
    private float timeInWall = 0;
    private float randomPositionRotation = -4f;
    private float restartWallTimer = 0;
    
    void Start()
    {
        
    }

    void Update()
    {
        if(timeInWall < 2f && timeInWall > 0)
        {
            randomPositionRotation += Time.deltaTime;
            restartWallTimer += Time.deltaTime;
        }
        if(randomPositionRotation > 4f)
        {
            randomPositionRotation = -4f;
        }
        if(restartWallTimer > 3f)
        {
            Debug.Log("No te mantuviste en la pared lo suficiente");
            RestartWall();       
        }
        ChangePositionWall();
    }

    public void OnCollisionStay(Collision other)
    {
        if(other.gameObject.name == "Player")
        {
            timeInWall += Time.deltaTime;
        }
    }

    public void ChangePositionWall()
    {
        if(timeInWall > 2f)
        {
            transform.position = new Vector3(randomPositionRotation-1f,2,randomPositionRotation+1f);
            transform.rotation = Quaternion.Euler(0,randomPositionRotation * 45f,0);
            RestartWall();
        }
    }

    public void RestartWall()
    {
        timeInWall = 0;
        restartWallTimer = 0;
    }

}