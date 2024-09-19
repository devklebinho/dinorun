using UnityEngine.SceneManagement;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public bool isGameActive;
    private bool isGameEnd;

    [Header("UI")]
    [SerializeField] TMP_Text scoreText;
    [SerializeField] GameObject endGamePanel;
    //[SerializeField] Button restartButton;

    private float score = 0f;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        
    }

    void Start()
    {
        Time.timeScale = 1f;
        isGameActive = true;
        isGameEnd = false;
        endGamePanel.SetActive(false);
        ResetScore();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            
            if (isGameActive && !isGameEnd)
            {
                PauseGame();
            }
            else if (!isGameActive && !isGameEnd)
            {
                ResumeGame();
            }

            if (isGameEnd && Input.GetKeyDown(KeyCode.R))
            {
                ResetGame();
            }

        }
    }

    #region Basic System
    public void PauseGame()
    {
        if (!isGameEnd) 
        {
            Time.timeScale = 0f;
            isGameActive = false;
        }
    }

    public void ResumeGame()
    {
        if (!isGameEnd)
        {
            Time.timeScale = 1f;
            isGameActive = true;
        }
    }

    public void ResetGame()
    {
        /*
        ResetScore();
        isGameActive = true;
        isGameEnd = false;
        Time.timeScale = 1f;
        endGamePanel.SetActive(false);
        */
        SceneManager.LoadScene("Game");
    }

    public void EndGame()
    {
        PauseGame();
        isGameActive = false;
        isGameEnd = true;
        endGamePanel.SetActive(true);
    }
    #endregion

    #region Score Methods
    public void AddScore(float amount)
    {
        score += amount;
        scoreText.text = score.ToString(); 
    }

    public void SubtractScore(float amount)
    {
        score -= amount;
        scoreText.text = score.ToString(); 
    }

    public void ResetScore()
    {
        score = 0f;
        scoreText.text = score.ToString(); 
    }
    #endregion
}
