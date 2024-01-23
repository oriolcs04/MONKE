using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableEnemy : MonoBehaviour
{
    public GameObject enemy;
    public bool alreadySpawned = false;

    private void OnBecameVisible()
    {
        if (alreadySpawned != true)
        {
            enemy.transform.position = gameObject.transform.position;
            Instantiate(enemy);
            alreadySpawned = true;
        }
    }
}
