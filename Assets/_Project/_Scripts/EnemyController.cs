using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public HealthBar healthBar;

    public Transform []SpawnPoint;
    public GameObject rightFlash;
    public GameObject bullets;
    public GameObject Explosion;
    public GameObject DamageVFX;
    public GameObject coin;
    public AudioSource audioSource;
    public AudioClip bulletClip;
    public AudioClip damageClip;
    public AudioClip ExplosionClip;

    public float bulletSpawnTime = 1f;
    public float speed = 1f;
    public float maxHealth = 10;
    float health;

    float barSize = 1f;
    float damage = 0;


    void Start()
    {
        rightFlash.SetActive(false);
        StartCoroutine(Shooting());
        health = maxHealth;
        damage = barSize / health;
    }
    void Update()
    {
        transform.Translate(Vector2.down * speed * Time.deltaTime);
    }
    void EnemyFire()
    {
        for (int i = 0; i < SpawnPoint.Length; i++)
        {
           Instantiate(bullets, SpawnPoint[i].position, Quaternion.identity);

        }
    }
    IEnumerator Shooting()
    {
        while (true)
        {
            yield return new WaitForSeconds(bulletSpawnTime);
            EnemyFire();
            audioSource.PlayOneShot(bulletClip, .5f);
            rightFlash.SetActive(true);
            yield return new WaitForSeconds(.04f);
            rightFlash.SetActive(false);

        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("PlayerBullet"))
        {
            audioSource.PlayOneShot(damageClip, .5f);
            DamageHealth();
            Destroy(collision.gameObject);
            GameObject dmgVFX = Instantiate(DamageVFX, collision.transform.position, Quaternion.identity);  
                Destroy(dmgVFX, .05f);
            if(health <= 0)
            {
                AudioSource.PlayClipAtPoint(ExplosionClip, Camera.main.transform.position, .5f);
                Destroy(gameObject);
                GameObject EnemyExplosion = Instantiate(Explosion, transform.position, Quaternion.identity);  
                Destroy(EnemyExplosion,.4f);
                Instantiate(coin, transform.position, Quaternion.identity);
            }
        }
      
    }
    void DamageHealth()
    {
        if(health > 0)
        {
            health -= 1;
            healthBar.SetSize(health / maxHealth);
        }
    }
}
