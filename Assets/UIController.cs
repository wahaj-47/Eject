using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIController : MonoBehaviour
{
    public GameObject cameraContainer;
    public GameObject player;
    private Vector3 offset;
    private PlayerMovement movementScript;
    private Floater floaterScript; 
    private Vector3 playerStartPosition;

    private void StartMovement(){
        movementScript.enabled = true;
        floaterScript.enabled = false;
        FindObjectOfType<AudioManager>().StopPlaying("EngineIdle");
        FindObjectOfType<AudioManager>().Play("EngineRunning");
    }

    private void Awake() {
        movementScript = player.GetComponent<PlayerMovement>();
        floaterScript = player.GetComponent<Floater>();
        playerStartPosition = player.transform.position;
        offset = cameraContainer.GetComponent<FollowPlayer>().offset;
    }

    private void Start() {
        FindObjectOfType<AudioManager>().Play("EngineStart");
        FindObjectOfType<AudioManager>().Play("EngineIdle");
    }
    
    // Update is called once per frame
    private void Update() {
        if(cameraContainer.transform.position == playerStartPosition + offset){
            if(Input.touchCount>0 || Input.anyKeyDown){
                gameObject.SetActive(false);
                StartMovement();
            }
        }
    }
}
