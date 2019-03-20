using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class SetupLocalPlayer : NetworkBehaviour {


    Animator anim;

    [SyncVar(hook = "OnChangeAnimation")]
    public string animState = "idle";

    void OnChangeAnimation (string aS)
    {
        if (isLocalPlayer) return;
        UpdateAnimationState(aS);
    }

    [Command]
    public void CmdChangeAnimState(string aS)
    {
        UpdateAnimationState(aS);     
    }

    void UpdateAnimationState(string aS)
    {
        if (animState == aS) return;
        animState = aS;
        Debug.Log(animState);

        if(animState == "Moving")
        {
            //anim.SetFloat("VelY", z * 10);
            //anim.SetFloat("VelX", x * 10);
        }else if (animState == "Cleave")
        {
            anim.SetTrigger("Cleave");
        }else if (animState == "Whirlwind")
        {
            anim.SetTrigger("Whirlwind");
        }else if (animState == "Sprint")
        {
            anim.SetTrigger("Sprint");
        }else if(animState == "Hamstring")
        {
            anim.SetTrigger("Hamstring");
        }

    }

	// Use this for initialization
	void Start () {

        anim = GetComponentInChildren<Animator>();

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
		
	}
}
