using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordCollider : MonoBehaviour {

    //private void OnTriggerEnter(Collider other)
    //{
    //    print("hit " + other);
    //    
    //}

    public float sphereRadius = 100f;

    private void OnTriggerEnter(Collider other)
    {
        // Play a noise if an object is within the sphere's radius.
        if (Physics.CheckSphere(other.transform.position, sphereRadius))
        {
            print("hit" + other);
            print(other.transform.position);
        }
    }

}
