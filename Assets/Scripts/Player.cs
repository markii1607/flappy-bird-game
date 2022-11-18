using UnityEngine;

public class Player : MonoBehaviour
{
    public Sprite[] sprites;

    public float gravity = -9.8f;
    public float strength = 5f;

    private Vector3 direction;

    private SpriteRenderer spriteRenderer;

    private int spriteIndex;

    private void Awake() {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start() {
        InvokeRepeating(nameof(AnimateSprite), 0.15f, 0.15f);
    }

    private void OnEnable() {
        direction = Vector3.zero;
    }

    private void Update() {
        // key or click input
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)) {
            direction = Vector3.up * strength;
        }

        // touch input
        if (Input.touchCount > 0) { // check how many fingers touch
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began) {
                direction = Vector3.up * strength;
            }
        }

        direction.y += gravity * Time.deltaTime;
        transform.position += direction * Time.deltaTime;
    }

    // Sprite Animation
    private void AnimateSprite() {
        spriteIndex++;

        if (spriteIndex >= sprites.Length) {
            spriteIndex = 0;
        }

        spriteRenderer.sprite = sprites[spriteIndex];
    }

    // triggers
    private void OnTriggerEnter2D(Collider2D other) {
        // Game Over
        if (other.tag == "Obstacle") {
            FindObjectOfType<GameManager>().GameOver();
        }

        // Score
        if (other.tag == "Scoring") {
            FindObjectOfType<GameManager>().IncreaseScore();
        }
    }
}
