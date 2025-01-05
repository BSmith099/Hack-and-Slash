using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public bool gameOver;

    [SerializeField] TMP_Text scoreText;

    [SerializeField] GameObject pauseText;

    int score;

    private float fixedDeltaTime;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        this.fixedDeltaTime = Time.fixedDeltaTime;

        if(pauseText != null)
        {
            pauseText.SetActive(false);
        }

        gameOver = false;
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score.ToString();
        }   
    }

    public void GameOver()
    {
        StartCoroutine(GameOverCoroutine());    
    }

    public void UpdateScore(int points)
    {
        if(scoreText != null)
        {
            score += points;
        }  
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void GoToMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void QuitGame()
    {
        print("I Quit!");
        Application.Quit();
    }

    public void PauseGame()
    {
        if (Time.timeScale == 1.0f)
        {
            pauseText.SetActive(true);
            Time.timeScale = 0f;
        }
        else
        {
            pauseText.SetActive(false);
            Time.timeScale = 1f;
        }

        // Adjust fixed delta time according to timescale
        // The fixed delta time will now be 0.02 real-time seconds per frame
        Time.fixedDeltaTime = this.fixedDeltaTime * Time.timeScale;
    }

    private IEnumerator GameOverCoroutine()
    {
        gameOver = true;
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(2);
    }
}
