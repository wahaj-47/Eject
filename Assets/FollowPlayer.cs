using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class FollowPlayer : MonoBehaviour
{
    public GameObject UI;
    public Vector3 offset;
    public Transform player;

    private void Start() {
        transform.DOMove(player.position + offset, 3.0f).From(transform.position);
        // Invoke("StartMovement", 3.1f);
    }

    // Update is called once per frame
    void Update()
    {
        if(!UI.activeSelf)
            transform.position = player.position + offset;
    }
}
