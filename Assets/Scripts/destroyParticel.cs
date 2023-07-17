using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyParticel : MonoBehaviour
{
    [SerializeField] float timer = 1;
    [SerializeField] SphereCollider colliderS;
    public int Damage;


    private void Start()
    {
        colliderS = GetComponent<SphereCollider>();
    }

    void Update()
    {
        if (timer >= 0)
        {
            timer -= Time.deltaTime;
        }
        else
        {
            Destroy(gameObject);
        }

    }
}
