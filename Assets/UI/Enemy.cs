using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour {


    public float startHealth = 100f;
    public Slider m_Slider;
    private float health;

    [Header("Do not change")]
    public Image healthBar;

    private bool m_dead = true;

	void Start () {
        health = startHealth;
	}

	// Update is called once per frame
	void Update () {
		
	}

    public void TakeDamage(float amount)
    {
        health -= amount;

        healthBar.fillAmount = health / startHealth;

        if (health <= 0 && !m_dead)
        {
            //die 
        }
    }

}
