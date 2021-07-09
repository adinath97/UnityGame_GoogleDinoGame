using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudSpawner : MonoBehaviour
{
    [SerializeField] List<Transform> instantiationPoints;
    [SerializeField] GameObject cloudPrefab;
    [SerializeField] float moveSpeed = 3f;
    private float timer, timerCap;
    
    // Start is called before the first frame update
    void Start()
    {
        timerCap = Random.Range(0,5f);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(timer > timerCap) {
            timer = 0f;
            timerCap = Random.Range(0,5f);
            int randomPos = Random.Range(0,instantiationPoints.Count);
            GameObject cloudInstance = Instantiate(cloudPrefab,instantiationPoints[randomPos].position,Quaternion.identity);
            cloudInstance.GetComponent<Rigidbody2D>().velocity = new Vector2(-moveSpeed,0f);
        }
    }
}
