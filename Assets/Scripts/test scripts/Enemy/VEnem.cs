using UnityEngine;

public class VidaEnemigo : MonoBehaviour
{
    public int vidaInicial = 1; // Vida inicial del enemigo
    private int vidaActual; // Vida actual del enemigo

    void Start()
    {
        vidaActual = vidaInicial;
    }

    // Método para recibir daño
    public void RecibirDanio(int cantidad)
    {
        vidaActual -= cantidad;

        // Verificar si la vida llegó a cero
        if (vidaActual <= 0)
        {
            // Llamar a un método de destrucción o simplemente destruir el objeto
            DestruirEnemigo();
        }
    }

    // Método para destruir el enemigo
    void DestruirEnemigo()
    {
        // Puedes agregar aquí lógica adicional antes de destruir el objeto (por ejemplo, efectos visuales)
        Destroy(gameObject);
    }
}