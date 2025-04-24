using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.UI;
using UnityEngine;

public class Enemy : CharacterBase
{
    public float speed;
    public float xspeed = 0.02f;
    public float yspeed = 0.05f;

    public GameObject thisObject;
    public float xDir = 0f;
    public float yDir = 0f;

    public GameManager manager;
    public float reverseTime = 0f;
    public float reverseInterval = 3.0f;


    // Start is called before the first frame update
    void Start()
    {
        speed = Random.Range(xspeed, yspeed);
        xDir = Random.Range(-1f, 1f);
        yDir = Random.Range(-1f, 1f);
        

        //PlayerPrefs.transform postion += new Vector3(0, 1, 0);

    }

    // Update is called once per frame
    void Update()
    {
        DisplayHealth();
        manager = FindObjectOfType<GameManager>();
  
        thisObject.transform.position += new Vector3(xDir, yDir, 0) * speed;
        reverseTime += Time.deltaTime;
        if (reverseTime >= reverseInterval)
        {
            reverseTime = 0f;
            xDir = xDir * -1;
            yDir = yDir * -1;
        }
        if (health <= 0)
        {
            //manager.enemyCounter--;
            Destroy(gameObject);
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Projectile")
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}
