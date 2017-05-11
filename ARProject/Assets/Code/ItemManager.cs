using UnityEngine;
using System.Collections;

public class ItemManager : MonoBehaviour {

    public GameObject[] items;

    public Transform player1;
    public Transform player2;

    public float min_spawn_time = 3.0f;
    public float max_spawn_time = 5.0f;

    float timer = 0.0f;
    float spawn_time = 0.0f;

    private void Start()
    {
        spawn_time = Random.Range(min_spawn_time, max_spawn_time);   
    }

	
	// Update is called once per frame
	void Update ()
    {
        if(Game_Manager.gm.starting && !Game_Manager.gm.game_over)
        {
            timer += Time.deltaTime;
            if(timer >= spawn_time)
            {
                spawn_time = Random.Range(min_spawn_time, max_spawn_time);
                timer = 0.0f;
                SpawnRndItem();
            }
        }
	}

    private void SpawnRndItem()
    {
        Vector3 dst = player2.position - player1.position;
        dst *= -0.5f;
        dst += player2.position;

        Instantiate(items[Random.Range(0, items.Length)], dst, Quaternion.Euler(new Vector3(0,90,0)));
    }
}
