using UnityEngine;

public class GameManager : MonoBehaviour
{
    private int score;

    private void IncreaseScore() {
        score++;
    }

    private void GameOver() {
        Debug.Log("Game Over");
    }
}
