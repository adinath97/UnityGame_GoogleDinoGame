using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingDinoSpawner : MonoBehaviour
{
    [SerializeField] List<Transform> instantiationPoints;
    [SerializeField] GameObject flyingDinoPrefab;
    [SerializeField] float moveSpeed = 2f;
    private float timer, timerCap;
    
    // Start is called before the first frame update
    void Start()
    {
        timerCap = Random.Range(0,10f);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(timer > timerCap) {
            timer = 0f;
            timerCap = Random.Range(0,10f);
            int randomPos = Random.Range(0,instantiationPoints.Count);
            GameObject flyingDinoInstance = Instantiate(flyingDinoPrefab,instantiationPoints[randomPos].position,Quaternion.identity);
            flyingDinoInstance.GetComponent<Rigidbody2D>().velocity = new Vector2(-moveSpeed,0f);
        }
    }
}
