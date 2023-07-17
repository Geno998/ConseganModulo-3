using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Turret : MonoBehaviour
{
    [SerializeField] List<Transform> EnemiesInRange;
    Transform LockedEnemie;
    [SerializeField] Transform Muzzle;
    [SerializeField] GameObject visualRange;
    [SerializeField] GameObject Bullet;
    [SerializeField] float offset;

    public bool Dragable;


    public Transform base1pos;
    public Transform base2pos;
    public Transform base3pos;

    public Base base1;
    public Base base2;
    public Base base3;


    public int damage = 1;
    public int currentDamage;


    public bool showingRange;
    public bool dragged;

    [SerializeField] LayerMask turret;


    int stackNumber;

    public float shootSpeed;
    public float currentShootSpeed;
    float timer;


    private void Start()
    {
        currentDamage = damage; currentShootSpeed = shootSpeed;
    }


    private void Update()
    {
        if (!dragged)
        {
            EnemiesKilledCheck();
            AimAtTarget();
            shoot();
            placeCheck();
            showingRange = false;
        }
        else
        {
            AttachTurret();
            showingRange = true;
        }


        if (showingRange)
        {
            visualRange.SetActive(true);
        }
        else
        {
            visualRange.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            EnemiesInRange.Add(other.gameObject.transform);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            EnemiesInRange.Remove(other.gameObject.transform);
        }
    }



    void EnemiesKilledCheck()
    {
        for (int i = 0; i < EnemiesInRange.Count; i++)
        {
            if (EnemiesInRange[i] == null)
            {
                EnemiesInRange.RemoveAt(i);
            }
        }
    }

    void AimAtTarget()
    {
        if (EnemiesInRange.Count != 0)
        {
            LockedEnemie = EnemiesInRange[0];

            var lookPosX = LockedEnemie.position - transform.position;
            lookPosX.y = 0;

            var rotationX = Quaternion.LookRotation(lookPosX);

            transform.rotation = Quaternion.Slerp(transform.rotation, rotationX, Time.deltaTime * 50f);
            Muzzle.LookAt(LockedEnemie);
            Debug.DrawRay(Muzzle.position, Muzzle.forward * 20, Color.red, 1);
        }
    }

    void shoot()
    {

        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }
        else
        {
            if (EnemiesInRange.Count != 0)
            {

                GameObject tmpBullet = Instantiate(Bullet, Muzzle.position, Muzzle.rotation, Muzzle);
                tmpBullet.GetComponent<Bullet>().Damage = currentDamage;
                timer = currentShootSpeed;
            }
        }


    }



    void placeCheck()
    {
        Ray ray = new Ray(transform.position, Vector3.down);
        RaycastHit hit;

        // Perform a sphere cast and store the hit information

        if (Physics.Raycast(ray, out hit, 100f, turret))
        {
            transform.position = new Vector3(hit.transform.position.x, hit.transform.position.y + offset, hit.transform.position.z);
            Debug.Log(hit.transform.name);
        }
        else
        {

        }
    }

    void AttachTurret()
    {
        float distance1 = Vector3.Distance(base1pos.position, transform.position);
        float distance2 = Vector3.Distance(base2pos.position, transform.position);
        float distance3 = Vector3.Distance(base3pos.position, transform.position);

        if (distance1 < 2)
        {
            base1.attachTurret(transform, this);
        }

        if (distance2 < 2)
        {
            base2.attachTurret(transform, this);
        }

        if (distance3 < 2)
        {
            base3.attachTurret(transform, this);
        }

    }

}
