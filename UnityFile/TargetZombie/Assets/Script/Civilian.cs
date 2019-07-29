using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Civilian : MonoBehaviour
{
    private float fSpeed;
    private int civilianMaleDie = 1;
    private int civilianMaleDie2 = 1;
    private int civilianFemaleDie = 1;
    private bool checkSavedBullet = false;

    private new Rigidbody rigidbody;

    public GameObject savedText;
    public float speedAnimationChange = 7f;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();

        Debug.Log("current Health: " + PlayerStats.currentLive);
        fSpeed = Mover.speed;
        if (fSpeed >= speedAnimationChange)
        {
            ChangeAnimatorZombie();
        }
    }

    public void ChangeAnimatorZombie()
    {
        Animator animator = gameObject.GetComponent<Animator>();
        animator.SetFloat("speed", fSpeed);
        Debug.Log("Animation Changed Civilian!");
        animator.Play("Z_run");
    }

    public void Die()
    {
        if(gameObject.tag == "MaleCivilian")
        {

            PlayerStats.currentLive -= civilianMaleDie;
        }

        if (gameObject.tag == "MaleCivilian2")
        {
            PlayerStats.currentLive -= civilianMaleDie2;
        }

        if (gameObject.tag == "FemaleCivilian")
        {
            PlayerStats.currentLive -= civilianFemaleDie;
        }
        Destroy(this.gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Bullet")
        {
            Die();
            Destroy(other.gameObject);
            WaveSpawner.EnemiesAlive--;
            Debug.Log("current Health: " + PlayerStats.currentLive);
        }
        else if (other.tag == "Saver" && checkSavedBullet == false)
        {
            savedText.SetActive(true);
            Destroy(other.gameObject);

            ChangeAnimatorZombie();
            rigidbody.velocity = transform.forward * Mover.speed * 4;

            checkSavedBullet = true;
        }
        
    }
}
