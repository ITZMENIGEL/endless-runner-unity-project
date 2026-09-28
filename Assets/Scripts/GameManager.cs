using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverText;
    public GameObject player;
    public bool isGameOver = false;

    private int score;

    private void Awake()
    {
        Instance = this;
    }

    private void Update()
    {
        if (isGameOver)
        {
            if (Input.GetKeyDown(KeyCode.R))
                RestartGame();
            return;
        }

        if (scoreText != null)
            scoreText.text = "Score: " + score;
    }

    public void AddScore(int amount)
    {
        if (isGameOver)
            return;

        score += amount;
    }

    public void EndGame()
    {
        if (isGameOver)
            return;

        isGameOver = true;

        if (gameOverText != null)
            gameOverText.gameObject.SetActive(true);

        Time.timeScale = 0f;
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
