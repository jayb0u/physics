using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vanguard : MonoBehaviour, IDamageable
{
    Rigidbody[] rbs;
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        rbs = GetComponentsInChildren<Rigidbody>();
        animator = GetComponent<Animator>();
        // désactiver le ragdoll
        ToggleRagdoll(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Die()
    {
        // activer le ragdoll
        ToggleRagdoll(true);
    }

    void ToggleRagdoll(bool value)
    {
        // Activer/Désactiver les rigidbodies
        foreach (var rb in rbs)
        {
            rb.isKinematic = !value;

        }

        // Activer/Désactiver l'animator
        animator.enabled = !value;
    }

    public void TakeDamage()
    {
        Die();
    }
}
