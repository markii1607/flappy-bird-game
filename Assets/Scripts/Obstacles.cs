using UnityEngine;

public class Obstacles : MonoBehaviour
{
    public float speed = 5;

    private float leftEdgeOfScreen;

    private void Start() {
        // calculate edge of screen
        leftEdgeOfScreen = Camera.main.ScreenToWorldPoint(Vector3.zero).x - 1;
    }

    private void Update() {
        transform.position += Vector3.left * speed * Time.deltaTime;

        // destroy obstacle if it reached leftmost of the screen
        if (transform.position.x < leftEdgeOfScreen) {
            Destroy(gameObject);
        }
    }
}
