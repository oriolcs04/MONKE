using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New EnemyData", menuName = "Enemy")]
public class Enemy : ScriptableObject
{
    public int health;
    public int damage;

}
