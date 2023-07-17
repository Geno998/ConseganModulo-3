using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretSpawnser : MonoBehaviour
{

    [SerializeField] List<Transform> Spawners;
    [SerializeField] Transform base1pos, base2pos, base3pos;
    [SerializeField] Base base1, base2, base3;

    [SerializeField] List<TourretGroupSO> tourretGroup;

    TourretGroupSO currentTourretGroup;
    int currentRound;

    EnemySpawner spawner;

    private void Start()
    {
        spawner = GameManager.Instance.Spawner;

        chooseTurretGroup();
        SpawnTourretGroup();

    }

    private void Update()
    {

    }


    public void chooseTurretGroup()
    {
        if (currentRound < tourretGroup.Count)
        {
            currentTourretGroup = tourretGroup[currentRound];
        }

    }

    public void SpawnTourretGroup()
    {
        if (currentRound < tourretGroup.Count)
        {
            for (int i = 0; i < currentTourretGroup.tourrets.Count; i++)
            {
                GameObject tmp;
                tmp = Instantiate(currentTourretGroup.tourrets[i], Spawners[i].position, Quaternion.identity, transform);
                Turret tmpTurret = tmp.GetComponent<Turret>();
                tmpTurret.base1 = base1;
                tmpTurret.base2 = base2;
                tmpTurret.base3 = base3;
                tmpTurret.base1pos = base1pos;
                tmpTurret.base2pos = base2pos;
                tmpTurret.base3pos = base3pos;
            }


            if (currentTourretGroup.pUp != null)
            {

                GameObject tmp2;
                tmp2 = Instantiate(currentTourretGroup.pUp, Spawners[3].position, Quaternion.identity, transform);
                PowerUp tmpPup = tmp2.GetComponent<PowerUp>();
                tmpPup.base1 = base1;
                tmpPup.base2 = base2;
                tmpPup.base3 = base3;
                tmpPup.base1pos = base1pos;
                tmpPup.base2pos = base2pos;
                tmpPup.base3pos = base3pos;
            }

            spawner.nextWave = false;
            currentRound++;
        }
    }

}
