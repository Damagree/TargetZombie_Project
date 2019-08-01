using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int worth = 10;

    public GameObject ImpactEffect;

    private float fSpeed;
    private bool checkSavedBullet = false;
    private new Rigidbody rigidbody;

    public float speedAnimationChange = 7f;

    public GameObject rushText;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();

        fSpeed = Mover.speed;
        if (fSpeed >= speedAnimationChange)
        {
            ChangeAnimatorZombie();
        }
    }

    public void Die()
    {
        PlayerStats.Score += worth;
        WaveSpawner.EnemiesAlive--;
        Destroy(this.gameObject);
    }

    public void ChangeAnimatorZombie()
    {
        Animator animator = gameObject.GetComponent<Animator>();
        animator.SetFloat("speed", fSpeed);
        animator.Play("Z_run");
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Bullet" && checkSavedBullet == false)
        {
            Destroy(other.gameObject);
            Die();

            //effect
            GameObject Effect = Instantiate(ImpactEffect, this.gameObject.transform.position, Quaternion.identity);
            Destroy(Effect, 2f);
        }
        else if (other.tag == "Saver" && checkSavedBullet == false)
        {
            rushText.SetActive(true);
            Destroy(other.gameObject);

            ChangeAnimatorZombie();

            rigidbody.velocity = transform.forward * Mover.speed * 4;

            checkSavedBullet = true;
        }
    }
}
