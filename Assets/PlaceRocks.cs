using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceRocks : MonoBehaviour
{
    public GameObject smallRock;
    public GameObject mediumRock;
    public GameObject bigRock;

    public float zMax = 20.0f;
    public float xMin = 10.0f;
    public float xMax = -120.0f;
    void Start()
    {
        SpawnRocks();
    }

    void SpawnRocks(){
        for(int i=0; i<40; i++){
            SpawnRock(smallRock);
            SpawnRock(mediumRock);
            SpawnRock(bigRock);
        }
    }

    void SpawnRock(GameObject rock){
        rock.transform.position = new Vector3(
            Random.Range(xMin,xMax), 
            0.0f, 
            Random.Range(-zMax,zMax)
        );

        Instantiate(rock);
    }

}
