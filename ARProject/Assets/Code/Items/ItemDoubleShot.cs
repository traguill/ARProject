using UnityEngine;
using System.Collections;

public class ItemDoubleShot : MonoBehaviour {

    void Update()
    {
        if (Game_Manager.gm.game_over)
            Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player1")
        {
            other.GetComponent<Shooter>().PickDoubleShot();
            Destroy(gameObject);
        }

        if (other.tag == "Player2")
        {
            other.GetComponent<Shooter>().PickDoubleShot();
            Destroy(gameObject);
        }
    }
}
