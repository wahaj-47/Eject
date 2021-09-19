using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody rb;
    public float forwardForce = 200f;
    private Touch touch;

    // Update is called once per frame
    private void FixedUpdate() {
        rb.AddForce(-forwardForce*Time.deltaTime, 0, 0);

        if(Input.touchCount > 0){

            touch  = Input.GetTouch(0);

            if(touch.phase == TouchPhase.Moved){
                rb.AddForce(0, forwardForce*Time.deltaTime, 0);
            }

        }
    }

}
