using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Base : MonoBehaviour
{
    [SerializeField] List<Transform> turretsslots;

    List<Transform> turretsTransforms = new List<Transform>();
    List<Turret> turrets = new List<Turret>();
    Transform powerUpTransform;
    PowerUp powerUp;

    private void Update()
    {
        putTurretsInPos();

        GivePowerUps();
    }


    void GivePowerUps()
    {
        if (powerUp != null)
        {
            if (powerUp.type == PowerUp.PowerUpType.speed)
            {
                if (turrets.Count > 0)
                {
                    for (int i = 0; i < turrets.Count; i++)
                    {
                        turrets[i].currentShootSpeed = turrets[i].shootSpeed / 2f;
                    }
                }
                Debug.Log("boosting speed");
            }


            if (powerUp.type == PowerUp.PowerUpType.damage)
            {
                if (turrets.Count > 0)
                {
                    for (int i = 0; i < turrets.Count; i++)
                    {
                        turrets[i].currentDamage = turrets[i].damage * 2;
                    }
                }
                Debug.Log("boosting damage");
            }
        }

    }

    void putTurretsInPos()
    {

        if (turrets.Count > 0)
        {
            for (int i = 0; i < turretsTransforms.Count; i++)
            {
                turretsTransforms[i].position = turretsslots[i].position;

                if (i == turretsTransforms.Count - 1)
                {
                    if (powerUp != null)
                    {
                        powerUpTransform.position = turretsslots[i + 1].position;
                    }
                }
            }
        }
    }

    public void attachTurret(Transform turretTrans, Turret turret)
    {
        if (turretsTransforms.Count < 3)
        {
            turretsTransforms.Add(turretTrans);
            turrets.Add(turret);
            turret.dragged = false;
        }
    }


    public void AttachPowerUp(PowerUp PowerUp, Transform PowerUpTransform)
    {
        if (powerUp == null && turrets.Count > 0)
        {
            powerUp = PowerUp;
            powerUpTransform = PowerUpTransform;
            PowerUp.dragged = false;
        }
    }

}
