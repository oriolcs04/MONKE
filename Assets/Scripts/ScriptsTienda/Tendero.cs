using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tendero : MonoBehaviour
{
    [SerializeField] private GameObject tienda;
    [SerializeField] private GameObject interact;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            interact.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        interact.SetActive(false);
    }

    private void Update()
    {
        if (tienda.activeInHierarchy == true && Input.GetKeyDown(KeyCode.E))
        {
            tienda.SetActive(false);
        }
        else if (interact.activeInHierarchy == true && Input.GetKeyDown(KeyCode.E))
        {
            tienda.SetActive(true);
        }
    }

}
