using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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
        if (GameObject.FindGameObjectsWithTag("Reward").Length <= 1 || GameObject.FindGameObjectsWithTag("Isle").Length <= 20)
        {
            Invoke("SpawnNewIsle", 0.1f);
        }
        
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
        do
        {
            rand = UnityEngine.Random.Range(0, suitableIsles.Length);            
        } while (!CheckIfIslandIsSuitable(suitableIsles[rand]) == false); 
        Instantiate(suitableIsles[rand], transform.position, suitableIsles[rand].transform.rotation);
    }

    private bool CheckIfIslandIsSuitable(GameObject newIsland)
    {
        return CheckSameIsland(newIsland) && CheckDeadEndOnFirstIsland(newIsland);
    }

    private bool CheckDeadEndOnFirstIsland(GameObject newIsland)
    {
        return (newIsland.CompareTag("DeadEnd") || newIsland.CompareTag("Reward")) && GameObject.FindGameObjectsWithTag("Isle").Length <= 4;
    }

    private bool CheckSameIsland(GameObject newIsland)
    {
        return newIsland.gameObject.GetPrefabDefinition() == gameObject.transform.parent.GetPrefabDefinition();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("IsleSpawner"))
        {
            if (collision.gameObject.GetComponent<IsleSpawner>().spawned == false && spawned == false)
            {
                Instantiate(template.closedRoom, transform.position, Quaternion.identity);
            }
        }
        Destroy(gameObject);
    }
}
