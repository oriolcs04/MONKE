using UnityEngine;

public class Lanzallamas : MonoBehaviour
{
    public LayerMask capaEnemigos; // Capa que contiene los enemigos
    public float rangoGolpe = 2f; // Rango del golpe
    public int danio = 1; // Cantidad de daño causado
    public float tiempoRecarga = 0.1f; // Tiempo de recarga entre espadazos (ajustado para que se repita rápidamente)

    public GameObject efectoGolpePrefab; // Prefab del efecto visual del golpe
    public float tiempoEfectoGolpe = 0.1f; // Duración del efecto visual del golpe (ajustado para que sea más rápido)

    private bool clicSostenido = false; // Variable que indica si el botón del mouse está siendo sostenido
    private float tiempoUltimoGolpe; // Tiempo del último golpe
    private GameObject efectoGolpeActual; // Referencia al efecto visual actual

    void Update()
    {
        // Iniciar el efecto de lanzallamas mientras el botón del mouse está siendo sostenido
        if (Input.GetMouseButtonDown(0))
        {
            clicSostenido = true;
            RealizarGolpeDeLanzallamas();
        }
        // Detener el efecto de lanzallamas cuando se suelta el botón del mouse
        else if (Input.GetMouseButtonUp(0))
        {
            clicSostenido = false;
            // Destruir el efecto visual cuando se suelta el botón del mouse
            if (efectoGolpeActual != null)
            {
                Destroy(efectoGolpeActual);
            }
        }

        // Si el botón del mouse está siendo sostenido, realizar el golpe de lanzallamas continuamente
        if (clicSostenido && Time.time > tiempoUltimoGolpe + tiempoRecarga)
        {
            RealizarGolpeDeLanzallamas();
        }
    }

    void RealizarGolpeDeLanzallamas()
    {
        // Obtener la posición del ratón en el mundo
        Vector2 posicionMouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // Activar el efecto visual temporal del golpe desde la posición del personaje
        MostrarEfectoGolpe(transform.position, posicionMouse);

        // Detectar enemigos dentro del rango del golpe
        Collider2D[] enemigosGolpeados = Physics2D.OverlapCircleAll(posicionMouse, rangoGolpe, capaEnemigos);

       

        // Actualizar el tiempo del último golpe
        tiempoUltimoGolpe = Time.time;
    }

    void MostrarEfectoGolpe(Vector2 posicionInicio, Vector2 posicionFin)
    {
        // Destruir el efecto visual anterior si existe
        if (efectoGolpeActual != null)
        {
            Destroy(efectoGolpeActual);
        }

        // Calcular la dirección del golpe
        Vector2 direccion = posicionFin - posicionInicio;

        // Calcular el ángulo de rotación
        float angulo = Mathf.Atan2(direccion.y, direccion.x) * Mathf.Rad2Deg;

        // Instanciar el efecto visual del golpe
        efectoGolpeActual = Instantiate(efectoGolpePrefab, transform.position, Quaternion.Euler(0, 0, angulo));

        // Escalar el efecto visual para que alcance el máximo de la circunferencia del cono
        efectoGolpeActual.transform.localScale = new Vector3(rangoGolpe * 2, rangoGolpe * 2, 1);

        // No destruir el efecto visual automáticamente
        // Destroy(efectoGolpeActual, tiempoEfectoGolpe);
    }

    // Método opcional para visualizar el área del golpe en el Editor de Unity
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, rangoGolpe);
    }
}