using UnityEngine;

public class ObstacleMove : MonoBehaviour
{
    public float speed = 8f;

    void Update()
    {
        if (GameManager.Instance != null && GameManager.Instance.isGameOver)
            return;

        transform.position += Vector3.back * speed * Time.deltaTime;
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
