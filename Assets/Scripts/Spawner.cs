using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject  []enemy;
    public float respwanTime = 3f;
    public int enemySpawnCount = 10; 
    public GameController gameController;

    private bool lastEnemySpawned = false;  
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(EnemySpawner()); 
    }

    // Update is called once per frame
    void Update()
    {
        if (lastEnemySpawned&&FindObjectOfType<EnemyScript>()==null)
        {
           StartCoroutine( gameController.LevelComplete());

        }
    }
    IEnumerator EnemySpawner()
    {
        for (int i = 0; i < enemySpawnCount; i++)
        {

            yield return new WaitForSeconds(respwanTime);
            SpawnEnemy();
        }
        lastEnemySpawned = true;


    }
    void SpawnEnemy()
    {
        int randomEnemy = Random.Range(0, enemy.Length);
        int randomXPos =  Random.Range(-2,2);
        Instantiate(enemy[randomEnemy], new Vector2(randomXPos,transform.position.y), Quaternion.identity);
    }
}
