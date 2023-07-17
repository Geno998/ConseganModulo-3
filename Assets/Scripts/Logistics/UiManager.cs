using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class UiManager : MonoBehaviour
{



    [SerializeField] TextMeshProUGUI Hp;
    [SerializeField] TextMeshProUGUI round;
    [SerializeField] GameObject pressSpace;

    GameManager Gm;
    EnemySpawner spawner;


    private void Start()
    {
        Gm = GameManager.Instance;
        spawner = GameManager.Instance.Spawner;

    }


    private void Update()
    {
        if (Gm != null)
        {
            if (!Gm.roundNotFinished)
            {
                pressSpace.SetActive(true);
            }
            else
            {
                pressSpace.SetActive(false);
            }

            Hp.text = new string("Hp: " + Gm.currentHp);
            round.text = new string("round: " + spawner.currentWave + 1 + "/3");
        }
    }

    public void playGame()
    {
        SceneManager.LoadScene(1);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void victoryScreen()
    {
        SceneManager.LoadScene(2);
    }

    public void GameOverScreen()
    {
        SceneManager.LoadScene(3);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
