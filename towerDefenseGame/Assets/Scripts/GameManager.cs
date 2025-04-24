using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public float enemyTimer = 0f;
    public float spawnInterval = 1f;

    public float enemyTimer2 = 0f;
    public float spawninterval2 = 4f;

    public Vector2 xBounds;
    public Vector2 yBounds;

    public GameObject enemy;
    public GameObject enemy2;


    public int enemyCounter = 0;

    public int spawnLimit = 10;
    public void Awake()
    {
        if (Instance == null)
        {
            DontDestroyOnLoad(gameObject);
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        enemyTimer += Time.deltaTime;
        Vector3 targetPos = new Vector3(Random.Range(xBounds.x, xBounds.y), Random.Range(yBounds.x, yBounds.y), 0);

        if(enemyTimer >= spawnInterval && enemyCounter < spawnLimit)
        {
            enemyTimer = 0;
            Instantiate(enemy, targetPos, Quaternion.identity);
            enemyCounter++;
        }
        if (enemyTimer2  >= spawninterval2 && enemyCounter < spawnLimit)
        {
            enemyTimer2 = 0;
            Instantiate(enemy2, targetPos, Quaternion.identity);
            enemyCounter++;
        }
    }
}
