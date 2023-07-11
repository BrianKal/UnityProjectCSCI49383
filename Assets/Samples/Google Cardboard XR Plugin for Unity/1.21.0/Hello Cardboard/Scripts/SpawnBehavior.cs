using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpawnBehavior : MonoBehaviour
{
    public GameObject enemy;
    GameObject currentEnemy;
    bool spawningAllowed = true;
    float spawnTimer = 0f;
    float Timer = 0f;
    float gameTimer = 300f;

    // Start is called before the first frame update
    void Start()
    {
        GenerateSpawnTime();
    }

    private void Update()
    {
        if (spawningAllowed)
        {
            Timer += Time.deltaTime;
            if (Timer >= gameTimer)
            {
                spawningAllowed = false;
                return;
            }
            if (currentEnemy == null)
            {
                spawnTimer -= Time.deltaTime;
                if (spawnTimer <= 0f)
                {
                    SpawnEnemy();
                    GenerateSpawnTime();
                }
            }
        }
        if (!spawningAllowed)
        {
            Invoke("WinScreen", 15f);
        }
    }

    void SpawnEnemy()
    {
        Vector3 center = transform.position;
        float height = transform.localScale.y;
        Vector3 topCenter = center + Vector3.up * (height / 2f);
        currentEnemy = Instantiate(enemy, topCenter, transform.rotation);
    }

    void GenerateSpawnTime()
    {
        spawnTimer = Random.Range(1, 21);
    }

    void WinScreen()
    {
        SceneManager.LoadScene("WinScreen");
    }
}
