using System.Collections;
using UnityEngine;

public class VidasP : MonoBehaviour
{
    public int vidas;
    public string ultimaColl;

    public int iFrames;
    private int framesInvencivilidad;

    public bool tocandoObeliscoCerdo;
    public float tiempoObeliscoCerdo = 1.0f; 
    private float tiempoPasadoObeliscoCerdo;

 
    void Start()
    {
        vidas = 7;
        ultimaColl = null;
        framesInvencivilidad = 0;
        tocandoObeliscoCerdo = false;
        tiempoPasadoObeliscoCerdo = 0f;
    }

 
    void Update()
    {

        if (framesInvencivilidad > 0)
        {
            framesInvencivilidad--;
        }
        if (tocandoObeliscoCerdo)
        {
            tiempoPasadoObeliscoCerdo += Time.deltaTime;

            if (tiempoPasadoObeliscoCerdo >= tiempoObeliscoCerdo)
            {
                IncrementarVidas();
                tiempoPasadoObeliscoCerdo = 0f;
            }
        }
        else
        {
            tiempoPasadoObeliscoCerdo = 0f;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (framesInvencivilidad == 0)
        {
            if (collision.gameObject.CompareTag("Animal"))
            {
                HurtwithAnimal(collision.gameObject);
                Debug.Log("Hurt with Animal");
            }
            else if (collision.gameObject.CompareTag("Mage"))
            {
                HurtwithMage(collision.gameObject);
                Debug.Log("Hurt with Mage");
            }
            else if (collision.gameObject.CompareTag("Ogre"))
            {
                HurtwithOgre();
                Debug.Log("Hurt with Ogre");
            }
            else if (collision.gameObject.CompareTag("Heal") && vidas < 7)
            {
                tocandoObeliscoCerdo = true;
                Debug.Log("Healing");
                if (vidas == 7)
                {
                    tocandoObeliscoCerdo=false;
                }
            }
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (framesInvencivilidad == 0)
        {
            if (collision.gameObject.CompareTag("Animal"))
            {
                HurtwithAnimal(collision.gameObject);
                Debug.Log("Hurt with Animal");
            }
            else if (collision.gameObject.CompareTag("Mage"))
            {
                HurtwithMage(collision.gameObject);
                Debug.Log("Hurt with Mage");
            }
            else if (collision.gameObject.CompareTag("Bullet"))
            {
                Hurt();
                Debug.Log("Hurt with bullet");
            }
            else if (collision.gameObject.CompareTag("Ogre"))
            {
                HurtwithOgre();
                Debug.Log("Hurt with Ogre");
            }
            /*else if (collision.gameObject.CompareTag("Heal") && vidas < 7)
            {

                tocandoObeliscoCerdo = true;
                if (vidas == 7)
                {
                    tocandoObeliscoCerdo = false;
                }
            }*/
        }
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Heal") && vidas < 7)
        {
            Debug.Log("ASDASD");
            IncrementarVidas();

        }

    }

    private void IncrementarVidas()
    {
        //if (vidas < 7)
            vidas += 1;
   
    }

    private void HurtwithMage(GameObject mago)
    {
        vidas -= mago.GetComponent<Enemy>().damage;
    }

    private void HurtwithAnimal(GameObject animal)
    {
        vidas -= animal.GetComponent<Enemy>().damage;
    }

    private void HurtwithOgre()
    {
        vidas -= 3;
    }

    private void Hurt()
    {
        vidas -= 1;

    }

    private void HealWithOrb()
    {
        vidas += 1;
    }

}