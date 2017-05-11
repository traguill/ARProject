using UnityEngine;
using System.Collections;

public class ItemQuickShot : MonoBehaviour {

    void Update()
    {
        if (Game_Manager.gm.game_over)
            Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player1")
        {
            other.GetComponent<Shooter>().PickQuickShot();
            Destroy(gameObject);
        }

        if (other.tag == "Player2")
        {
            other.GetComponent<Shooter>().PickQuickShot();
            Destroy(gameObject);
        }
    }
}
