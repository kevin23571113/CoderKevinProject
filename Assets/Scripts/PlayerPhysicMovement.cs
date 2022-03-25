using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPhysicMovement : MonoBehaviour
{
    private Vector3 positionInitial;
    private Vector3 inputJugador;
    public Rigidbody rb;
    public Transform cam;
    public Animator anim;
    public GameObject prefabBullet;
    private float acceleration = 3f;
    private float deceleration = 4f;
    private float vel = 0;
    private float movSpeed = 1800f;
    private float turnSmoothTime = 0.1f;
    private float turnSmoothVel;
    
    void Start()
    {
        positionInitial = transform.position;
    }

    void Update()
    {
        Respawn();
        if(ManagerScore.playerHealth <= 0)
        {
            this.gameObject.SetActive(false);
        }
        anim.SetFloat("Velocity", vel);

        if(Input.GetKeyDown("space"))
        {
            Instantiate(prefabBullet, transform.position, transform.rotation);
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
        if(inputJugador.magnitude >= 0.01f)
        {
            if(vel < 1)
            {
                vel += Time.deltaTime * acceleration;
            }
            float targetAngle = Mathf.Atan2(inputJugador.x, inputJugador.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVel, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0, angle, 0);

            Vector3 movDirect = Quaternion.Euler(0, targetAngle, 0) * Vector3.forward;
            rb.AddForce(movDirect.normalized * movSpeed * Time.deltaTime);
        }
        else if(vel > 0)
        {
            vel -= Time.deltaTime * deceleration;
        }
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
            ManagerScore.playerHealth -= 5;
            Debug.Log("Tienes " + ManagerScore.playerHealth + "pts de vida");
            break;
            // Este es un ataque de un mago que añadire en el futuro
            case "MagicOrb":
            ManagerScore.playerHealth -= 3;
            Debug.Log("Tienes " + ManagerScore.playerHealth + "pts de vida");
            break;
        }
    }
}
