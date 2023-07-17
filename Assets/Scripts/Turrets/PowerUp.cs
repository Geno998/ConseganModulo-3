using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public Transform base1pos;
    public Transform base2pos;
    public Transform base3pos;

    public Base base1;
    public Base base2;
    public Base base3;

    public bool dragged;

    public enum PowerUpType
    {
        speed,
        damage
    }

    public PowerUpType type;

    private void Start()
    {
        dragged = true;
    }
    private void Update()
    {
            AttachTurret();
    }

    void AttachTurret()
    {
        float distance1 = Vector3.Distance(base1pos.position, transform.position);
        float distance2 = Vector3.Distance(base2pos.position, transform.position);
        float distance3 = Vector3.Distance(base3pos.position, transform.position);

        if (distance1 < 2)
        {
            base1.AttachPowerUp(this, transform);
        }

        if (distance2 < 2)
        {
            base2.AttachPowerUp(this, transform);
        }

        if (distance3 < 2)
        {
            base3.AttachPowerUp(this, transform);
        }

    }
}
