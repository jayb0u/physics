using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombSpawner : MonoBehaviour
{
    public GameObject BombePrefab;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //si j'appuie sur Fire2
        if (Input.GetButtonDown("Fire2"))
        {
            //Spawn une bombe devant soi
            Instantiate(BombePrefab, transform.position + transform.forward, Quaternion.identity);
        }

    }
}
