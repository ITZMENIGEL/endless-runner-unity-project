using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject obstaclePrefab;
    public float spawnInterval = 1.25f;
    public float laneWidth = 3f;
    public float spawnZ = 20f;

    private float timer;

    void Update()
    {
        if (GameManager.Instance != null && GameManager.Instance.isGameOver)
            return;

        timer -= Time.deltaTime;

        if (timer <= 0f)
        {
            SpawnObstacle();
            timer = spawnInterval;
        }
    }

    private void SpawnObstacle()
    {
        int lane = Random.Range(0, 3);
        float x = (lane - 1) * laneWidth;

        Vector3 spawnPosition = new Vector3(x, 0.5f, spawnZ);
        GameObject obstacle = Instantiate(obstaclePrefab, spawnPosition, Quaternion.identity);
        obstacle.tag = "Obstacle";
        obstacle.AddComponent<ObstacleMove>();
    }
}
