using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class VidasP : MonoBehaviour
{
    public int vidas;
    public string ultimaColl;

    public int iFrames;
    private int framesInvencivilidad;

    public GameObject image;
 
    void Start()
    {
        vidas = 7;
        ultimaColl = null;
        framesInvencivilidad = 0;
    }

 
    void Update()
    {

        if (framesInvencivilidad > 0)
        {
            framesInvencivilidad--;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (framesInvencivilidad == 0)
        {
            if (collision.gameObject.CompareTag("Animal"))
            {
                HurtwithAnimal(collision.gameObject);
            }
            else if (collision.gameObject.CompareTag("Mage"))
            {
                HurtwithMage(collision.gameObject);
            }
            else if (collision.gameObject.CompareTag("Bullet"))
            {
                Hurt();
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
            }
            else if (collision.gameObject.CompareTag("Mage"))
            {
                HurtwithMage(collision.gameObject);
            }
            else if (collision.gameObject.CompareTag("Bullet"))
            {
                Hurt();
            }
        }
    }

    private void HurtwithMage(GameObject mago)
    {
        vidas -= mago.GetComponent<Enemy>().damage;
        ShowFeedback();
    }


    private void HurtwithAnimal(GameObject animal)
    {
        vidas -= animal.GetComponent<Enemy>().damage;
        ShowFeedback();
    }

    private void Hurt()
    {
        vidas -= 1;
        ShowFeedback();
    }

    private void ShowFeedback()
    {
        image = GameObject.FindGameObjectWithTag("Feedback");
        image.gameObject.GetComponent<Image>().enabled = true;
        StartCoroutine(HoldeaBbsita());
    }

    public IEnumerator HoldeaBbsita()
    {
        yield return new WaitForSeconds(1);
        image.gameObject.GetComponent<Image>().enabled = false;
    }

}