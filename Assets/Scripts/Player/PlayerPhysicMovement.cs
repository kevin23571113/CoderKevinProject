using UnityEngine;
using System;

public class PlayerPhysicMovement : MonoBehaviour
{
    private Vector3 positionInitial;
    private Vector3 inputJugador;
    public Rigidbody rb;
    public Transform cam;
    public Animator anim;
    public GameObject swordCollider;
    public GameObject shieldCollider;
    public GameObject postProcessGlobal;
    public GameObject winPanel;
    private float acceleration = 3f;
    private float deceleration = 4f;
    private float vel = 0;
    private float movSpeed = 4300f;
    private float turnSmoothTime = 0.1f;
    private float turnSmoothVel;
    private int attackFase = 0;
    private float attackTimer = 0;
    private bool attacking = false;
    private bool blocking = false;
    private int axeDamage = 6;
    private float hit = 0;
    
    void Start()
    {
        positionInitial = transform.position;
    }

    void Update()
    {
        Debug.Log(ManagerGame.EnemigosSala_1);
        Respawn();
        anim.SetFloat("Velocity", vel);
        if(attackTimer > 0)
        {
            attackTimer -= Time.deltaTime;
        }else if(attackTimer < 0)
        {
            attackTimer = 0;
        }
        if(blocking == false)
        {
            AttackCombo();
        }
        if(attackFase == 0)
        {
            swordCollider.SetActive(false);
            Block();
        }else
        {
            swordCollider.SetActive(true);
        }
        BeingHit();
        LowHealthPostPorcess();
        YouWin();
    }

    void FixedUpdate()
    {
        if(attackFase == 0 && blocking == false && hit <= 0)
        {
            Move();
        }
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

    public void AttackCombo()
    {
        if(Input.GetMouseButtonDown(0))
        {
            if(attackTimer <= 0.55f && attackFase <= 2)
            {
                attackFase ++;
                attacking = false;
            }
        }
        switch(attackFase)
        {
            case 1:
            anim.SetBool("Attack1", true);
            if(attacking == false)
            {
                attackTimer = 1.3f;
                attacking = true;
            }
            break;
            case 2:
            anim.SetBool("Attack2", true);
            if(attacking == false)
            {
                attackTimer = 1.14f;
                attacking = true;
            }
            break;
            case 3:
            anim.SetBool("Attack3", true);
            transform.position += transform.forward * 1.1f * Time.deltaTime;
            if(attacking == false)
            {
                attackTimer = 1.708f;
                attacking = true;
            }
            break;
        }
        if(attackTimer <= 0 && attackFase != 0)
        {
            anim.SetBool("Attack1", false);
            anim.SetBool("Attack2", false);
            anim.SetBool("Attack3", false);
            attackFase = 0;
            attacking = false;
        }
    }

    public void Block()
    {
        if(Input.GetMouseButton(1))
        {
            blocking = true;
            shieldCollider.SetActive(true);
            anim.SetBool("Block", true);
        }else
        {
            anim.SetBool("Block", false);
            blocking = false;
            shieldCollider.SetActive(false);
        }
    }

    public void BeingHit()
    {
        if(hit > 0)
        {
            anim.SetBool("Hit",true);
            hit -= Time.deltaTime;
        }else if (hit <= 0)
        {
            anim.SetBool("Hit",false);
        }
    }

    public void LowHealthPostPorcess()
    {
        if(ManagerScore.playerHealth <= 8f)
        {
            postProcessGlobal.SetActive(true);
        }
    }

    public void YouWin()
    {
        if(ManagerGame.EnemigosSala_1 == 0)
        {
            winPanel.SetActive(true);
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        switch(other.gameObject.tag)
        {
            case "AxeEnem":
            ManagerScore.playerHealth -= axeDamage;
            if(blocking == false && attackTimer <= 0)
            {
                hit = 0.25f;
            }
            Debug.Log("Tienes " + ManagerScore.playerHealth + "pts de vida.");
            break;
        }
    }
}
