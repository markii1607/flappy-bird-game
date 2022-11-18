using System.Collections;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public Player player;
    public TextMeshProUGUI scoreText;
    public GameObject playButton;
    public GameObject gameOver;
    public GameObject getReady;

    public float delayTime = 1f;

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
        getReady.SetActive(true);

        Time.timeScale = 1f;

        // reset the position of the player when enabled
        Vector3 position = player.transform.position;
        position.y = 0f;
        player.transform.position = position;

        // Destroy all obstacles in the screen
        Obstacles[] obstacles = FindObjectsOfType<Obstacles>();
        for (int i = 0; i < obstacles.Length; i++) {
            Destroy(obstacles[i].gameObject);
        }

        StartCoroutine(delaySpawn(delayTime));
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

    IEnumerator delaySpawn(float delayTime) {
        Debug.Log("Started Coroutine at timestamp : " + Time.time);
        yield return new WaitForSeconds(delayTime);
        getReady.SetActive(false);
        player.enabled = true;
        Debug.Log("Finished Coroutine at timestamp : " + Time.time);
    }
}
