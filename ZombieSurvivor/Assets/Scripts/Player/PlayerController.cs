using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float minX = -8.48f;
    [SerializeField] private float maxX = 8.48f;
    [SerializeField] private float minY = -4.6f;
    [SerializeField] private float maxY = 4.6f;
    [SerializeField] private GameObject visualSprite; 
    private Rigidbody2D rb;
    private float moveX;
    private float moveY;
    private Animator animator;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = transform.Find("Visuals").GetComponent<Animator>();
    }

    void Update()
    {
        GatherInput();
        Move();
        RotateTowardsMouse();
        SetAnimation();
    }

    private void RotateTowardsMouse()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 direction = (mousePosition - transform.position).normalized;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        visualSprite.transform.rotation = Quaternion.Euler(0, 0, angle);
    }
    private void SetAnimation()
    {
        bool isMoving = new Vector2(moveX, moveY) != Vector2.zero;
        animator.SetBool("IsMoving", isMoving);
    }


    private void Move()
    {
        float desiredX = transform.position.x + moveX * Time.deltaTime * moveSpeed;
        float desiredY = transform.position.y + moveY * Time.deltaTime * moveSpeed;

        float clampedX = Mathf.Clamp(desiredX, minX, maxX);
        float clampedY = Mathf.Clamp(desiredY, minY, maxY);

        rb.MovePosition(new Vector2(clampedX, clampedY));
    }

    private void GatherInput()
    {
        moveX = Input.GetAxisRaw("Horizontal");
        moveY = Input.GetAxisRaw("Vertical");
    }
}
