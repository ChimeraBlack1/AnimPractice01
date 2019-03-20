using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class SetupLocalPlayer : NetworkBehaviour {

    Quaternion rotation;
    Rigidbody rb;
    NetworkAnimator anim;
    Animator animator;

    public float speed = 0.1f;
    public float startTImeBtwAttack3;
    public float startTimeBtwAttack4;
    public float sphereRadius = 5f;


    private float timeBtwAttack;
    private float timeBtwAttack3;
    private float timeBtwAttack4;
    private float speedTimer;


    // Use this for initialization
    void Start () {

        anim = GetComponentInChildren<NetworkAnimator>();

        if (isLocalPlayer)
        {
            GetComponent<BobControls>().enabled = true;
            WowCamera.target = this.gameObject.transform;
        }
        else
        {
            GetComponent<BobControls>().enabled = false;
        }

    }
	
	// Update is called once per frame
	void Update () {
        CheckAbilityOne();
        CheckAbilityTwo();
        CheckAbilityThree();
        CheckAbilityFour();
    }

    
    private void CheckAbilityOne()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            anim.SetTrigger("Cleave");
        }

        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            timeBtwAttack4 = startTimeBtwAttack4;
            //this.GetComponent<SetupLocalPlayer>().CmdChangeAnimState("Whirlwind");
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

    private void CheckAbilityTwo()
    {
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            anim.SetTrigger("Hamstring");
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
                //this.GetComponent<SetupLocalPlayer>().CmdChangeAnimState("Sprint");
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

    private void CheckAbilityFour()
    {
        if (timeBtwAttack4 <= 0)
        {
            if (Input.GetKeyDown(KeyCode.Alpha4))
            {

                timeBtwAttack4 = startTimeBtwAttack4;
                //this.GetComponent<SetupLocalPlayer>().CmdChangeAnimState("Whirlwind");
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


}



//[SyncVar(hook = "OnChangeAnimation")]
//public string animState = "idle";

////SyncListFloat direction = new SyncListFloat();

//[SyncVar(hook = "OnChangeEx")]
//public float x;

//[SyncVar(hook ="OnChangeZed")]
//public float z;

//void OnChangeAnimation (string aS)
//{
//    if (isLocalPlayer) return;
//    UpdateAnimationState(aS);
//}

//void OnChangeEx (float x)
//{
//    anim.SetFloat("VelX", x *10);
//}

//void OnChangeZed(float z)
//{
//    anim.SetFloat("VelY", z * 10);
//}

//[Command]
//public void CmdChangeAnimState(string aS)
//{
//    UpdateAnimationState(aS);     
//}

//[Command]
//public void CmdChangeMovement(float newX, float newZ)
//{
//    UpdateMovement(newX, newZ);
//}

//void UpdateMovement(float newX, float newZ)
//{
//    //if (x == newX && z == newZ) return;
//    x = newX;
//    z = newZ;

//    anim.SetFloat("VelY", newZ * 10);
//    anim.SetFloat("VelX", newX * 10);
//}



//void UpdateAnimationState(string aS)
//{
//    if (animState == aS) return;
//    animState = aS;
//    Debug.Log(animState);

//    if (animState == "Cleave")
//    {
//        anim.SetTrigger("Cleave");
//    }else if (animState == "Whirlwind")
//    {
//        anim.SetTrigger("Whirlwind");
//    }else if (animState == "Sprint")
//    {
//        anim.SetTrigger("Sprint");
//    }else if(animState == "Hamstring")
//    {
//        anim.SetTrigger("Hamstring");
//    }

//}



    //////////////////////////////////////////////////////////////////////////////




//[SyncVar(hook = "OnChangeEx")]
//public float x;

//[SyncVar(hook = "OnChangeZed")]
//public float z;

//void OnChangeEx(float x)
//{
//    animator.SetFloat("VelX", x * 10);
//}

//void OnChangeZed(float z)
//{
//    animator.SetFloat("VelY", z * 10);
//}


//[Command]
//public void CmdChangeMovement(float newX, float newZ)
//{
//    UpdateMovement(newX, newZ);
//}

//void UpdateMovement(float newX, float newZ)
//{
//    //if (x == newX && z == newZ) return;
//    x = newX;
//    z = newZ;

//    animator.SetFloat("VelY", newZ * 10);
//    animator.SetFloat("VelX", newX * 10);
//}