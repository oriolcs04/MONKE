using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsleSpawner : MonoBehaviour
{
    public int openPath; // 1 top, 2 left, 3 right, 4 bottom
    private int rand;
    private bool spawned = false;
    public bool allreadyTaken = false;

    private IsleTemplate template;

    private void Start()
    {
        template = GameObject.FindGameObjectWithTag("Templates").GetComponent<IsleTemplate>();
        Invoke("SpawnNewIsle", 5f);
    }

    void SpawnNewIsle()
    {
        if (spawned == false)
        {
            switch (openPath)
            {
                case 1: // top
                    InstantiateSuitableIsle(template.bottomIsle);
                    break;
                case 2: // left
                    InstantiateSuitableIsle(template.rightIsle);
                    break;
                case 3: // right
                    InstantiateSuitableIsle(template.leftIsle);
                    break;
                case 4: // bottom
                    InstantiateSuitableIsle(template.topIsle);
                    break;
            }
            spawned = true;
        }
    }

    private void InstantiateSuitableIsle(GameObject[] suitableIsles)
    {
        rand = UnityEngine.Random.Range(0, suitableIsles.Length);
        Instantiate(suitableIsles[rand], transform.position, suitableIsles[rand].transform.rotation);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(gameObject);
    }
}
