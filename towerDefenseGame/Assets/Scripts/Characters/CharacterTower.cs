using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterTower : Tower
{
    public GameObject player;
    public float speed = 0.2f;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        DisplayHealth();
        if (Input.GetKey(KeyCode.W))
        {
            //find the player game object, find that object's transform and position, increase the Y value by adding Vector3.up, multiplied by speed to determine rate of increase
            player.transform.position += Vector3.up * speed;
        }

        if (Input.GetKey(KeyCode.S))
        {
            player.transform.position += Vector3.down * speed;
        }

        if (Input.GetKey(KeyCode.A))
        {
            player.transform.position += Vector3.left * speed;
        }

        if (Input.GetKey(KeyCode.D))
        {
            player.transform.position += Vector3.right * speed;
        }
        if (Input.GetKey(KeyCode.L))
        {
            Instantiate(projectile, transform.position, Quaternion.identity);
        }
    }
}
