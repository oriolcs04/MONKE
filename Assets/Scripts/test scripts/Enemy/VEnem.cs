using UnityEngine;

public class VidaEnemigo : MonoBehaviour
{
    private int vidaActual; // Vida actual del enemigo

    void Start()
    {
        //vidaActual = vidaInicial;
    }

    // Método para recibir daño
    public void RecibirDanio(int cantidad)
    {
        vidaActual -= cantidad;

        // Verificar si la vida llegó a cero
        if (vidaActual <= 0)
        {
            Destroy(gameObject); // Se destruirá inmediatamente al tocar la bala
        }
    }
}