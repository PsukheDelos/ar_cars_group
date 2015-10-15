using UnityEngine;
using System.Collections;

public class TurnOnGravityOnContact : MonoBehaviour {
    public GameObject contact;
    private bool once = false;

    void OnCollisionEnter(Collision c){
        if (!once)
        {
            once = true;
            GetComponent<Rigidbody>().useGravity = true;
            GetComponent<TrailRenderer>().enabled = false;
            GameObject hit = GameObject.Instantiate(contact);
            hit.transform.position = transform.position;
            GameObject.Destroy(hit, 0.3f);
        }
    }
}
