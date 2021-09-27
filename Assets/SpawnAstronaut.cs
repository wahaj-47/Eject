using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class SpawnAstronaut : MonoBehaviour
{
    private int count = 0;
    public List<GameObject> Astronauts;
    public GameObject FlyingAstronaut;

    public float offset = 0.7f;

    void OnTriggerEnter(Collider other) {
        if(other.gameObject.CompareTag("Collectible")){
            Destroy(other.gameObject);
            Astronauts[count].SetActive(true);
            count++;
        } 
    }

    private void OnCollisionEnter(Collision other) {
        if(count > 0){
            Debug.Log(count);
            count--;

            FlyingAstronaut.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);
            GameObject SpawnedAstronaut = Instantiate(FlyingAstronaut);
            SpawnedAstronaut.transform.DOMove(new Vector3(FlyingAstronaut.transform.position.x,3.0f,Random.Range(-1.5f, 1.5f)), 5f);
            SpawnedAstronaut.transform.DORotate(new Vector3(Random.Range(-90f, 90f),Random.Range(-90f, 90f),Random.Range(-90f, 90f)), 2f);

            Astronauts[count].SetActive(false);
            
        }

    }
}
