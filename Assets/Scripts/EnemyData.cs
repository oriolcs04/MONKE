using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New EnemyData", menuName = "EnemyObject")]
public class EnemyData : ScriptableObject
{
    public string type;
    public int health;
    public int damage;

}
