using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour {


    public float startHealth = 100f;
    private float health;

    [Header("Unity Stuff")]
    public Image healthBar;

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

        if (health <= 0)
        {
            //die 
        }
    }

}
