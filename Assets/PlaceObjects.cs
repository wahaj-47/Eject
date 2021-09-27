using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceObjects : MonoBehaviour
{   
    public GameObject obstacle;
    public float xOffsetObstacle = 7.0f;
    public float yPositionObstacle = 0.0f;
    public int countObstacle = 20;
    private float lastSpawnedXObstacle = 10;
    private float lastSpawnedZObstacle = 0.0f;

    private List<float> obstaclePositionsX = new List<float>();

    public GameObject collectible;
    public float xOffsetCollectible = 21.0f;
    public float yPositionCollectible = 0.5f;
    public int countCollectible = 6;
    private float lastSpawnedXCollectible = 10;
    private float lastSpawnedZCollectible = 0.0f;

    private float[] possibleZValues = {0.0f,1.5f,-1.5f};
    public int countPerRow = 1;

    // Start is called before the first frame update
    void Awake()
    {
        lastSpawnedZObstacle = possibleZValues[Random.Range(0,3)];
        lastSpawnedZCollectible = possibleZValues[Random.Range(0,3)];

        for(int i=0; i<countObstacle; i++){
            for(int j=0; j<Random.Range(1,countPerRow+1); j++){
                SpawnObstacle();
            }
            lastSpawnedXObstacle = lastSpawnedXObstacle - xOffsetObstacle;
        }
        for(int i=0; i<countCollectible; i++){
            SpawnCollectible();
        }
    }
    void SpawnObstacle(){

        float PositionZ = lastSpawnedZObstacle;

        while(PositionZ == lastSpawnedZObstacle){
            PositionZ = possibleZValues[Random.Range(0,3)];
        }

        obstacle.transform.position = new Vector3(
            lastSpawnedXObstacle - xOffsetObstacle, 
            yPositionObstacle,
            PositionZ
        );

        lastSpawnedZObstacle = PositionZ;
        obstaclePositionsX.Add(lastSpawnedXObstacle - xOffsetObstacle);

        Instantiate(obstacle);
    }

    void SpawnCollectible(){

        float PositionZ = lastSpawnedZCollectible;
        float PositionX = lastSpawnedXCollectible - xOffsetCollectible;

        while(PositionZ == lastSpawnedZCollectible){
            PositionZ = possibleZValues[Random.Range(0,3)];
        }

        while(obstaclePositionsX.Contains(PositionX)){
            PositionX = PositionX - 3;
        }

        collectible.transform.position = new Vector3(
            PositionX, 
            yPositionCollectible,
            PositionZ
        );

        lastSpawnedZCollectible = PositionZ;
        lastSpawnedXCollectible = PositionX;

        Instantiate(collectible);
    }

}
