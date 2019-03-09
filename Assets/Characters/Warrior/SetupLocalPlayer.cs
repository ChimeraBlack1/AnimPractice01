using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class SetupLocalPlayer : NetworkBehaviour {

	// Use this for initialization
	void Start () {
        if (isLocalPlayer)
        {
            GetComponent<knightControls>().enabled = true;
        }
        else
        {
            GetComponent<knightControls>().enabled = false;
        }

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
