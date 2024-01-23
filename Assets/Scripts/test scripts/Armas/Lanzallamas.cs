using UnityEngine;

public class Lanzallamas : MonoBehaviour
{
    public LayerMask capaEnemigos; // Capa que contiene los enemigos
    public float rangoGolpe = 2f; // Rango del golpe
    public int danio = 1; // Cantidad de da�o causado
    public float tiempoRecarga = 0.1f; // Tiempo de recarga entre espadazos (ajustado para que se repita r�pidamente)

    public GameObject efectoGolpePrefab; // Prefab del efecto visual del golpe
    public float tiempoEfectoGolpe = 0.1f; // Duraci�n del efecto visual del golpe (ajustado para que sea m�s r�pido)

    private bool clicSostenido = false; // Variable que indica si el bot�n del mouse est� siendo sostenido
    private float tiempoUltimoGolpe; // Tiempo del �ltimo golpe
    private GameObject efectoGolpeActual; // Referencia al efecto visual actual

    void Update()
    {
        // Iniciar el efecto de lanzallamas mientras el bot�n del mouse est� siendo sostenido
        if (Input.GetMouseButtonDown(0))
        {
            clicSostenido = true;
            RealizarGolpeDeLanzallamas();
        }
        // Detener el efecto de lanzallamas cuando se suelta el bot�n del mouse
        else if (Input.GetMouseButtonUp(0))
        {
            clicSostenido = false;
            // Destruir el efecto visual cuando se suelta el bot�n del mouse
            if (efectoGolpeActual != null)
            {
                Destroy(efectoGolpeActual);
            }
        }

        // Si el bot�n del mouse est� siendo sostenido, realizar el golpe de lanzallamas continuamente
        if (clicSostenido && Time.time > tiempoUltimoGolpe + tiempoRecarga)
        {
            RealizarGolpeDeLanzallamas();
        }
    }

    void RealizarGolpeDeLanzallamas()
    {
        // Obtener la posici�n del rat�n en el mundo
        Vector2 posicionMouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // Activar el efecto visual temporal del golpe desde la posici�n del personaje
        MostrarEfectoGolpe(transform.position, posicionMouse);

        // Detectar enemigos dentro del rango del golpe
        Collider2D[] enemigosGolpeados = Physics2D.OverlapCircleAll(posicionMouse, rangoGolpe, capaEnemigos);

       

        // Actualizar el tiempo del �ltimo golpe
        tiempoUltimoGolpe = Time.time;
    }

    void MostrarEfectoGolpe(Vector2 posicionInicio, Vector2 posicionFin)
    {
        // Destruir el efecto visual anterior si existe
        if (efectoGolpeActual != null)
        {
            Destroy(efectoGolpeActual);
        }

        // Calcular la direcci�n del golpe
        Vector2 direccion = posicionFin - posicionInicio;

        // Calcular el �ngulo de rotaci�n
        float angulo = Mathf.Atan2(direccion.y, direccion.x) * Mathf.Rad2Deg;

        // Instanciar el efecto visual del golpe
        efectoGolpeActual = Instantiate(efectoGolpePrefab, transform.position, Quaternion.Euler(0, 0, angulo));

        // Escalar el efecto visual para que alcance el m�ximo de la circunferencia del cono
        efectoGolpeActual.transform.localScale = new Vector3(rangoGolpe * 2, rangoGolpe * 2, 1);

        // No destruir el efecto visual autom�ticamente
        // Destroy(efectoGolpeActual, tiempoEfectoGolpe);
    }

    // M�todo opcional para visualizar el �rea del golpe en el Editor de Unity
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, rangoGolpe);
    }
}