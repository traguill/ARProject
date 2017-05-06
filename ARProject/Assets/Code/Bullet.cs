using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

    [HideInInspector]
    public Vector3 direction;

    public float speed = 3.0f;
	
	void Update () 
    {
        transform.position += direction * speed * Time.deltaTime;
	}
}
