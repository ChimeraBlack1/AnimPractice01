using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class knightControls : MonoBehaviour
{

    public bool isGrounded;
    public bool isCrouching;

    public float speed;
    public float w_speed = 10f;
    public float r_speed = 20f;
    public float c_speed = 0.25f;
    public float MouserotSpeed = 2000f;
    public float rotSpeed = 20f;
    public float jumpHeight;
    public float sphereRadius = 5f;
    private float timeBtwAttack;
    private float timeBtwAttack4;
    public float startTimeBtwAttack;
    public float startTimeBtwAttack4;

    // Layer masks
    int ignoreEnemy = 1 << 13;


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

        if (Input.GetButtonDown("Jump"))
        {
            anim.SetTrigger("isJumping");
        }

        var translation = Input.GetAxis("Vertical") * w_speed * Time.deltaTime;
        var rotation = Input.GetAxis("Horizontal") * rotSpeed * Time.deltaTime;

        // if right mouse button held, rotation is controlled by mouse x
        if (Input.GetKey(KeyCode.Mouse1))
        {
            rotation = Input.GetAxis("Mouse X") * MouserotSpeed * Time.deltaTime;
        }


        if(timeBtwAttack <= 0)
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
        }else
        {
            timeBtwAttack -= Time.deltaTime;
        }
       

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            
            anim.SetTrigger("Hamstring");
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            anim.SetTrigger("Sprint");
        }


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
        }else
        {
            timeBtwAttack4 -= Time.deltaTime;
        }


        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            anim.SetTrigger("Whirlwind");
        }


        if (translation > 0)
        {
            anim.SetBool("isRunning", true);
        }
        else
        {
            anim.SetBool("isRunning", false);
        }

        if (Input.GetKey(KeyCode.Mouse1))
        {
            transform.rotation = Quaternion.Euler(0, Camera.main.transform.eulerAngles.y, 0);

            if(Input.GetKey(KeyCode.A))
            {
               // LEFT STRAFE
                transform.position += Vector3.left * w_speed * Time.deltaTime;
            }

            // RIGHT STRAFE
            if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            {
                transform.position += Vector3.right * w_speed * Time.deltaTime;
            }

        }
        else
        {
            transform.Rotate(0, rotation, 0);
        }

        transform.Translate(0, 0, translation);
    }



}





