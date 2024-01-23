using UnityEngine;

public class VidaEnemigo : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            Destroy(gameObject); // Se destruirá inmediatamente al tocar la bala
        }
    }
}