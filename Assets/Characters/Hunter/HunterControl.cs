using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HunterControl : MonoBehaviour {

    Animator anim;
    public float w_speed = 5f;
    public float rotSpeed = 200f;
    public float mouseRotSpeed = 1000f;

    // Use this for initialization
    void Start () {
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        float translation = Input.GetAxis("Vertical") * w_speed * Time.deltaTime;
        float rotation = Input.GetAxis("Horizontal") * rotSpeed * Time.deltaTime;

        //if(Input.GetKey(KeyCode.Mouse1))
        //{
        //    //rotation = Input.GetAxis("Mouse X") * mouseRotSpeed * Time.deltaTime;
           
        //}

        if(translation > 0)
        {
            anim.SetBool("isRunning", true);
        }else
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
