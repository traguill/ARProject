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
    public ExplosionAudio explosion_audio;

    public Transform double_shot_left;
    public Transform double_shot_right;

    float timer = 0.0f;

    public AudioClip[] blast;
    AudioSource audio_src;

    [HideInInspector]
    bool quick_shot_enabled = false;
    [HideInInspector]
    bool double_shot_enabled = false;

    [Header("Balance")]
    public float shoot_time = 1.0f;
    public float quick_shoot_time = 0.5f;
    public float quick_shoot_effect = 3.0f;
    public float double_shoot_effect = 3.0f;

    float initial_shoot_time;

    //Items
    float quick_shot_timer = 0.0f;
    float double_shoot_timer = 0.0f;

    private void Start()
    {
        audio_src = GetComponent<AudioSource>();
        initial_shoot_time = shoot_time;
    }

	void Update () 
    {
        if(enabled && !Game_Manager.gm.game_over && Game_Manager.gm.starting)
        {
            timer += Time.deltaTime;

            //Shoot
            if(timer >= shoot_time)
            {
                if(!double_shot_enabled)
                {
                    Bullet tmp = (Bullet)Instantiate(bullet, shoot_position.position, shoot_position.rotation);
                    tmp.direction = transform.forward;
                    timer = 0.0f;

                    audio_src.clip = blast[Random.Range(0, blast.Length)];
                    audio_src.Play();
                }
                else
                {
                    Bullet left = (Bullet)Instantiate(bullet, double_shot_left.position, double_shot_left.rotation);
                    left.direction = transform.forward;

                    Bullet right = (Bullet)Instantiate(bullet, double_shot_right.position, double_shot_right.rotation);
                    right.direction = transform.forward;

                    audio_src.clip = blast[Random.Range(0, blast.Length)];
                    audio_src.Play();
                    audio_src.clip = blast[Random.Range(0, blast.Length)];
                    audio_src.Play();
                    timer = 0.0f;
                }
                
                
            }

            //QuickShot
            if(quick_shot_enabled)
            {
                quick_shot_timer += Time.deltaTime;
                if(quick_shot_timer >= quick_shoot_effect)
                {
                    quick_shot_timer = 0.0f;
                    quick_shot_enabled = false;
                    shoot_time = initial_shoot_time;
                }
            }

            //Double Shoot
            if(double_shot_enabled)
            {
                double_shoot_timer += Time.deltaTime;
                if(double_shoot_timer >= double_shoot_effect)
                    double_shot_enabled = false;
            }
           
        }
        else
        {
            if(Game_Manager.gm.game_over)
            {
                //Reset
                double_shot_enabled = false;
                quick_shot_enabled = false;
                double_shoot_timer = 0.0f;
                quick_shot_timer = 0.0f;

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
                explosion_audio.Play();
                Game_Manager.gm.SubstractLife(id);
            }
        } 
    }

    public void PickQuickShot()
    {
        quick_shot_enabled = true;
        shoot_time = quick_shoot_time;
        quick_shot_timer = 0.0f;
    }

    public void PickDoubleShot()
    {
        double_shot_enabled = true;
        double_shoot_timer = 0.0f;
    }
}
