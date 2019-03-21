using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class Enemy : NetworkBehaviour
{
    public float startHealth = 100f;
    //public Slider m_Slider;

    [SyncVar (hook = "OnChangeHealth")]
    float currentHealth;

    [Header("Do not change")]
    public Image healthBar;

    private bool m_dead = true;

	void Start () {
        currentHealth = startHealth;
	}


    public void TakeDamage(float amount)
    {
        if (isLocalPlayer)
        {
            return;
        }
        Debug.Log("taking damage");
        currentHealth -= amount;

        

        if (currentHealth <= 0 && !m_dead)
        {
            //die 
        }
    }

    void OnChangeHealth(float health)
    {
        healthBar.fillAmount = health / startHealth;
    }

}
