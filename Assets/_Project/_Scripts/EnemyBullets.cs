using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullets : MonoBehaviour
{
    public float speed = 10f;



    void Update()
    {
        transform.Translate(Vector2.up * speed * Time.deltaTime);

    }
}
