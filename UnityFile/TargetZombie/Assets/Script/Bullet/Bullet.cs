using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private new Rigidbody rigidbody;
    public float speed = 10;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        rigidbody.velocity = transform.forward * speed * 0.5f * Mover.speed;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "SpecialEnemy")
        {
            PlayerStats.hasFlashKill = true;
        }
    }
}
