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

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            //
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            anim.SetTrigger("Frostbolt");
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            anim.SetTrigger("Hamstring");
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

        transform.Translate(0, 0, translation);
        transform.Rotate(0, rotation, 0);
    }


}


//float translation = Input.GetAxis("Mouse Y") * speed;
//float rotation = Input.GetAxis("Mouse X") * rotSpeed;

//print(rotation);

//translation *= Time.deltaTime;
//        rotation *= Time.deltaTime;
//        transform.Translate(0,0,translation);
//        transform.Rotate(0, rotation, 0);

//        if(Input.GetKey(KeyCode.Mouse0) && Input.GetKey(KeyCode.Mouse1))
//        {
//            transform.Translate(Vector3.forward* Time.deltaTime* speed);
//        }


//        if (Input.GetButtonDown("Jump"))
//        {
//            anim.SetTrigger("isJumping");
//        }