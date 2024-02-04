using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class VidasP : MonoBehaviour
{
    public int vidas;
    public string ultimaColl;

    public int iFrames;
    private int framesInvencivilidad;

    public GameObject image;
    public List<GameObject> lifes;
 
    void Start()
    {
        vidas = 7;
        ultimaColl = null;
        framesInvencivilidad = 0;

        lifes = GameObject.FindGameObjectsWithTag("Heart").ToList();
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
        ShowFeedback(mago.GetComponent<Enemy>().damage);
    }


    private void HurtwithAnimal(GameObject animal)
    {
        vidas -= animal.GetComponent<Enemy>().damage;
        ShowFeedback(animal.GetComponent<Enemy>().damage);
    }

    private void Hurt()
    {
        vidas -= 1;
        ShowFeedback(1);
    }

    private void ShowFeedback(int damage)
    {
        if (vidas > 0)
        {
            image = GameObject.FindGameObjectWithTag("Feedback");
            image.gameObject.GetComponent<Image>().enabled = true;
            for (int i = 0; i < damage; i++)
            {
                lifes.ElementAt(0).gameObject.SetActive(false);
                lifes.RemoveAt(0);
            }
            StartCoroutine(HoldeaBbsita());
        }
        else 
        {
            SceneManager.LoadScene("GameOver");
        }
    }

    public IEnumerator HoldeaBbsita()
    {
        yield return new WaitForSeconds(1);
        image.gameObject.GetComponent<Image>().enabled = false;
    }

}