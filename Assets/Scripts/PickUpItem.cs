using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.U2D;
using UnityEngine.UI;

public class PickUpItem : MonoBehaviour
{
    public GameObject[] inventory;

    // Start is called before the first frame update
    void Start()
    {
        inventory = GameObject.FindGameObjectsWithTag("EmptySlot");
        inventory.Reverse();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            foreach (var item in inventory)
            {
                if (item.CompareTag("EmptySlot"))
                {
                    item.gameObject.GetComponent<Image>().enabled = true;
                    item.gameObject.GetComponent<Image>().sprite = gameObject.GetComponent<SpriteRenderer>().sprite;
                    gameObject.SetActive(false);
                    item.tag = "FullSlot";
                    break;
                }
            }
        }
    }
}
