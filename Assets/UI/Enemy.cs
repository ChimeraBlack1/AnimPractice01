using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class Enemy : NetworkBehaviour
{
    NetworkAnimator netAnim;

    public float startHealth = 100f;
    //public Slider m_Slider;

    [SyncVar (hook = "OnChangeHealth")]
    public float currentHealth;

    [Header("Do not change")]
    public Image healthBar;

	void Start () {
        currentHealth = startHealth;
        netAnim = GetComponent<NetworkAnimator>();
    }


    public void TakeDamage(float amount)
    {
        //if (isLocalPlayer)
        //{
        //    return;
        //}
        
        currentHealth -= amount;
        healthBar.fillAmount = currentHealth / startHealth;
       
        //this.gameObject.GetComponent<SetupLocalPlayer>().CmdUpdateHealth(currentHealth);

        if (currentHealth <= 0)
        {
            Debug.Log("health is " + currentHealth + "You should be dead now");
            netAnim.SetTrigger("Death");
        }
    }

    void OnChangeHealth(float health)
    {
        healthBar.fillAmount = health / startHealth;
    }




}


//[SyncVar(hook = "OnChangeAnimation")]
//public string animState = "idle";

//void OnChangeAnimation (string aS)
//{
//    if (isLocalPlayer) return;
//    UpdateAnimationState(aS);
//}

//[Command]
//public void CmdChangeMovement(float newX, float newZ)
//{
//    UpdateMovement(newX, newZ);
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