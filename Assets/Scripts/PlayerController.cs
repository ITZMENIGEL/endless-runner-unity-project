using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float laneWidth = 3f;
    public float moveSpeed = 8f;
    public float jumpForce = 7f;
    public float gravity = 22f;
    public float groundY = 0.5f;

    private int laneIndex = 1;
    private float verticalVelocity;
    private bool isGrounded = true;

    private GameManager gameManager;

    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    void Update()
    {
        if (gameManager != null && gameManager.isGameOver)
            return;

        if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
            ChangeLane(-1);

        if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
            ChangeLane(1);

        if ((Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.Space)) && isGrounded)
        {
            verticalVelocity = jumpForce;
            isGrounded = false;
        }

        float targetX = (laneIndex - 1) * laneWidth;
        Vector3 targetPosition = new Vector3(targetX, transform.position.y, 0f);
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);

        verticalVelocity -= gravity * Time.deltaTime;
        transform.position += new Vector3(0f, verticalVelocity * Time.deltaTime, 0f);

        if (transform.position.y <= groundY)
        {
            transform.position = new Vector3(transform.position.x, groundY, transform.position.z);
            verticalVelocity = 0f;
            isGrounded = true;
        }
    }

    private void ChangeLane(int direction)
    {
        laneIndex += direction;
        laneIndex = Mathf.Clamp(laneIndex, 0, 2);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            if (gameManager != null)
                gameManager.EndGame();
        }
    }
}
