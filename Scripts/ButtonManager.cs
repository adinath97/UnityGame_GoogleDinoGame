using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    [SerializeField] GameObject endFade;
    [SerializeField] AudioClip buttonPressSound;
    private AudioSource myAudioSource;

    void Awake()
    {
        myAudioSource = this.GetComponent<AudioSource>();
        endFade.SetActive(false);
    }
    
    public void ReloadGame() {
        myAudioSource.PlayOneShot(buttonPressSound);
        StartCoroutine(ReLoadGameScene());
    }

    private IEnumerator ReLoadGameScene() {
        endFade.SetActive(true);
        yield return new WaitForSeconds(1f);
        PlayerController.playerDead = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
