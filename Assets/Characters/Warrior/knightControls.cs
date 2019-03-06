using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class knightControls : MonoBehaviour
{

    public bool isGrounded;
    public bool isCrouching;

    public float speed = 0.1f;
    public float w_speed = 10f;
    public float jumpHeight;
    public float sphereRadius = 5f;
    public float startTimeBtwAttack;
    public float startTImeBtwAttack3;
    public float startTimeBtwAttack4;
    

    private float x;
    private float z;
    private float timeBtwAttack;
    private float timeBtwAttack3;
    private float timeBtwAttack4;
    private float speedTimer;
    

    // Layer masks
    int ignoreEnemy = 1 << 13;

    private Vector3 moveDirection = Vector3.zero;
    private CharacterController controller;

    Rigidbody rb;
    Animator anim;
    CapsuleCollider col_size;

    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        col_size = GetComponent<CapsuleCollider>();
        isGrounded = true;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, sphereRadius);
    }

    // Update is called once per frame
    void Update()
    {
        CheckIsJumping();
        CheckAbilityOne();
        CheckAbilityTwo();
        CheckAbilityThree();
        CheckAbilityFour();

        Move();
    }

    private void Move()
    {
        if (Input.GetKey(KeyCode.Mouse1))
        {
            transform.rotation = Quaternion.Euler(0, Camera.main.transform.eulerAngles.y, 0);
        }

        // todo think about putting in Time.deltaTime
        x = Input.GetAxis("Horizontal") * speed;
        z = Input.GetAxis("Vertical") * speed;

        Debug.Log("x: " + x + " and z: " + z);

        anim.SetFloat("VelY", z*100);
        anim.SetFloat("VelX", x*100);

        transform.Translate(x, 0, z);

        
    }

    private void CheckIfRunning()
    {
        if (z > 0)
        {
            anim.SetBool("isRunning", true);
        }
        else
        {
            anim.SetBool("isRunning", false);
        }

    }

    private void StrafeLeft()
    {
        if(x < 0)
        {
            anim.SetBool("StrafeLeft", true);
        }
        else
        {
            anim.SetBool("StrafeLeft", false);
        }
    }

    private void StrafeRight()
    {
        if (x > 0)
        {
            anim.SetBool("StrafeRight", true);
        }
        else
        {
            anim.SetBool("StrafeRight", false);
        }
    }

    private void CheckAbilityFour()
    {
        if (timeBtwAttack4 <= 0)
        {
            if (Input.GetKeyDown(KeyCode.Alpha4))
            {

                timeBtwAttack4 = startTimeBtwAttack4;
                anim.SetTrigger("Whirlwind");

                Collider[] hits = Physics.OverlapSphere(transform.position, sphereRadius);

                foreach (Collider hit in hits)
                {

                    if (hit.tag == "Enemy")
                    {
                        print("hit " + hit.gameObject);
                        // todo insert logic for reducing hitpoints of enemy
                    }
                }

            }
        }
        else
        {
            timeBtwAttack4 -= Time.deltaTime;
        }
    }

    private void CheckAbilityThree()
    {
        if (timeBtwAttack3 <= 0)
        {

            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                timeBtwAttack3 = startTImeBtwAttack3;
                speed = 0.2f;
                speedTimer = 5;
                anim.SetTrigger("Sprint");
            }

        }
        else
        {
            timeBtwAttack3 -= Time.deltaTime;
        }

        SpeedBoost();
    }

    private void SpeedBoost()
    {
        if (speed == 0.2f)
        {
            speedTimer -= Time.deltaTime;

            Debug.Log("speed for " + speedTimer + " seconds");

            if (speedTimer <= 0)
            {
                speed = 0.1f;
                speedTimer = 0;
            }
        }
    }

    private void CheckAbilityTwo()
    {
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {

            anim.SetTrigger("Hamstring");
        }
    }

    private void CheckAbilityOne()
    {
        if (timeBtwAttack <= 0)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {

                timeBtwAttack = startTimeBtwAttack;
                anim.SetTrigger("Cleave");

                Collider[] hits = Physics.OverlapSphere(transform.position, sphereRadius);

                foreach (Collider hit in hits)
                {

                    if (hit.tag == "Enemy")
                    {
                        print("hit " + hit.gameObject);
                        // todo insert logic for reducing hitpoints of enemy
                    }
                }

            }
        }
        else
        {
            timeBtwAttack -= Time.deltaTime;
        }
    }

    private void CheckIsJumping()
    {
        if (Input.GetButtonDown("Jump"))
        {
            anim.SetTrigger("isJumping");
        }
    }
}





