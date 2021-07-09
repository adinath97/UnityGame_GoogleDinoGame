using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float moveSpeed = 2f;
    [SerializeField] Sprite idleSprite;
    private Rigidbody2D myRigidbody;
    private Animator myAnim;
    private SpriteRenderer mySpriteRenderer;
    private float minHeight, maxHeight, holdTime;
    private bool allowRise;

    void Start() {
        allowRise = true;
        mySpriteRenderer = this.GetComponent<SpriteRenderer>();
        myAnim = this.GetComponent<Animator>();
        myRigidbody = this.GetComponent<Rigidbody2D>();
        minHeight = this.transform.position.y;
        maxHeight = this.transform.position.y + 2f;
    }

    private void Update() {
        /*
       if(Input.GetKeyDown(KeyCode.Space) && allowRise) {
            myAnim.enabled = false;
            mySpriteRenderer.sprite = idleSprite;
            myRigidbody.velocity = Vector2.zero;
            myRigidbody.velocity = new Vector2(myRigidbody.velocity.x,moveSpeed);
        } 
        if(this.transform.position.y >= maxHeight) {
            Debug.Log("HELLO THERE!");
            allowRise = false;
        }
        if(Input.GetKeyUp(KeyCode.Space)) {
            if(allowRise) {
                allowRise = false;
            }
        }
        */
    }

    void OnCollisionEnter2D(Collision2D collisionInfo) {
        /*
        if(!myAnim.enabled) {
            myAnim.enabled = true;
        }
        if(collisionInfo.gameObject.tag == "ground" && !allowRise) {
            allowRise = true;
        }
        */
    }
}
