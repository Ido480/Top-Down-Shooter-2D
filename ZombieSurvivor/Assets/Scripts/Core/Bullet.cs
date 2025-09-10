using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float speed = 10f;
    [SerializeField] private float lifetime = 3f;
    [SerializeField] private GameObject hitEffectPrefab;
    public float bulletDamage;


    private Vector2 shootDirection;
    private float timer;

    public void Initialize(Vector2 direction, float damage)
    {
        shootDirection = direction.normalized;
        bulletDamage = damage;
        timer = lifetime; 
    }

    void Update()
    {
        transform.Translate(shootDirection * speed * Time.deltaTime, Space.World);

        timer -= Time.deltaTime;

        if (timer <= 0f)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<EnemyMovement>())
        {
            Health health = collision.GetComponent<Health>();
            health.TakeDamage(bulletDamage);

            Instantiate(hitEffectPrefab, collision.transform.position,Quaternion.identity);
            Destroy(gameObject); 
        }
    }
    public void IncreaseDamage(float amount)
    {
        bulletDamage += amount;
    }

}
