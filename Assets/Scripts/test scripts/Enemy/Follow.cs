using UnityEngine;

public class SeguirJugador : MonoBehaviour
{
    private Transform jugador;
    public float velocidad = 3f;

    private bool tocado = false;
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        jugador = GameObject.FindGameObjectWithTag("Player").transform;
        if (jugador != null && !tocado)
        {
            Vector3 direccion = jugador.position - transform.position;
            direccion.Normalize();

            transform.Translate(direccion * velocidad * Time.deltaTime);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        { 
            Destroy(gameObject,1f);
        }
    }

   
}
