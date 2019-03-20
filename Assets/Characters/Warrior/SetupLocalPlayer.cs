using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class SetupLocalPlayer : NetworkBehaviour {


    NetworkAnimator anim;



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
		if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            anim.SetTrigger("Cleave");
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