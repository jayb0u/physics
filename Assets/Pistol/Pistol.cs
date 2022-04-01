using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : MonoBehaviour
{
    public Transform barrel;
    public LineRenderer bullettrail;

    const float firerange = 100f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //si j'appuie sur Fire1
        if (Input.GetButtonDown("Fire1"))
        {
            Fire();
        }
        
    }

    void Fire()
    {
        //bullet trail A
        bullettrail.SetPosition(0, barrel.position);
        //je crée un rayon
        Ray fireray = new Ray(barrel.position, barrel.forward);

        //contient les infos de ce qui est touché
        RaycastHit hit;


        //si le rayon touche
        if (Physics.Raycast(fireray,out hit, firerange))
        {
            //message indique ce qui a été touché
            Debug.Log($"{hit.transform.name} touchée");

            //s'il s'agit d'un IDamageable
            IDamageable damageable = hit.transform.GetComponentInParent<IDamageable>();
            if (damageable != null)
            {
                damageable.TakeDamage();
            }

            //bullet trail B
            bullettrail.SetPosition(1, hit.point);
        }
        else
        {

            bullettrail.SetPosition(1, barrel.position + barrel.forward * firerange);
        }


    }
}
