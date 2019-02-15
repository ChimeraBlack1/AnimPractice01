using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MageControl : MonoBehaviour {

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


        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            anim.SetTrigger("Blink");
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            if (translation == 0)
            {
                anim.SetTrigger("Frostbolt");
            }else
            {
                // todo change "can't cast while moving" warning to GUI representation for user, rather than just printing in console
                print("must be standing still to cast");
            }
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            anim.SetTrigger("FrostNova");

        }

        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            anim.SetTrigger("FrozenOrb");

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
        }
        else
        {
            transform.Rotate(0, rotation, 0);
        }


        transform.Translate(0, 0, translation);
    }

}
