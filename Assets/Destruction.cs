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

        if(!other.gameObject.CompareTag("Collectible")){
            rb.AddForce(5,0,0);
            //Shake camera
            MyShaker.Shake(ShakePreset);
            FindObjectOfType<AudioManager>().Play("Crash");
        }
       
    }

}
