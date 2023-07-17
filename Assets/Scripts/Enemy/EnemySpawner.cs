using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] List<Waves> Waves;
    [SerializeField] List<Transform> targets;
    [SerializeField] GameObject enemy;
    List<EnemyStats> stats;

    [SerializeField] int spawnTimer;
    [SerializeField] float time;

    public int currentWave = -1;
    int currentEnemy;
    [SerializeField] public bool nextWave;
    [SerializeField] public bool nextEnemy;
    public bool lastEnemy;
    TurretSpawnser turretSpawnser;

    private void Awake()
    {
        stats = Waves[0].stats;
        time = spawnTimer;

    }

    private void Start()
    {
        turretSpawnser = GameManager.Instance.TurretSp;
    }

    private void Update()
    {
        SpawnEnemies();
    }


    void SpawnEnemies()
    {
        if (time > 0)
        {
            time -= Time.deltaTime;
        }
        else
        {
            if (currentWave < Waves.Count)
            {
                if (currentEnemy < stats.Count && nextEnemy)
                {

                    GameObject tmp;
                    tmp = Instantiate(enemy, transform.position, Quaternion.identity, transform);
                    EnemyController controller = tmp.GetComponent<EnemyController>();
                    controller.stats = stats[currentEnemy];
                    controller.targets = targets;
                    currentEnemy++;
                    GameManager.Instance.currentEnemies++;
                    time = spawnTimer;
                }
                else
                {
                    nextEnemy = false;
                    lastEnemy = true;
                }

                if (Input.GetKeyDown(KeyCode.Space) && !GameManager.Instance.roundNotFinished)
                {
                    currentWave++;
                    currentEnemy = 0;
                    time = spawnTimer;
                    stats = Waves[currentWave].stats;
                    nextEnemy = true;
                    lastEnemy = false;
                }
            }
        }
    }
}
