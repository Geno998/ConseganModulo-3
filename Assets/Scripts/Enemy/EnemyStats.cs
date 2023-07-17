using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "EnemyStats", menuName = "scriptableObjects/Enemies/Stats")]
public class EnemyStats : ScriptableObject
{
    public int maxHP;
    public float speed;
}
