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
        score = 0;
        scoreText.SetText(score.ToString());

        gameOver.SetActive(false);
        playButton.SetActive(false);

        Time.timeScale = 1f;
        player.enabled = true;

        // Destroy all obstacles in the screen
        Obstacles[] obstacles = FindObjectsOfType<Obstacles>();
        for (int i = 0; i < obstacles.Length; i++) {
            Destroy(obstacles[i].gameObject);
        }
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
