using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject obstaclePrefab;
    public GameObject coinPrefab;
    public float spawnInterval = 1.2f;
    public float laneWidth = 3f;
    public float spawnZ = 20f;

    private float timer;

    private void Update()
    {
        if (GameManager.Instance != null && GameManager.Instance.isGameOver)
            return;

        timer -= Time.deltaTime;

        if (timer <= 0f)
        {
            SpawnPattern();
            timer = spawnInterval;
        }
    }

    private void SpawnPattern()
    {
        int lane = Random.Range(0, 3);
        float x = (lane - 1) * laneWidth;

        Vector3 obstaclePos = new Vector3(x, 0.5f, spawnZ);
        GameObject obstacle = Instantiate(obstaclePrefab, obstaclePos, Quaternion.identity);
        obstacle.tag = "Obstacle";
        obstacle.AddComponent<ObstacleMove>();

        if (coinPrefab != null)
        {
            int coinLane = Random.Range(0, 3);
            float coinX = (coinLane - 1) * laneWidth;
            Vector3 coinPos = new Vector3(coinX, 1.0f, spawnZ - 2f);
            GameObject coin = Instantiate(coinPrefab, coinPos, Quaternion.identity);
            coin.tag = "Coin";
            coin.AddComponent<CoinPickup>();
        }
    }
}
