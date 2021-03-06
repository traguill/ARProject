﻿using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

    [HideInInspector]
    public Vector3 direction;

    public float speed = 3.0f;

    float timer = 0.0f;
	
	void Update () 
    {
        if (!Game_Manager.gm.game_over)
            transform.position += direction * speed * Time.deltaTime;
        else
            Destroy(gameObject);

        timer += Time.deltaTime;
        if (timer >= 5.0f)
            Destroy(gameObject);
	}

    void OnCollisionEnter(Collision collision)
    {
       if(collision.gameObject.tag == "Field")
        {
            Vector3 n = collision.contacts[0].normal.normalized;

            direction = direction - 2 * (Vector3.Dot(direction, n)) * n;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Bounds")
        {
            Destroy(gameObject);
        }
    }
}
