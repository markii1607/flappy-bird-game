using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public Player player;
    public TextMeshProUGUI scoreText;
    public GameObject playButton;
    public GameObject gameOver;

    private int score;

    private void Awake() {
        Application.targetFrameRate = 60;
        Pause();
    }

    public void Play() {
        
    }

    public void Pause() {
        // simulate pause
        Time.timeScale = 0f;

        player.enabled = false;
    }

    public void IncreaseScore() {
        score++;

        scoreText.SetText(score.ToString());
    }

    public void GameOver() {
        gameOver.SetActive(true);
        playButton.SetActive(true);

        Pause();
    }
}
