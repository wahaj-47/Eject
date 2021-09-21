using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{
    public ParticleSystem Dust;

    private void DestroyParticleSystem(){
        Destroy(Dust);
    }

    private void OnCollisionEnter(Collision other) {
        Dust.Play();
        Destroy(gameObject);

        Invoke("DestroyParticleSystem", 0.5f);
    }
}
