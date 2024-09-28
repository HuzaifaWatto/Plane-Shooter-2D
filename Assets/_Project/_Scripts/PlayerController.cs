using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject VFX;
    public GameObject DamageVFX;
    public PlayerHealth playerHealth;
    public CoinCount coinCount;
    public GameController gameController;
    public AudioSource audioSource;
    public AudioClip DamageAudioClip;
    public AudioClip explosionAudioClip;
    public AudioClip coinClip;

    public float speed = 10f;
    public float padding = 0.8f;
    public float health = 20f;

    float barFillAmount = 1f;
    float damage = 0;
    float minX;
    float maxX;
    float minY;
    float maxY;

    private void Start()
    {
        FindBoundary();
        damage = barFillAmount / health;
    }
    void Update()
    {
        Movement();
    }
    void Movement()
    {
        //keyboardMovement
        //float deltaY = Input.GetAxis("Vertical") * Time.deltaTime * speed;
        //float deltaX = Input.GetAxis("Horizontal") * Time.deltaTime * speed;

        //float Xpos = Mathf.Clamp(transform.position.x + deltaX, minX, maxX);
        //float Ypos = Mathf.Clamp(transform.position.y + deltaY, minY, maxY);
       
        //transform.position = new Vector2(Xpos, Ypos);

        //mobile movement
        if(Input.GetMouseButton(0)) 
        {
            Vector2 newPos = Camera.main.ScreenToWorldPoint(new Vector2(Input.mousePosition.x, Input.mousePosition.y));
            transform.position = Vector2.Lerp(transform.position, newPos, 10 * Time.timeScale);
        }
    }
    void FindBoundary()
    {
        Camera gameCam = Camera.main;
        minX = gameCam.ViewportToWorldPoint(new Vector3(0, 0, 0)).x + padding;
        maxX = gameCam.ViewportToWorldPoint(new Vector3(1, 0, 0)).x - padding;

        minY = gameCam.ViewportToWorldPoint(new Vector3(0, 0, 0)).y + padding;
        maxY = gameCam.ViewportToWorldPoint(new Vector3(0, 1, 0)).y - padding;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("EnemyBullet"))
        {
            audioSource.PlayOneShot(DamageAudioClip, .5f);
            DamageHealth();
            Destroy(collision.gameObject);
            GameObject dmgVFX = Instantiate(DamageVFX, collision.transform.position, Quaternion.identity);
            Destroy(dmgVFX, .05f);
            if (health <= 0)
            {
                AudioSource.PlayClipAtPoint(explosionAudioClip, Camera.main.transform.position, .5f);
                Destroy(gameObject);
                GameObject VFXExplosion = Instantiate(VFX, transform.position, Quaternion.identity);
                Destroy(VFXExplosion, 2f);
                gameController.GameOver();
            }
        }
        if (collision.CompareTag("Coin"))
        {
            audioSource.PlayOneShot(coinClip, .5f);
            Destroy(collision.gameObject);
            coinCount.AddCount();
        }
    }
    void DamageHealth()
    {
        if (health > 0 )
        {
            health -= 1;
            barFillAmount = barFillAmount - damage;
            playerHealth.SetAmount(barFillAmount);
        }
    }
}
