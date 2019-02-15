using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordCollider : MonoBehaviour {

    public GameObject Self;
    public GameObject PlayerSword;

    private void Update()
    {
        Physics.IgnoreCollision(Self.GetComponent<Collider>(), PlayerSword.GetComponent<Collider>());
    }

    private void OnTriggerEnter(Collider other)
    {
        print("hit " + other);
        //other.TakeDamage();
    }

}
