using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flyingDinoInstance : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        if(PlayerController.playerDead) {
            Debug.Log("DONE!");
            this.GetComponent<Animator>().enabled = false;
            this.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        }
    }
}
