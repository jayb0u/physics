using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crate : MonoBehaviour, IDamageable
{
    public void TakeDamage()
    {
        //masquer le parent
        GetComponent<MeshRenderer>().enabled = false;
        GetComponent<BoxCollider>().enabled = false;
        GetComponent<Rigidbody>().isKinematic = true;

        // liberer les enfants
        transform.GetChild(0).gameObject.SetActive(true);


    }
}
