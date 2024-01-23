using UnityEngine;

public class ControladorDisparo : MonoBehaviour
{
    public GameObject balaPrefab; // Prefab de la bala
    public Transform puntoDeDisparo; // Punto desde el cual se disparará la bala
    public float velocidadBala = 10f; // Velocidad de la bala
    public float tiempoEntreDisparos = 1f; // Tiempo entre disparos
    private float tiempoUltimoDisparo; // Tiempo del último disparo

    void Update()
    {
        // Disparar cuando se hace clic y ha pasado suficiente tiempo desde el último disparo
        if (Input.GetMouseButtonDown(0) && Time.time > tiempoUltimoDisparo + tiempoEntreDisparos)
        {
            Disparar();
        }
    }

    void Disparar()
    {
        // Instanciar la bala
        GameObject bala = Instantiate(balaPrefab, puntoDeDisparo.position, Quaternion.identity);

        // Obtener la dirección hacia la posición del ratón
        Vector3 direccion = (Camera.main.ScreenToWorldPoint(Input.mousePosition) - puntoDeDisparo.position).normalized;

        // Aplicar fuerza a la bala en esa dirección
        bala.GetComponent<Rigidbody2D>().velocity = new Vector2(direccion.x, direccion.y) * velocidadBala;

        // Actualizar el tiempo del último disparo
        tiempoUltimoDisparo = Time.time;

        // Destruir la bala después de 2 segundos
        Destroy(bala, 2f);
    }
}