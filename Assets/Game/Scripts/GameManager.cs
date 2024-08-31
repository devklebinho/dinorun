using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    public static GameManager instance;


    [Header("UI")]
    [SerializeField] TMP_Text scoreText;

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

    private float score = 0f;
    void Start()
    {
        ResetScore();
    }

    void Update()
    {
        scoreText.text = score.ToString();
    }

    #region Score Methods
    public void AddScore(float amount)
    {
        score += amount;
    }

    public void SubtractScore(float amount)
    {
        score -= amount;
    }

    public void ResetScore()
    {
        score = 0f;
    }
    #endregion

}
