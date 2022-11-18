using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject prefabObstacle;

    public float spawnRate = 1f;
    public float minHeight = -1f;
    public float maxHeight = 1f;

    private void OnEnable() {
        InvokeRepeating(nameof(SpawnObstacle), spawnRate, spawnRate);
    }

    private void OnDisable() {
        CancelInvoke(nameof(SpawnObstacle));
    }

    private void SpawnObstacle() {
        // clone each obstacle
        GameObject obstacles = Instantiate(prefabObstacle, transform.position, Quaternion.identity);
        obstacles.transform.position += Vector3.up * Random.Range(minHeight, maxHeight);
    }
}
