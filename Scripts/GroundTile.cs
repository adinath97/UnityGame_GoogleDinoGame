using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundTile : MonoBehaviour
{
    [SerializeField] List<GameObject> obstaclePrefabs;
    public float moveSpeed = .5f;
    public bool startObstacleProduction;
    private bool destroyCommandSent;
    private int rand1,rand2;
    GameObject obstacleInstance1,obstacleInstance2,obstacleInstance3;
    GroundSpawner groundSpawner;
    
    // Start is called before the first frame update
    void Start()
    {
        destroyCommandSent = false;
        groundSpawner = GameObject.FindObjectOfType<GroundSpawner>();
        rand1 = Mathf.RoundToInt(Random.Range(0,1f));
        rand2 = Mathf.RoundToInt(Random.Range(0,1f));
        this.moveSpeed = ScoreManager.correctedMoveSpeed;
        if(startObstacleProduction) {
            int randX = Random.Range(0,obstaclePrefabs.Count);
            /*
            if(rand1 == rand2) {
                obstacleInstance1 = Instantiate(obstaclePrefabs[randX],this.transform.GetChild(2).transform.position,Quaternion.identity);
                obstacleInstance1.transform.parent = this.gameObject.transform; //make column a child of the parent ground tile
                if(obstacleInstance1.gameObject.tag == "flyingDino") {
                    int rand4 = Mathf.RoundToInt(Random.Range(0,3f));
                    if(rand4 == 0) {
                        obstacleInstance1.transform.position += new Vector3(0,1f,0);
                    }
                    else if(rand4 == 1) {
                        obstacleInstance1.transform.position += new Vector3(0,.7f,0);
                    }
                    else if(rand4 == 2) {
                        obstacleInstance1.transform.position += new Vector3(0,1.4f,0);
                    }
                }
                rand1 = Mathf.RoundToInt(Random.Range(0,1f));
                rand2 = Mathf.RoundToInt(Random.Range(0,1f));
            }
            */
            if(rand1 == rand2) {
                randX = Random.Range(0,obstaclePrefabs.Count);
                obstacleInstance2 = Instantiate(obstaclePrefabs[randX],this.transform.GetChild(3).transform.position,Quaternion.identity);
                obstacleInstance2.transform.parent = this.gameObject.transform; //make column a child of the parent ground tile
                if(obstacleInstance2.gameObject.tag == "flyingDino") {
                    int rand4 = Mathf.RoundToInt(Random.Range(0,3f));
                    if(rand4 == 0) {
                        obstacleInstance2.transform.position += new Vector3(0,.6f,0);
                    }
                    else if(rand4 == 1) {
                        obstacleInstance2.transform.position += new Vector3(0,.4f,0);
                    }
                    else if(rand4 == 2) {
                        obstacleInstance2.transform.position += new Vector3(0,.2f,0);
                    }
                }
                rand1 = Mathf.RoundToInt(Random.Range(0,1f));
                rand2 = Mathf.RoundToInt(Random.Range(0,1f));
            }
            /*
            if(rand1 == rand2) {
                randX = Random.Range(0,obstaclePrefabs.Count);
                obstacleInstance3 = Instantiate(obstaclePrefabs[randX],this.transform.GetChild(4).transform.position,Quaternion.identity);
                obstacleInstance3.transform.parent = this.gameObject.transform; //make column a child of the parent ground tile
                if(obstacleInstance3.gameObject.tag == "flyingDino") {
                    int rand4 = Mathf.RoundToInt(Random.Range(0,3f));
                    if(rand4 == 0) {
                        obstacleInstance3.transform.position += new Vector3(0,1f,0);
                    }
                    else if(rand4 == 1) {
                        obstacleInstance3.transform.position += new Vector3(0,.7f,0);
                    }
                    else if(rand4 == 2) {
                        obstacleInstance3.transform.position += new Vector3(0,1.4f,0);
                    }
                }
                rand1 = Mathf.RoundToInt(Random.Range(0,1f));
                rand2 = Mathf.RoundToInt(Random.Range(0,1f));
            }
            */
        }
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position += new Vector3(-moveSpeed * Time.deltaTime * 8f,0,0); //make framerate independent
        if(PlayerController.playerDead) {
            moveSpeed = 0;
        }
        /*
        if(bean.playerDead) {
            CancelInvoke("DestroySelf");
        }
        */
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player" && !destroyCommandSent) {
            destroyCommandSent = true;
            groundSpawner.SpawnTile();
            Invoke("DestroySelf",10.0f);
        }
    }

    private void DestroySelf() {
        if(!PlayerController.playerDead) {
            Destroy(this.gameObject);
        }
    }
}
