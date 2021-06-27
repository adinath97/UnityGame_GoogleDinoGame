using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    public void ReloadGame() {
        PlayerController.playerDead = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
