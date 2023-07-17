using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DragScript : MonoBehaviour

{

    private Vector3 mOffset;
    private float mZCoord;

    Turret turret;
    PowerUp pUp;
    BoxCollider bCollider;

    private void Start()
    {
        turret = GetComponent<Turret>();
        bCollider = GetComponent<BoxCollider>();
        pUp = GetComponent<PowerUp>();
    }

    private void Update()
    {
        if (turret != null)
        {
            if (turret.dragged)
            {
                bCollider.enabled = false;
            }
        }
        else
        {
            if (pUp.dragged)
            {
                bCollider.enabled = false;
            }
        }


    }


    void OnMouseDown()
    {
        if (turret != null)
        {
            if (turret.dragged)
            {
                mZCoord = Camera.main.WorldToScreenPoint(
                gameObject.transform.position).z;
                mOffset = gameObject.transform.position - GetMouseAsWorldPoint();
            }
        }
        else
        {
            if (pUp.dragged)
            {
                mZCoord = Camera.main.WorldToScreenPoint(
                gameObject.transform.position).z;
                mOffset = gameObject.transform.position - GetMouseAsWorldPoint();
            }
        }


    }



    private Vector3 GetMouseAsWorldPoint()
    {
        Vector3 mousePoint = Input.mousePosition;
        mousePoint.z = mZCoord;
        return Camera.main.ScreenToWorldPoint(mousePoint);
    }



    void OnMouseDrag()
    {
        if (turret != null)
        {
            if (turret.dragged)
            {
                transform.position = new Vector3(GetMouseAsWorldPoint().x + mOffset.x, transform.position.y, GetMouseAsWorldPoint().z + mOffset.z);
            }
        }
        else
        {
            if (pUp.dragged)
            {
                transform.position = new Vector3(GetMouseAsWorldPoint().x + mOffset.x, transform.position.y, GetMouseAsWorldPoint().z + mOffset.z);
            }
        }


    }

}
