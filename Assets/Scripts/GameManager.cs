using UnityEngine;
using UnityEngine.UI; 
using UnityEngine.SceneManagement;
using TMPro;
public class GameManager : MonoBehaviour
{
    public float survivalTime = 30f; // Waktu untuk bertahan hidup
    private float timer;
    private bool isGameOver = false;

    [Header("UI Elements")]
    public GameObject winPanel;
    public GameObject gameOverPanel;
    public TextMeshProUGUI timerText;

    [Header("Audio")]
    public AudioSource audioSource;
    public AudioClip winSound;
    public AudioClip loseSound;
    public AudioClip backgroundMusic;

    void Start()
    {
        timer = survivalTime;
        winPanel.SetActive(false);
        gameOverPanel.SetActive(false);
        Time.timeScale = 1f;
        audioSource.clip = backgroundMusic;
        audioSource.loop = true;
        audioSource.Play();
    }

    void Update()
    {
        if (isGameOver)
        {
            return;
        }

        // Hitung mundur timer
        timer -= Time.deltaTime;
        timerText.text = " bertahan: " + Mathf.Max(0, timer).ToString("0.0");

        if (timer <= 0)
        {
            GameWin();
        }
    }

    public void GameWin()
    {
        if (isGameOver) return; 
        isGameOver = true;
        Debug.Log("YOU WIN!");
        winPanel.SetActive(true);
        audioSource.clip = winSound;
        audioSource.loop = true;
        audioSource.Play();
        Time.timeScale = 0f; 
    }

    public void GameOver()
    {
        if (isGameOver) return;

        isGameOver = true;
        Debug.Log("GAME OVER!");
        gameOverPanel.SetActive(true);
        audioSource.clip = loseSound;
        audioSource.loop = true;
        audioSource.Play(); 
        Time.timeScale = 0f;
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenuScene");
        audioSource.Stop();
    }
}
