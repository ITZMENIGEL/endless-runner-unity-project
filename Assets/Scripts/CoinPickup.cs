using UnityEngine;

public class CoinPickup : MonoBehaviour
{
    public int value = 1;

    private void Update()
    {
        transform.Rotate(Vector3.up * 120f * Time.deltaTime, Space.World);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (GameManager.Instance != null)
                GameManager.Instance.AddScore(value);

            Destroy(gameObject);
        }
    }
}
