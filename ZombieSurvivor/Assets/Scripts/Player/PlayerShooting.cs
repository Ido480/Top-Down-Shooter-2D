using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab; 
    [SerializeField] private Transform firePoint;
    [SerializeField] private float fireRate = 0.2f;
    [SerializeField] private float bulletDamage = 10f;
    [SerializeField] private AudioSource shootAudio;
    private float nextFireTime = 0f; 

    void Update()
    {
        if (Input.GetButton("Fire1") && Time.time > nextFireTime)
        {
            Shoot(); 
            nextFireTime = Time.time + fireRate; 
        }
    }

    private void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

        bullet.transform.SetParent(GameObject.Find("Projectiles").transform);

        Vector2 shootDirection = (Camera.main.ScreenToWorldPoint(Input.mousePosition) - firePoint.position).normalized;

        bullet.GetComponent<Bullet>().Initialize(shootDirection, bulletDamage);

        if (shootAudio != null)
        {
            SoundManager.Instance.PlayShootingSound();
        }
    }
    public void IncreaseFireRate(float amount)
    {
        fireRate -= amount;

        if (fireRate < 0.05f) 
        {
            fireRate = 0.05f;
        }
    }
    public void IncreaseBulletDamage(float amount)
    {
        bulletDamage += amount;
    }

}
