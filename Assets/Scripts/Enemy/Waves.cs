using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyWaves", menuName = "scriptableObjects/Enemies/Waves")]
public class Waves : ScriptableObject
{
   public List<EnemyStats> stats;
}
