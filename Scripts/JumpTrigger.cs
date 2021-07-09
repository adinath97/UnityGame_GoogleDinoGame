using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpTrigger : MonoBehaviour
{
    [SerializeField] AudioClip jumpAudio;
    private AudioSource myAudioSource;
    private int counter;

    void Awake()
    {
        myAudioSource = this.GetComponent<AudioSource>();
        counter = 1;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player") {
            counter++;
            if(counter % 2 == 0) {
                Debug.Log("JUMPING");
                //myAudioSource.PlayOneShot(jumpAudio);
            }
        }
    }
}
