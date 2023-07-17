using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "TurretGroups", menuName = "scriptableObjects/turret/Group")]
public class TourretGroupSO : ScriptableObject
{
    public List<GameObject> tourrets;
    public GameObject pUp;
}
