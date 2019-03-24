using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class SetupLocalPlayer : NetworkBehaviour {

    Quaternion rotation;
    Rigidbody rb;
    NetworkAnimator anim;

    public float speed = 0.1f;
    public float startTimeBtwAttack = 2;
    public float startTImeBtwAttack3;
    public float startTimeBtwAttack4;
    public float sphereRadius = 5f;
    public float cleaveDamage = 10f;
    public float whirlwindDamage = 20f;
    public float hamstringDamage = 5f;

    [SyncVar]
    private float dmgAmount;

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

        Attack();
        //CheckAbilityOne();
        //CheckAbilityTwo();
        //CheckAbilityFour();
    }

    //[Command]
    //public void CmdUpdateHealth(float health)
    //{
    //    UpdateHealth(health);
    //}


    [Command]
    public void CmdAttack()
    {
            timeBtwAttack = startTimeBtwAttack;
            dmgAmount = cleaveDamage;

            GameObject thePlayer;
            thePlayer = this.gameObject;

            Debug.Log(thePlayer);

            Collider[] hits = Physics.OverlapSphere(transform.position, sphereRadius);

            foreach (Collider hit in hits)
            {
                    Debug.Log(hit.name);
                    if (hit.tag == "Player" && hit.gameObject != thePlayer)
                    {
                        print("hit " + hit.gameObject);   // <-----------------
                        Damage(hit.transform);
                    }
            }
    }


    void Attack()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            anim.SetTrigger("Cleave");
            CmdAttack();
        }
    }


    void Damage(Transform enemy)
    {
        Enemy e = enemy.GetComponent<Enemy>();

        if (e != null)
        {
            e.TakeDamage(dmgAmount);
        }
        else
        {
            Debug.Log("Error taking damage.");
        }


    }

    void UpdateHealth(float hp)
    {
        Debug.Log("hersky fersky new hp " + hp);
    }

    //private void CheckAbilityOne() 
    //{
    //    if (timeBtwAttack <= 0)
    //    {
    //        if (Input.GetKeyDown(KeyCode.Alpha1))
    //        {
    //            timeBtwAttack = startTimeBtwAttack;
    //            anim.SetTrigger("Cleave");
    //            dmgAmount = cleaveDamage;

    //            Collider[] hits = Physics.OverlapSphere(transform.position, sphereRadius);
                

    //            foreach (Collider hit in hits)
    //            {
    //                if (!isLocalPlayer)
    //                {
    //                    Debug.Log(hit.name);
    //                    if (hit.tag == "Player")
    //                    {
    //                        print("hit " + hit.gameObject);   // <-----------------
    //                        Damage(hit.transform);
    //                    }
    //                }
                    
    //            }
    //        }
    //    }     
    //}

    private void CheckAbilityTwo()
    {
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            anim.SetTrigger("Hamstring");
        }
    }


    private void CheckAbilityFour()
    {
        //if (timeBtwAttack4 <= 0)
        //{
        //    if (Input.GetKeyDown(KeyCode.Alpha4))
        //    {

        //        timeBtwAttack4 = startTimeBtwAttack4;
        //        anim.SetTrigger("Whirlwind");
        //        dmgAmount = whirlwindDamage;

        //        Collider[] hits = Physics.OverlapSphere(transform.position, sphereRadius);
                
        //        foreach (Collider hit in hits)
        //        {
                    
        //            if (hit.tag == "Player")
        //            {
        //                print("hit " + hit.gameObject);
        //                Damage(hit.transform);
        //            }
        //        }

        //    }
        //}
        //else
        //{
        //    timeBtwAttack4 -= Time.deltaTime;
        //}
    }






}

// HEALTHBAR STUFF -- START

//[Command]
//public void CmdAddPumpkin()
//{
//    NetworkManager.singleton.GetComponent<NetworkManager>().AddObject(5, this.transform);
//}

//void OnGUI()
//{
//    if (isLocalPlayer)
//    {
//        if (Event.current.Equals(Event.KeyboardEvent("0")) ||
//            Event.current.Equals(Event.KeyboardEvent("1")) ||
//            Event.current.Equals(Event.KeyboardEvent("2")) ||
//            Event.current.Equals(Event.KeyboardEvent("3")))
//        {
//            int charid = int.Parse(Event.current.keyCode.ToString().Substring(5)) + 1;
//            NetworkConnection conn = this.connectionToClient;
//            NetworkManager.singleton.GetComponent<CustomNetworkManager>().ChangeCharacters(conn, charid, this.transform);
//            Destroy(this.gameObject);
//        }
//        //-----NEW CODE BELOW TO USE 9 KEY TO CREATE A PUMPKIN -----
//        else if (Event.current.Equals(Event.KeyboardEvent("9")))
//        {
//            NetworkConnection conn = this.connectionToClient;
//            CmdAddPumpkin();
//        }
//        //-----NEW CODE ABOVE------------
//    }
//}



// HEALTHBAR STUFF  -- END




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