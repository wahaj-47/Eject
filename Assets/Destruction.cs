using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MilkShake;

public class Destruction : MonoBehaviour
{
    public Rigidbody rb;
    public Shaker MyShaker;
    public ShakePreset ShakePreset;

    private void OnCollisionEnter(Collision other) {
        // Add extra force to resume faster
        rb.AddForce(-1000*Time.deltaTime, 0, 0);

        //Shake camera
        MyShaker.Shake(ShakePreset);
       
    }

}
