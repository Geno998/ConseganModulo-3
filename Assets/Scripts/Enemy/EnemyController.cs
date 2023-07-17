using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public EnemyStats stats;

    public int HP = 1;
    float speed;
    public List<Transform> targets;
    int currentTarget;


    private void Start()
    {
        HP = stats.maxHP;
        speed = stats.speed;

    }

    private void Update()
    {
        attack();
        Move();
        Death();
    }


    private void Move()
    {
        if (transform.position != targets[currentTarget].position)
        {
            transform.position = Vector3.MoveTowards(transform.position, targets[currentTarget].position, speed * Time.deltaTime);
        }
        else
        {
            currentTarget++;
        }
    }


    private void attack()
    {
        if (transform.position != targets[currentTarget].position && currentTarget == targets.Count - 1)
        {
            Destroy(gameObject);
            GameManager.Instance.currentEnemies--;
            GameManager.Instance.currentHp --;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bullet"))
        {
            HP -= other.GetComponent<Bullet>().Damage;
        }

    }



    private void Death()
    {
        if (HP <= 0)
        {
            GameManager.Instance.currentEnemies--;
            Destroy(gameObject);
        }

    }
}
