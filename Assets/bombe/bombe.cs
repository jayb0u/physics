using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bombe : MonoBehaviour
{
    const float radius = 30f;
    // Start is called before the first frame update
    void Start()
    {
        //call Explode après 3 secondes
        Invoke("Explode", 3f);
    }

    void Explode()
    {
        // recuperer les objets à proximité
        Collider[] colliders = Physics.OverlapSphere(transform.position,radius);

        // s'il a un rigidbody, propulse
        foreach (Collider c in colliders)
        {
            //s'il s'agit d'un IDamageable
            IDamageable damageable = c.transform.GetComponentInParent<IDamageable>();
            if (damageable != null)
            {
                damageable.TakeDamage();
            }

            // on a trouvé un rigidbody
            if (c.TryGetComponent(out Rigidbody rb))
            {
                // appliquer une force
                rb.AddExplosionForce(300f, transform.position, radius, 2f);
            }

            

        }


        // détruire la bombe
        Destroy(gameObject);
    }
}
