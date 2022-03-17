using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPhysicMovement : MonoBehaviour
{
    private Vector3 positionInitial;
    public Rigidbody rb;
    public Transform cam;
    public GameObject prefabBullet;
    private float movSpeed = 800f;
    private float turnSmoothTime = 0.1f;
    private float turnSmoothVel;
    private float shootTimer = 0;
    private int health = 20;
    
    void Start()
    {
        positionInitial = transform.position;
    }

    void Update()
    {
        Respawn();
        if(health <= 0)
        {
            this.gameObject.SetActive(false);
        }
        if(shootTimer > 0)
        {
            shootTimer -= Time.deltaTime;
        }else
        {
            shootTimer = 0;
        }
        if(Input.GetKeyUp("space") && shootTimer == 0)
        {
            Shoot();
            shootTimer = 1f;
        }
    }

    void FixedUpdate()
    {
        Move();
    }

    public void Move()
    {
        float hor = Input.GetAxis("Horizontal");
        float ver = Input.GetAxis("Vertical");
        Vector3 inputJugador = new Vector3(hor,0,ver).normalized;
        if(inputJugador.magnitude >= 0.5f)
        {
            float targetAngle = Mathf.Atan2(inputJugador.x, inputJugador.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVel, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0, angle, 0);

            Vector3 movDirect = Quaternion.Euler(0, targetAngle, 0) * Vector3.forward;
            rb.AddForce(movDirect.normalized * movSpeed * Time.deltaTime);
        }
        
    }

    public void Shoot()
    {
        Instantiate(prefabBullet, transform.position, transform.rotation);
    }

    public void Respawn()
    {
        if(transform.position.y < -10)
        {
            transform.position = positionInitial;
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        switch(other.gameObject.tag)
        {
            case "Bullet":
            health -= 5;
            Debug.Log("Tienes " + health + "pts de vida");
            break;
            // Este es un ataque de un mago que añadire en el futuro
            case "MagicOrb":
            health -= 3;
            Debug.Log("Tienes " + health + "pts de vida");
            break;
        }
    }
}
