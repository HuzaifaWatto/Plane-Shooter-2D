using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerController : MonoBehaviour
{
    public GameObject[] Enemy;
    public GameController Controller;
    public float respawnTime = 2f;
    public int enemySpawnCount;

    bool lastSpawning = false;
    private void Start()
    {
        StartCoroutine(Spawn());

    }
    private void Update()
    {
        if (lastSpawning && FindObjectOfType<EnemyController>() == null)
        {
            StartCoroutine(Controller.LevelComplete());
            
        }
    }
    void SpawnEnemy()
    {
        int randonValue = Random.Range(0, Enemy.Length);
        int randomPos = Random.Range(-2, 2);
        Instantiate(Enemy[randonValue], new Vector2(randomPos, transform.position.y), Quaternion.identity);
    }
    IEnumerator Spawn()
    {
        for (int i = 0; i < enemySpawnCount; i++)
        {
            yield return new WaitForSeconds(respawnTime);
            SpawnEnemy();
        }
        lastSpawning = true;
    }

}
