using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody rb;
    public float forwardForce = 200f;

    private Vector2 fingerDownPos;
	private Vector2 fingerUpPos;

	public bool detectSwipeAfterRelease = false;

	public float SWIPE_THRESHOLD = 20f;

    void DetectSwipe ()
	{
        if (HorizontalMoveValue () > SWIPE_THRESHOLD) {
			Debug.Log ("Horizontal Swipe Detected!");
			if (fingerDownPos.x - fingerUpPos.x > 0) {
				OnSwipeRight ();
			} else if (fingerDownPos.x - fingerUpPos.x < 0) {
				OnSwipeLeft ();
			}
			fingerUpPos = fingerDownPos;

		} else {
			Debug.Log ("No Swipe Detected!");
		}
	}

    float HorizontalMoveValue ()
	{
		return Mathf.Abs (fingerDownPos.x - fingerUpPos.x);
	}

    private void Update() {
         if(Input.touchCount > 0){
            foreach (Touch touch in Input.touches) {
                if (touch.phase == TouchPhase.Began) {
                    fingerUpPos = touch.position;
                    fingerDownPos = touch.position;
                }

                //Detects Swipe while finger is still moving on screen
                if (touch.phase == TouchPhase.Moved) {
                    if (!detectSwipeAfterRelease) {
                        fingerDownPos = touch.position;
                        DetectSwipe ();
                    }
                }

                //Detects swipe after finger is released from screen
                if (touch.phase == TouchPhase.Ended) {
                    fingerDownPos = touch.position;
                    DetectSwipe ();
                }
            }
        }
    }

    private void FixedUpdate() {
        rb.AddForce(-forwardForce*Time.deltaTime, 0, 0);
    }

    void OnSwipeLeft ()
	{
		//Do something when swiped left
        transform.DOMoveZ(transform.position.z-1.5f, 0.3f);
	}

	void OnSwipeRight ()
	{
		//Do something when swiped right
        transform.DOMoveZ(transform.position.z+1.5f, 0.3f);
	}

}
