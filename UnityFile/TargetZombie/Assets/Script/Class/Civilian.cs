using UnityEngine;

public class Civilian : MonoBehaviour
{
    private float fSpeed;
    private int civilianMaleDie = 1;
    private int civilianMaleDie2 = 1;
    private int civilianFemaleDie = 1;
    private bool checkSavedBullet = false;

    private new Rigidbody rigidbody;

    public SFXHuman HumanSound;
    private GameObject[] sfx;
    public GameObject savedText;
    public float speedAnimationChange = 7f;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
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
        animator.Play("Z_run");
    }

    public void Die()
    {
        sfx = GameObject.FindGameObjectsWithTag("sfxHumans");
        if (gameObject.tag == "MaleCivilian")
        {

            PlayerStats.currentLive -= civilianMaleDie;
            sfx[0].GetComponent<AudioSource>().clip = HumanSound.GetComponent<SFXHuman>().MaleDie;
        }

        if (gameObject.tag == "MaleCivilian2")
        {
            PlayerStats.currentLive -= civilianMaleDie2;
            sfx[0].GetComponent<AudioSource>().clip = HumanSound.GetComponent<SFXHuman>().MaleDie;
        }

        if (gameObject.tag == "FemaleCivilian")
        {
            PlayerStats.currentLive -= civilianFemaleDie;
            sfx[0].GetComponent<AudioSource>().clip = HumanSound.GetComponent<SFXHuman>().WomanDie;
        }
        sfx[0].GetComponent<AudioSource>().Play();
        Destroy(this.gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Bullet" && checkSavedBullet == false)
        {
            Die();
            Destroy(other.gameObject);
            WaveSpawner.EnemiesAlive--;
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
