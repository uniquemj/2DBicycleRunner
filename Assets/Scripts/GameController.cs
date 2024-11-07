using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class GameController : MonoBehaviour
{
    public TMP_Text scoreText;
    public GameObject gameOverPanel;
    public TMP_Text finalScoreText;
    public PlatformController platformController;
    public PlayerController playerController;

    public int score = 0;
    public bool isGameOver = false;
    public bool gamePaused = true;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0;
        gamePaused = true;
        platformController = GameObject.FindObjectOfType<PlatformController>();
        playerController = GameObject.FindObjectOfType<PlayerController>(); 
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && gamePaused)
        {
            ResumeGame();
        }
        if (!gamePaused)
        {
            UpdateScore();
        }
    }

    void ResumeGame()
    {
        Time.timeScale = 1;
        gamePaused = false;
    }

    void UpdateScore()
    {
        if (!isGameOver)
        {
            score++;
            scoreText.text = score.ToString();
        }
    }

    public void GameOver()
    {
        isGameOver = true;
        gameOverPanel.SetActive(true);
        finalScoreText.text = score.ToString();
        playerController.rb.velocity = Vector2.zero;
        playerController.enabled = false;
        platformController.enabled = false;
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
