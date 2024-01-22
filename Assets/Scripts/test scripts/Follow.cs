using UnityEngine;

public class SeguirJugador : MonoBehaviour
{
    public Transform jugador; // La referencia al objeto del jugador
    public float velocidad = 3f; // Velocidad de movimiento del enemigo

    void Update()
    {
        // Asegúrate de que la referencia al jugador no sea nula
        if (jugador != null)
        {
            // Calcula la dirección hacia el jugador
            Vector3 direccion = jugador.position - transform.position;
            direccion.Normalize(); // Normaliza para obtener un vector de dirección unitario

            // Mueve al enemigo en la dirección del jugador
            transform.Translate(direccion * velocidad * Time.deltaTime);
        }
    }
}