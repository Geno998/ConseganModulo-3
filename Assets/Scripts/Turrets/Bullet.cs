using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{


    public int Damage;
    public int bulletSpeed;
    [SerializeField] bool bulletExplosive;
    [SerializeField] SphereCollider colliderS;
    [SerializeField] GameObject explosion;

    [SerializeField] float timer = 5;



    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * bulletSpeed);

        if (timer >= 0)
        {
            timer -= Time.deltaTime;
        }
        else
        {
            Destroy(gameObject);
        }
    }


    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Enemie"))
        {
            if (bulletExplosive)
            {
               GameObject tmp = Instantiate(explosion, other.transform.position, Quaternion.identity);
               destroyParticel exp = tmp.GetComponent<destroyParticel>();
                exp.Damage = Damage;
            }
            Destroy(gameObject);
        }
    }
}
