using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public GameObject Bullet;
    public Transform LeftSpawnPoint;
    public Transform RightSpawnPoint;
    public GameObject rightFlash;
    public AudioSource audioSource;
    public float bulletSpawnTime = 1f;

    private void Start()
    {
        rightFlash.SetActive(false);
        StartCoroutine(Shooting());
    }
    void AutomaticFire()
    {
        Instantiate(Bullet, RightSpawnPoint.position, Quaternion.identity);
        Instantiate(Bullet, LeftSpawnPoint.position, Quaternion.identity);
    }

    IEnumerator Shooting()
    {
        while (true)
        {
          yield return new WaitForSeconds(bulletSpawnTime);
            AutomaticFire();
            audioSource.Play();
            rightFlash.SetActive(true);
            yield return new WaitForSeconds(.04f);
            rightFlash.SetActive(false);

        }

    }

}
