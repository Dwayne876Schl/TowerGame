using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : CharacterBase
{
    public GameObject projectile;
    public float spawnTimer = 0f;
    public float spawnInterval = 1f;
    public GameObject thisTower;
    private void Update()
    {
        DisplayHealth();
        spawnTimer += Time.deltaTime;
        if (spawnTimer >= spawnInterval )
        {
            Instantiate(projectile, transform.position, Quaternion.identity);
            spawnTimer = 0f;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            Debug.Log("colliding with Enemy");
            health = health - 1;
            Destroy(collision.gameObject);
        }
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
