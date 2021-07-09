using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static float playerScore;
    public static float correctedMoveSpeed;
    [SerializeField] GameObject titleBox;
    [SerializeField] GameObject scoreBox;
    [SerializeField] GameObject highScoreBox;
    [SerializeField] GameObject HIBox;
    [SerializeField] GameObject gameOverBtn;
    [SerializeField] GameObject instructionsBox;
    [SerializeField] GameObject gameOverBox;
    [SerializeField] GameObject creditsBox;
    [SerializeField] GameObject startFade;
    private float timer;
    private bool beginGame;
    private Text score;
    
    void Awake()
    {
        StartCoroutine(StartFadeAnim());
    }

    // Start is called before the first frame update
    void Start()
    {
        beginGame = false;
        instructionsBox.GetComponent<Animator>().enabled = false;
        creditsBox.GetComponent<Animator>().enabled = false;
        titleBox.GetComponent<Animator>().enabled = false;
        instructionsBox.SetActive(true);
        creditsBox.SetActive(true);
        titleBox.SetActive(true);
        scoreBox.SetActive(false);
        gameOverBox.SetActive(false);
        gameOverBtn.SetActive(false);
        highScoreBox.SetActive(false);
        HIBox.SetActive(false);
        highScoreBox.GetComponent<Text>().text = Mathf.RoundToInt(PlayerPrefs.GetFloat("HighScore",0f)).ToString();
        playerScore = 0;
        timer = 0;
        correctedMoveSpeed = .5f;
        score = scoreBox.GetComponent<Text>();
    }

    private IEnumerator StartFadeAnim() {
        startFade.SetActive(true);
        yield return new WaitForSeconds(1f);
        startFade.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(!PlayerController.playerDead && this.beginGame) {
            StartCoroutine(FadeOutStartingMaterial());
            playerScore += Time.deltaTime;
            score.text = Mathf.RoundToInt(playerScore).ToString();
        }
        if(GroundSpawner.allowObstacleProduction) {
            this.beginGame = true;
            timer += Time.deltaTime;
        }
        if(timer > 20f && correctedMoveSpeed < 1.5f) {
            timer = 0;
            correctedMoveSpeed += .1f;
        }
        if(playerScore > PlayerPrefs.GetFloat("HighScore",0f)) {
            PlayerPrefs.SetFloat("HighScore",playerScore);
            highScoreBox.GetComponent<Text>().text = Mathf.RoundToInt(PlayerPrefs.GetFloat("HighScore",0f)).ToString();
        }
        if(PlayerController.playerDead) {
            gameOverBtn.SetActive(true);
            gameOverBox.SetActive(true);
        }
    }

    private IEnumerator FadeOutStartingMaterial() {
        instructionsBox.GetComponent<Animator>().enabled = true;
        creditsBox.GetComponent<Animator>().enabled = true;
        titleBox.GetComponent<Animator>().enabled = true;
        yield return new WaitForSeconds(1f);
        instructionsBox.SetActive(false);
        creditsBox.SetActive(false);
        titleBox.SetActive(false);
        scoreBox.SetActive(true);
        if(PlayerPrefs.GetFloat("HighScore",0f) > 0) {
            highScoreBox.SetActive(true);
            HIBox.SetActive(true);
        }
    }
}
