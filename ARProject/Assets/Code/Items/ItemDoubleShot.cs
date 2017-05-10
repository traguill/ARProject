using UnityEngine;
using System.Collections;

public class ItemDoubleShot : MonoBehaviour {

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
