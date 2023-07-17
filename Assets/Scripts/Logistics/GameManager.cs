using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;
using UnityEngine.UIElements;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;


    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
            {
                Debug.Log(_instance);
            }
            return _instance;
        }
    }


    EnemySpawner _spawner;
    TurretSpawnser _turretSpawnser;
    UiManager _UIM;
    

    public EnemySpawner Spawner { get { return _spawner; } set { _spawner = value; } }
    public TurretSpawnser TurretSp { get { return _turretSpawnser; } set { _turretSpawnser = value; } }
    public UiManager UIM { get { return _UIM; } set { _UIM = value; } }




    private void Awake()
    {
        _instance = this;

        _turretSpawnser = FindObjectOfType<TurretSpawnser>();
        _spawner = FindObjectOfType<EnemySpawner>();
        _UIM= FindObjectOfType<UiManager>();

    }


    public int currentEnemies;
    public int currentHp;


    public bool roundNotFinished;
    public bool turretToSpawn;


    private void Start()
    {
        currentHp = 5;
    }
    private void Update()
    {
        RoundController();
        WinGame();


        if(currentHp <= 0 )
        {
            _UIM.GameOverScreen();
        }
    }
    void RoundController()
    {
        if(currentEnemies > 0)
        {
            roundNotFinished = true;
        }
        else
        {
            roundNotFinished = false;
        }


        if(roundNotFinished && Spawner.lastEnemy)
        {
            turretToSpawn = true;
        }
        else if(!roundNotFinished && turretToSpawn)
        {
           turretToSpawn = false;
           TurretSp.chooseTurretGroup();
           TurretSp.SpawnTourretGroup();
        }

    }

    void WinGame()
    {

        if (!roundNotFinished && Spawner.lastEnemy && Spawner.currentWave >= 2)
        {
          UIM.victoryScreen();
        }
    }

}
