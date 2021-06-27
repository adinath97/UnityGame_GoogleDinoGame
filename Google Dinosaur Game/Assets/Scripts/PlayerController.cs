using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] Sprite idleSprite;
    public static bool playerDead;
    private Animator myAnim;
    private SpriteRenderer mySpriteRenderer;

    public float speed;
    public float jumpForce;
    private Rigidbody2D myRigidbody;
    private BoxCollider2D myBoxCollider;
    private float moveInput;
     
    private bool isGrounded, isJumping, isCrouching;
    public Transform feetPos;
    public float checkRadius;

    public LayerMask whatIsGround;

    private float jumpTimerCounter, crouchTimer;
    public float jumpTime;
    
    // Start is called before the first frame update
    void Start()
    {
        mySpriteRenderer = this.GetComponent<SpriteRenderer>();
        myAnim = this.GetComponent<Animator>();
        myRigidbody = this.GetComponent<Rigidbody2D>();
        myBoxCollider = this.GetComponent<BoxCollider2D>();
        isGrounded = true;
        isCrouching = false;
        playerDead = false;
    }

    void Update()
    {
        //detect whether player is grounded by checking within a certain radius around the feet
        //isGrounded = Physics2D.OverlapCircle(feetPos.position,checkRadius,whatIsGround);
        if(isGrounded && Input.GetKeyDown(KeyCode.UpArrow) && !isCrouching) {
            myAnim.enabled = false;
            mySpriteRenderer.sprite = idleSprite;
            isGrounded = false;
            isJumping = true;
            jumpTimerCounter = jumpTime;
            myRigidbody.velocity = Vector2.up * jumpForce;
        }

        if(Input.GetKey(KeyCode.UpArrow) && isGrounded && !isCrouching) {
            myAnim.enabled = false;
            mySpriteRenderer.sprite = idleSprite;
            isGrounded = false;
            isJumping = true;
            jumpTimerCounter = jumpTime;
            myRigidbody.velocity = Vector2.up * jumpForce;
        }

        //jump higher (up to a certain limit) if player is holding space key down
        if(Input.GetKey(KeyCode.UpArrow) && isJumping) {
            if(jumpTimerCounter > 0) {
                myRigidbody.velocity = Vector2.up * jumpForce;
                jumpTimerCounter -= Time.deltaTime;
            } else {
                isJumping = false;
            }
        }

        if(Input.GetKeyUp(KeyCode.UpArrow)) {
            isJumping = false;
        }

        if(Input.GetKey(KeyCode.DownArrow) && !isCrouching) {
            if(crouchTimer == 0 && !playerDead) {
                myBoxCollider.size = new Vector3(.59f,.31f);
            }
            crouchTimer+= Time.deltaTime;
            isCrouching = true;
            myAnim.SetBool("Crouching",true);
        }

        if(Input.GetKeyUp(KeyCode.DownArrow) && isCrouching) {
            crouchTimer = 0;
            myBoxCollider.size = new Vector3(.44f,.47f);
            isCrouching = false;
            myAnim.SetBool("Crouching",false);
        }
    }

    void OnCollisionEnter2D(Collision2D collisionInfo)
    {
        if(!playerDead) {
            isGrounded = true;
            myAnim.enabled = true;
        }
        

        if(collisionInfo.gameObject.tag != "ground") {
            playerDead = true;
            myAnim.enabled = false;
            isGrounded = false;
            isJumping = false;
            isCrouching = false;
            //myRigidbody.constraints = Rigidbody2DConstraints.FreezePositionX;
            Destroy(myRigidbody);
            //this.GetComponent<BoxCollider2D>().enabled = false;
        }
    }
}
