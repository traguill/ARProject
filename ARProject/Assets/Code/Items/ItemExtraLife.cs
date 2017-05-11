using UnityEngine;
using System.Collections;

public class ItemExtraLife : MonoBehaviour
{

    void Update()
    {
        if (Game_Manager.gm.game_over)
            Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player1")
        {
            Game_Manager.gm.AddLife(1);
            Destroy(gameObject);
        }

        if(other.tag == "Player2")
        {
            Game_Manager.gm.AddLife(2);
            Destroy(gameObject);
        }
    }
}
