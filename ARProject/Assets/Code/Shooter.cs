using UnityEngine;
using System.Collections;

public class Shooter : MonoBehaviour 
{
    public int id; //Player 1 or 2
    public Bullet bullet;

    [HideInInspector]
    public bool enabled = false;

    public Transform shoot_position;
    public ParticleSystem explosion_hit;

    float timer = 0.0f;

	void Update () 
    {
        if(enabled && !Game_Manager.gm.game_over)
        {
            timer += Time.deltaTime;

            if(timer >= 1.0f)
            {
                Bullet tmp = (Bullet)Instantiate(bullet, shoot_position.position, shoot_position.rotation);
                tmp.direction = transform.forward;
                timer = 0.0f;
            }
           
        }
	}

    void OnCollisionEnter(Collision col)
    {
        if(!Game_Manager.gm.game_over)
        {
            if (col.gameObject.tag == "Bullet")
            {
                Destroy(col.gameObject);
                explosion_hit.Play();
                Game_Manager.gm.SubstractLife(id);
            }
        } 
    }
}
