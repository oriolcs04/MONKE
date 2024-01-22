using UnityEngine;

public class GolpeDeEspada : MonoBehaviour
{
    public LayerMask capaEnemigos; // Capa que contiene los enemigos
    public float rangoGolpe = 2f; // Rango del golpe
    public int danio = 1; // Cantidad de daño causado
    public float tiempoRecarga = 3f; // Tiempo de recarga entre espadazos

    public GameObject efectoGolpePrefab; // Prefab del efecto visual del golpe
    public float tiempoEfectoGolpe = 0.5f; // Duración del efecto visual del golpe

    private float tiempoUltimoGolpe; // Tiempo del último golpe

    void Update()
    {
        // Detectar clic del ratón para realizar el golpe de espada
        if (Input.GetMouseButtonDown(0) && Time.time > tiempoUltimoGolpe + tiempoRecarga)
        {
            RealizarGolpeDeEspada();
        }
    }

    void RealizarGolpeDeEspada()
    {
        // Obtener la posición del ratón en el mundo
        Vector2 posicionMouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // Activar el efecto visual temporal del golpe desde la posición del personaje
        MostrarEfectoGolpe(transform.position, posicionMouse);

        // Detectar enemigos dentro del rango del golpe
        Collider2D[] enemigosGolpeados = Physics2D.OverlapCircleAll(posicionMouse, rangoGolpe, capaEnemigos);

        // Aplicar daño a los enemigos dentro del rango
        foreach (Collider2D enemigo in enemigosGolpeados)
        {
            // Aquí puedes agregar lógica adicional si es necesario (por ejemplo, reproducir efectos de sonido, animaciones, etc.)
            // Aplicar daño al enemigo
            enemigo.GetComponent<VidaEnemigo>().RecibirDanio(danio);
        }

        // Actualizar el tiempo del último golpe
        tiempoUltimoGolpe = Time.time;
    }

    void MostrarEfectoGolpe(Vector2 posicionInicio, Vector2 posicionFin)
    {
        // Calcular la dirección del golpe
        Vector2 direccion = posicionFin - posicionInicio;

        // Calcular el ángulo de rotación
        float angulo = Mathf.Atan2(direccion.y, direccion.x) * Mathf.Rad2Deg;

        // Instanciar el efecto visual del golpe
        GameObject efectoGolpe = Instantiate(efectoGolpePrefab, posicionInicio, Quaternion.Euler(0, 0, angulo));

        // Escalar el efecto visual para que alcance el máximo de la circunferencia del cono
        efectoGolpe.transform.localScale = new Vector3(rangoGolpe * 2, rangoGolpe * 2, 1);

        // Destruir el efecto visual después de un breve período
        Destroy(efectoGolpe, tiempoEfectoGolpe);
    }

    // Método opcional para visualizar el área del golpe en el Editor de Unity
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, rangoGolpe);
    }
}