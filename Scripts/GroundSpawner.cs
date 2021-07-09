using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundSpawner : MonoBehaviour
{
    [SerializeField] GameObject groundTile;
    [SerializeField] GameObject tempWithSpawnPoint;
    public static bool allowObstacleProduction;
    public bool rotateUpDownX,closeGap;
    private Vector3 nextSpawnPoint;
    private bool first;
    private float groundmoveSpeed;
    
    // Start is called before the first frame update
    private void Start() {
        allowObstacleProduction = false;
        first = true;
        //nextSpawnPoint = tempWithSpawnPoint.transform.GetChild(1).transform.position;
        for(int i = 0; i < 3; i++) {
            SpawnTile();
        }
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.UpArrow)) {
            allowObstacleProduction = true;
        }
    }

    public void SpawnTile() {
        if(first) {
            first = false;
            GameObject temp = Instantiate(groundTile,nextSpawnPoint,Quaternion.identity);
            tempWithSpawnPoint = temp;
            return;
        }
        else {
            nextSpawnPoint = tempWithSpawnPoint.transform.GetChild(1).transform.position;
            GameObject temp = Instantiate(groundTile,nextSpawnPoint,Quaternion.identity);
            if(allowObstacleProduction) {
                temp.GetComponent<GroundTile>().startObstacleProduction = true;
            }
            tempWithSpawnPoint = temp;
        }
        
    }
}
