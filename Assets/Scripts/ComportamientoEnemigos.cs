using UnityEngine;
using System.Collections; // Agregamos esta línea

public class EnemyWizard : MonoBehaviour
{
    public GameObject bulletPrefab;
    public float bulletSpeed = 5f;
    public float timeToDestroyBullet = 4f;
    
    private Transform player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;

        if (player == null)
        {
            Debug.LogError("Player not found! Make sure the player has the 'Player' tag.");
        }
        else
        {
            // Start the bullet firing coroutine
            StartCoroutine(FireBullet());
        }

        

    }

    void Update()
    {
        // Rotate towards the player
        Vector3 directionToPlayer = player.position - transform.position;
        float angle = Mathf.Atan2(directionToPlayer.y, directionToPlayer.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }

    IEnumerator FireBullet()
    {
        while (true)
        {
            // Instantiate a bullet
            GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);

            // Set bullet speed
            Rigidbody2D bulletRb = bullet.GetComponent<Rigidbody2D>();
            bulletRb.velocity = transform.right * bulletSpeed;

            // Destroy the bullet after a certain time
            Destroy(bullet, timeToDestroyBullet);


            // Wait before firing the next bullet
            yield return new WaitForSeconds(2f); // You can adjust this value based on your preference
        }

    }
    void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the bullet collides with the player
        if (other.CompareTag("Player"))
        {
            // Destroy the bullet when it collides with the player
            Destroy(bulletPrefab);
        }
    }
}