using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{

    private float life = 2;

    void Awake()
    {
        Destroy(gameObject, life);
    }


    // Start is called before the first frame update
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }
}
