using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private float speed = 3f;
    [SerializeField] private float awarenessRadius = 5f;
    [SerializeField] private float stopDistance = 1f;
    [SerializeField] private float rotationSpeed = 5f;
    [SerializeField] private float randomMoveInterval = 2f;

    [SerializeField] private float obstacleCheckCircleRadius = 0.5f;
    [SerializeField] private float obstacleCheckDistance = 2f;
    [SerializeField] private LayerMask obstacleLayerMask;
    [SerializeField] private float obstacleAvoidanceCooldown = 0.5f;

    private Rigidbody2D rb;
    private Transform player;
    private Vector3 directionToPlayer;
    private Vector3 randomDirection;
    private float randomMoveTimer;
    private RaycastHit2D[] obstacleCollisions;
    private float obstacleAvoidanceTimer;
    private Vector2 obstacleAvoidanceDirection;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        obstacleCollisions = new RaycastHit2D[10];
    }

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        randomMoveTimer = randomMoveInterval;
    }

    void Update()
    {
        randomMoveTimer -= Time.deltaTime;
        obstacleAvoidanceTimer -= Time.deltaTime;

        if (player != null)
        {
            float distanceToPlayer = Vector2.Distance(transform.position, player.position);
            if (distanceToPlayer <= awarenessRadius && distanceToPlayer > stopDistance)
            {
                MoveTowardsPlayer();
                RotateTowardsPlayer();
            }
            else
            {
                RandomMovement();
            }
        }

        HandleObstacles();
        ClampPosition();
    }

    private void MoveTowardsPlayer()
    {
        directionToPlayer = (player.position - transform.position).normalized;
        rb.linearVelocity = directionToPlayer * speed;
    }

    private void RandomMovement()
    {
        if (randomMoveTimer <= 0f)
        {
            randomDirection = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), 0).normalized;
            randomMoveTimer = randomMoveInterval;
        }

        rb.linearVelocity = randomDirection * speed;

        float angle = Mathf.Atan2(randomDirection.y, randomDirection.x) * Mathf.Rad2Deg;
        Quaternion targetRotation = Quaternion.Euler(new Vector3(0, 0, angle - 90));
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }

    private void HandleObstacles()
    {
        var contactFilter = new ContactFilter2D();
        contactFilter.SetLayerMask(obstacleLayerMask);

        int numberOfCollisions = Physics2D.CircleCast(
            transform.position,
            obstacleCheckCircleRadius,
            transform.up,
            contactFilter,
            obstacleCollisions,
            obstacleCheckDistance);

        for (int i = 0; i < numberOfCollisions; i++)
        {
            var obstacle = obstacleCollisions[i];
            if (obstacle.collider.gameObject == gameObject)
            {
                continue;
            }

            if (obstacleAvoidanceTimer <= 0)
            {
                obstacleAvoidanceDirection = obstacle.normal;
                obstacleAvoidanceTimer = obstacleAvoidanceCooldown;

                float angle = Mathf.Atan2(obstacleAvoidanceDirection.y, obstacleAvoidanceDirection.x) * Mathf.Rad2Deg;
                Quaternion targetRotation = Quaternion.Euler(0, 0, angle - 90);
                transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

                rb.linearVelocity = obstacleAvoidanceDirection * speed;
            }
            break;
        }
    }

    private void RotateTowardsPlayer()
    {
        if (directionToPlayer != Vector3.zero)
        {
            float angle = Mathf.Atan2(directionToPlayer.y, directionToPlayer.x) * Mathf.Rad2Deg;
            Quaternion targetRotation = Quaternion.Euler(new Vector3(0, 0, angle - 90));
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }
    }

    private void ClampPosition()
    {
        float clampedX = Mathf.Clamp(transform.position.x, -8.48f, 8.48f);
        float clampedY = Mathf.Clamp(transform.position.y, -4.6f, 4.6f);
        transform.position = new Vector2(clampedX, clampedY);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Enemy collided with player!");
        }
    }
}
