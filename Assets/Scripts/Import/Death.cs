using UnityEngine;
using System.Collections;

public class Death : MonoBehaviour {
    private Animator anim;
    private bool dead;

    void Start(){
        anim = GetComponentInChildren<Animator>();
    }

    public void die()
    {
        dead = true;
        GetComponent<AudioSource>().enabled = true;
        GetComponent<GuestVisionCone>().kill();
        GetComponent<GuestVisionCone>().enabled = false;
        GetComponent<NavMeshAgent>().enabled = false;
        GetComponent<Collider>().enabled = false;
        anim.SetTrigger("Die");
    }

    public bool isDead()
    {
        return dead;
    }
}
