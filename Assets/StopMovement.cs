using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopMovement : MonoBehaviour
{
    private bool levelEnded = false;
    public GameObject player;
    public Rigidbody rb;
    public GameObject endCanvas;
    private PlayerMovement movementScript;
    private void Awake() {
        movementScript = player.GetComponent<PlayerMovement>();
    }
    private void OnTriggerEnter(Collider other) {
        if(other.CompareTag("End")){
            levelEnded = true;
            endCanvas.SetActive(true);
            movementScript.enabled = false;
            rb.drag = 0.5f;
            FindObjectOfType<AudioManager>().StopPlaying("EngineRunning");
            FindObjectOfType<AudioManager>().Play("EngineIdle");
        }
    }

    private void Update() {
        if (levelEnded){
            if(Input.touchCount>0 || Input.anyKeyDown){
                FindObjectOfType<LevelLoader>().LoadNextLevel();
            }
        }
    }
}
